using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineStarter : MonoBehaviour
{
	public CoroutineTarget target;

	private void Start()
	{
		// �ڷ�ƾ�� ��ü�� �߿��ϴ�.
		// �ڷ�ƾ�� �����ϴ� ��ü�� ��Ȱ��ȭ, �ı��ɽ� �ڷ�ƾ�� �����ȴ�.

		// StartCoroutine ȣ��� �ڷ�ƾ�� �ڵ鸵�ϴ� ��ü�� �� �ڽ��� �ǹǷ�
		// �� ���� ������Ʈ�� ��Ȱ��ȭ �ǰų� Component�� ��Ȱ��ȭ �Ǹ� �ڽ��� StartCoroutine�� ���� ������ ��� �ڷ�ƾ�� ������ ����

		target.StartCoroutine(DamageOnTime());
		//StartCoroutine(DamageOnTime());
	}

	private IEnumerator DamageOnTime()
	{
		print($"{name}�� {target.name}���� �ߵ��� �������ϴ�.");

		for (int i = 0; i < 10; i++)
		{
			yield return new WaitForSeconds(1.0f);
			print($"{target.name} : �������� �޾ҽ��ϴ�. x {i}");
		}
	}
}
