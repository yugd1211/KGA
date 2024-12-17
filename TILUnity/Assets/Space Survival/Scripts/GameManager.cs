using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �⺻���� ��ü������ ���� �̱��� ��ü�� ����� ���
// ���� ��ü ������ �Ѱ��ϴ� ������Ʈ
public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	public static GameManager Instance => instance;
	private GameManager() {/* �����ڸ� private�� �����Ͽ� �ܺο��� ������ ���´�. */}

	internal List<Enemy> enemies = new List<Enemy>();
	internal Player player;

	// ����Ƽ���� �̱��� ������ �����ϴ� ���
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
