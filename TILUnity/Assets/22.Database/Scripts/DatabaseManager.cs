using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using MySqlConnector;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
	public string dbIp = "127.0.0.1";
	public int port = 3306;

	private string dbName = "game";
	private string tableName = "users";
	private string rootPasswd = "1q2w3e4r";
	private MySqlConnection connection; //mysql(mariadb) DB와 연결 상태를 유지하는 객체.
	
	public static DatabaseManager Instance { get; set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			DestroyImmediate(gameObject);
		}
	}
	
	private void Start()
	{
		DBConnect();
	}

	// db에 접속(연결)
	private async void DBConnect()
	{
		// db 접속 설정
		string config = $"server={dbIp};port={port};database={dbName};" +
		               $"uid=root;pwd={rootPasswd};charset=utf8";

		connection = new MySqlConnection(config); 
		print($"mysql 접속 시작. state : {connection.State}");
		await connection.OpenAsync();
		print($"mysql 접속 성공. state : {connection.State}");
	}

	public async void SignUp(string email, string userName, string passwd)
	{
		// 비밀번호를 해쉬 키로 변경할 stringbuilder 객체 생성
		StringBuilder pwHash = new StringBuilder();
		// sha256 해쉬 알고리즘을 사용해 비밀번호를 해쉬키로 변경
		using (SHA256 sha256 = SHA256.Create())
		{
			byte[] hashArray = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwd));
			foreach (byte b in hashArray)
			{
				pwHash.Append($"{b:X2}");
				// pwHash.Append(b.ToString("X2"));
				
			}
		}


		using (MySqlCommand cmd = new MySqlCommand())
		{
			cmd.Connection = connection;
			cmd.CommandText = $"INSERT INTO {tableName} VALUES ('{email}', '{pwHash}', '{userName}', '초보자', 1);";
			int rowsAffected = 0;
			try
			{
				// 쿼리를 실행
				rowsAffected = await cmd.ExecuteNonQueryAsync();
			}
			finally
			{
				if (rowsAffected > 0) // 회원가입 완료
				{
					UIManager.Instance.PageOpen("Popup");
					UIManager.Instance.popup.PopupOpen("알림", "회원가입에 성공했습니다.", 
						() => UIManager.Instance.PageOpen("LogIn"));
				}
				else // 회원가입 실패
				{
					UIManager.Instance.PageOpen("Popup");
					UIManager.Instance.popup.PopupOpen("알림", "회원가입에 실패했습니다.", 
						() => UIManager.Instance.PageOpen("LogIn"));
				}
			}
		}

	}

	public async void Login(string email, string passwd)
	{
		// 비밀번호를 해쉬 키로 변경할 stringbuilder 객체 생성
		StringBuilder pwHash = new StringBuilder();
		// sha256 해쉬 알고리즘을 사용해 비밀번호를 해쉬키로 변경
		using (SHA256 sha256 = SHA256.Create())
		{
			byte[] hashArray = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwd));
			foreach (byte b in hashArray)
			{
				pwHash.Append($"{b:X2}");
				// pwHash.Append(b.ToString("X2"));
				
			}
		}
		
		using (MySqlCommand cmd = new MySqlCommand())
		{
			cmd.Connection = connection;
			cmd.CommandText = $"SELECT email, username, class, level FROM {tableName} WHERE email='{email}' AND pw='{pwHash}'";

			try
			{
				using (MySqlDataReader reader = await cmd.ExecuteReaderAsync())
				{
					if (reader.Read()) // 로그인 성공
					{
						print($"로그인 성공, 이메일 : {reader["email"]}, 이름 : {reader["username"]}, 직업 : {reader[2]}, 레벨 : {reader["level"]}");
						UserData userData = new UserData(
							reader[0].ToString(), 
							reader[1].ToString(), 
							reader[2].ToString(), 
							int.Parse(reader[3].ToString()));
						
						UIManager.Instance.PageOpen("UserInfo");
						UIManager.Instance.userInfo.UserInfoOpen(userData);
					}
					else // 로그인 실패
					{
						print("로그인 실패");
						UIManager.Instance.PageOpen("Popup");
						UIManager.Instance.popup.PopupOpen("알림", "로그인에 실패했습니다.", 
							() => UIManager.Instance.PageOpen("LogIn"));
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}

	public async void Levelup(string email)
	{
		using (MySqlCommand cmd = new MySqlCommand())
		{
			cmd.Connection = connection;
			cmd.CommandText = $"SELECT level FROM {tableName} WHERE email='{email}'";
			using (MySqlDataReader reader = await cmd.ExecuteReaderAsync())
			{
				
				if (reader.Read())
				{
					int level = int.Parse(reader["level"].ToString());
					level++;	
					reader.Close();
					cmd.CommandText = $"UPDATE {tableName} SET level={level} WHERE email='{email}'";
					await cmd.ExecuteNonQueryAsync();

					UIManager.Instance.userInfo.currentLevel = level;
					UIManager.Instance.userInfo.level.text = $"Lv.{level}";
				}
			}
		}
	}
}
