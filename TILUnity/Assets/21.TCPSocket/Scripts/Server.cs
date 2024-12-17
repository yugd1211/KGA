using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Server : MonoBehaviour
{
	public Button connect;
	public RectTransform textArea;
	public TextMeshProUGUI textPrefab;

	private string ipAddress = "127.0.0.1"; // localhost
	public int port = 9999;
	// port = 0 ~ 65535중 하나 사용. 80번 이전의 port는 이미 대부분 선점이 되어있다.

	private bool isConnected = false;
	
	private Thread serverMainThread;
	private int clientId = 0;
	
	private List<ClientHandler> clients = new List<ClientHandler>();

	public static Queue<string> log = new Queue<string>();

	private void Awake()
	{
		connect.onClick.AddListener(ConnectButtonClick);
	}
	
	
	private void Update()
	{
		if (log.Count > 0)
		{
			TextMeshProUGUI logText = Instantiate(textPrefab, textArea);
			logText.text = log.Dequeue();
		}
	}

	private void ConnectButtonClick()
	{
		if (false == isConnected)
		{
			serverMainThread = new Thread(ServerThread);
			serverMainThread.IsBackground = true;
			serverMainThread.Start();
			isConnected = true;
		}
		else
		{
			serverMainThread.Abort();
			isConnected = false;
		}
	}

	private void ServerThread()
	{
		try
		{
			TcpListener tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);
			tcpListener.Start();
			log.Enqueue("서버 시작됨");
			while (true)
			{
				// acceptTcpClient()는 클라이언트가 접속할때까지 대기한다.
				TcpClient tcpClient = tcpListener.AcceptTcpClient();
				ClientHandler handler = new ClientHandler();
				handler.Connect(clientId++, this, tcpClient);

				clients.Add(handler);
				// Instantiate(textPrefab, textArea).text = $"{clientId}번 클라이언트가 접속됨.";
				log.Enqueue($" {clientId}번 클라이언트가 접속됨.");

				// 멀티스레드에서 code, data영역에 대한 접근을 원천차단함
			}
		}
		catch (Exception e)
		{
			log.Enqueue(e.Message);
		}
		finally
		{
			foreach (ClientHandler client in clients)
				client.Disconnect();
			serverMainThread.Abort();
			isConnected = false;
		}
	}

	public void Disconnect(ClientHandler client)
	{
		clients.Remove(client);
	}

	public void BroadcastToClients(string message)
	{
		log.Enqueue(message);
		foreach (ClientHandler client in clients)
		{
			client.MessageToClient(message);
		}
	}
	
}


public class ClientHandler
{
	public int id;
	public Server server;
	public TcpClient tcpClient;
	public Thread clientThread;
	public StreamReader reader;
	public StreamWriter writer;

	public void Connect(int id, Server server, TcpClient tcpClient)
	{
		this.id = id;
		this.server = server;
		this.tcpClient = tcpClient;
		reader = new StreamReader(tcpClient.GetStream());
		writer = new StreamWriter(tcpClient.GetStream());
		writer.AutoFlush = true;
		clientThread = new Thread(Run);
		clientThread.IsBackground = true;
		clientThread.Start();
	}

	public void Disconnect()
	{
		clientThread.Abort();
		writer.Close();
		reader.Close();
		tcpClient.Close();
		server.Disconnect(this);
	}

	public void MessageToClient(string message)
	{
		writer.WriteLine(message);
	}
	
	public void Run()
	{
		try
		{
			while (tcpClient.Connected)
			{
				string receiveMessage = reader.ReadLine();
				// 메세지가없거나 이상할때
				if (string.IsNullOrEmpty(receiveMessage))
					continue;

				try
				{
					ClickEvent clickEvent = JsonConverter.Deserialize<ClickEvent>(receiveMessage);
					clickEvent.userId = id;
					server.BroadcastToClients($"{clickEvent.userId}가 클릭한 위치 x : {clickEvent.x}, y : {clickEvent.y}");
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					throw;
				}
				// 유효한 메세지를 전송받음
			
				// server.BroadcastToClients($"{id} 가 클릭한 위치 : {receiveMessage}");
			}
		}
		finally
		{
			Server.log.Enqueue($"{id}번 클라이언트 연결 종료됨.");
			// Disconnect();
		}
	}
}
