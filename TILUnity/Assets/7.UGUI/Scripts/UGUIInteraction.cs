using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUIInteraction : MonoBehaviour
{
	// Button ������Ʈ�� OnClick() �̺�Ʈ�� �Ҵ��Ͽ� �ش� ��ư�� Ŭ�� �� ������ ȣ�� �ǵ���
	// ����Ƽ ������ Inspector�� �Ҵ�� ��� �������� �������ش�.
	// �Լ��� ���������ڰ� public �̾�� ���������ϴ�.
	public void ButtonClick()
	{
		print("��ư Ŭ��");
	}

	public void ButtonClickWithParam(string param)
	{
		print($"��ư Ŭ��: {param}");
	}

	public void ButtonClicWithFloatParam(float param)
	{
		print($"��ư Ŭ�� float: {param}");
	}
}
