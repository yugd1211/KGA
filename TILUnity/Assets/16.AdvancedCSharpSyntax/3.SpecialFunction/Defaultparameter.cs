using System;
using UnityEngine;

public class Defaultparameter : MonoBehaviour
{
	// 기본 매개변수 : 매개변수에 전달할 값을 할당 안해도 기본적으로 특정 값이 전달 되도록 할 수 있음
	// 런타임이 아닌 컴파일타임에서 알 수 있는 값이여야 함(리터럴, 상수, enum 등)
	// [반환형] 함수이름 (타입 변수명 = 기본값){ }

	public Player newPlayer;
	private void Start()
	{
		GameObject go = CreateNewObject();
		// go.name = "New Obj";
		GameObject go2 = CreateNewObject("GameObject2");
		
		// Player player = CreatePlayer("Player1", 1, 10f,  Vector2.zero, go);
		newPlayer = CreatePlayer("경일", obj: gameObject);
	}

	// private GameObject CreateNewObject()
	// {
	// 	return new GameObject();
	// }
	
	private GameObject CreateNewObject(string name = "Some Object")
	{
		GameObject returnGameObject = new GameObject();
		returnGameObject.name = name;
		return returnGameObject;
	}

	// 팩토리 패턴
	private Player CreatePlayer(string name, int level = 1, float damage = 10f, Vector2 position = default, GameObject obj = null)
	{
		Player newPlayer = new Player();
		newPlayer.name = name;
		newPlayer.level = level;
		newPlayer.damage = damage;
		newPlayer.position = position;
		newPlayer.rendererObject = obj;
		return newPlayer;
	}
	
	// params 키워드 : 가변길이 매개변수

	private Player CreatePlayer(string name, params int[] items)
	{
		Player newPlayer = CreatePlayer(name);
		newPlayer.items = items;
		return newPlayer;
	}
	
	[Serializable]
	public class Player
	{
		public string name;
		public int level;
		public float damage;
		public Vector2 position;
		public GameObject rendererObject;
		public int[] items;
	}
}
