using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[System.Serializable]
public class ClickEvent
{
	public int userId;
	public float x;
	public float y;
	
	public ClickEvent(int id, float x, float y)
	{
		userId = id;
		this.x = x;
		this.y = y;
	}
}

public class JsonConverter
{
	public static string Serialize<T>(T obj)
	{
		return JsonUtility.ToJson(obj);
	}

	public static T Deserialize<T>(string json)
	{
		return JsonUtility.FromJson<T>(json);
	}
}

public class Client : MonoBehaviour
{
	[Header("IP Input")]
	public TMP_InputField ip;
	public TMP_InputField port;
	public Button connectButton;
	
	[Header("Message Input")]
	public TMP_InputField message;
	public Button send;
	
	[Header("Text Area")]
	public RectTransform textArea;
	public TextMeshProUGUI textPrefab;


	private Thread clientThread; // 쓰레드
	private StreamReader reader; // 스트림 리더
	private StreamWriter writer; // 스트림 라이터
	
	private bool isConnected;

	public static Queue<string> log = new Queue<string>();

	public int id;
	
	
	private void Awake()
	{
		connectButton.onClick.AddListener(ConnectButtonClick);
		send.onClick.AddListener(() => SendSubmit(message.text));
		message.onEndEdit.AddListener(SendSubmit);
	}

	private void Update()
	{
		CreateLog();
	}

	private void CreateLog()
	{
		if (log.Count > 0)
		{
			TextMeshProUGUI logText = Instantiate(textPrefab, textArea);
			logText.text = log.Dequeue();
		}
	}

	public void OnClickEvent(InputAction.CallbackContext context)
	{
		if (!context.started)
			return;
		Vector2 mousePosition = Mouse.current.position.ReadValue();
		ClickEvent clickEvent = new ClickEvent(id, mousePosition.x, mousePosition.y);
		SendSubmit(JsonConverter.Serialize(clickEvent));
	}

	private void ClientThread()
	{
		try
		{
			// 클라이언트 객체 생성
			TcpClient tcpClient = new TcpClient();
			// ip 입력란의 텍스트를 ip 주소로 파싱
			IPAddress serverAddress = IPAddress.Parse(ip.text);
			// Port = 0 ~ 65535 까지의 번호를 씀 = ushort 범위랑 같지만, C# 에서 주로 쓰이는 정수 자료형이 int 이므로 port 번호는 int로 취급
			int portNum = int.Parse(port.text);

			// 2번째 매개변수로 ushort가 아닌 int형으로 입력 받음
			IPEndPoint endPoint = new IPEndPoint(serverAddress, portNum);

			// 서버로 연결 시도
			tcpClient.Connect(endPoint);

			// 여기까지 코드가 실행 되었으면 서버에 접속 성공
			log.Enqueue("서버접속 성공~");


			//버퍼새로여는건강?
			reader = new StreamReader(tcpClient.GetStream());
			writer = new StreamWriter(tcpClient.GetStream());
			writer.AutoFlush = true; //?

			while (tcpClient.Connected)
			{
				string receiveMessage = reader.ReadLine();
				log.Enqueue(receiveMessage);
			}
		}
		catch (ApplicationException e)
		{
			log.Enqueue("어플리케이션 예외가 발생했습니다.");
			log.Enqueue(e.Message);
		}
		catch (Exception e)
		{
			log.Enqueue("뭔가... 문제가 발생했습니다.");
			log.Enqueue(e.Message);
		}
		finally
		{
			// try 문 내의 구문이 실행이 됐건 exception에 의해 끊겼건 반드시 호출
			if (reader != null)
				reader.Close();
			if (writer != null)
				writer.Close();
			clientThread.Abort();
			isConnected = false;
		}
	}
	
	private void ConnectButtonClick()
	{
		// 접속중이 아니므로 접속 시도
		if (false == isConnected)
		{
			clientThread = new Thread(ClientThread);
			clientThread.IsBackground = true;
			clientThread.Start();
			isConnected = true;
		}
		// 접속 끊기
		else
		{
			clientThread.Abort();
			isConnected = false;
		}
	}

	private void SendSubmit(string message)
	{
		// log.Enqueue(message);
		writer.WriteLine(message);
		this.message.text = "";
	}
	
}
