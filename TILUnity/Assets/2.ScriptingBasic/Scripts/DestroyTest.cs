using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTest : MonoBehaviour
{
	public GameObject destroyTarget;
	public Component destroyComponentTarget;
	public GameObject destroyTargetWithDelay;
	public GameObject destroyTargetOnImmediately;


	// ��ü �����ϴ� ���
	private void Start()
	{
		// 1. GameObject�� Destroy�Ѵ�.
		Destroy(destroyTarget);
		// 2. Component�� ����� Object�� Destroy�Ѵ�.
		Destroy(destroyComponentTarget);
		// Destroy �Լ��� ȣ�� ���Ŀ��� �Ķ���ͷ� ������ ������Ʈ�� ������ ���� (��ü�� ���� �ı����� �ʴ´�)
		FindMe findMe = destroyComponentTarget as FindMe;
		print(findMe.message);
		// Destroy �Լ��� ������Ʈ�� ��� �ı��ϴ� ���� �ƴ� �ı� ����Ʈ�� �߰��ϰ�, ���� �����ӿ� �ı��Ѵ�.
		// ����, Destroy �Լ� ȣ�� ���Ŀ��� ������Ʈ�� ������ �����ϴ�.

		// 3. �׷��� ������, Destroy �Լ��� �����̸� ���� �ϴ� ���� �����ϴ�.
		Destroy(destroyTargetWithDelay, 3.0f);

		// 4. ���� ���� �������̶� Ư�� ��ü�� ��� �ı��Ǳ⸦ ���Ѵٸ� DestroyImmediate() �Լ��� ����Ѵ�.
		DestroyImmediate(destroyTargetOnImmediately);
		// �� �Լ��� ȣ��� ������ �ڵ���� ������ �ش� ��ü�� ������ �� ����.
		print(destroyTargetOnImmediately);


	}
}
