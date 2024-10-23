using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;


// 기본적인 객체지향형 언어에서 싱글톤 객체를 만드는 방법
// 게임 전체 진행을 총괄하는 오브젝트
public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	public static GameManager Instance => instance;
	private GameManager() {/* 생성자를 private로 선언하여 외부에서 생성을 막는다. */}

	internal List<Enemy> enemies = new List<Enemy>();
	internal Player player;

	// 유니티에서 싱글톤 패턴을 적용하는 방법
	private void Awake()
	{
		if (instance != null)
		{
			DestroyImmediate(this);
			return;
		}
		instance = this;
		DontDestroyOnLoad(gameObject);
	}
}
