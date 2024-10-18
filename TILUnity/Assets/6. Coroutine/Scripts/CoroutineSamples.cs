using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSamples : MonoBehaviour
{
	private void Start()
	{
		//StartCoroutine(ReturnNull());
		//StartCoroutine(ReturnWaitForSeconds(1.0f, 5));
		//StartCoroutine(ReturnWaitForSecondsRealtime(1.0f, 5));
		//StartCoroutine(ReturnUntilAndWhile());
		//StartCoroutine(ReturnFrames());
		StartCoroutine(_1st());
	}

	// yield return null : �� �����Ӹ��� ���� yield return�� ��ȯ
	private IEnumerator ReturnNull()
    {
        print("Return Null Coroutine Start");
        while (true)
        {
		    yield return null;
            print($"Return null Coroutine~~~~~~~~~~~~~~~~~~~~~ {Time.time}");
        }
	}

	// yield return new WaitForSeconds(�Ķ����) : �ڷ�ƾ�� yield return�� ������ �Ķ���͸�ŭ ��� �� ����
	private IEnumerator ReturnWaitForSeconds(float interval, int count)
	{
		print("Return WaitForSeconds Coroutine Start");
		for (int i = 0; i < count; i++)
		{
			yield return new WaitForSeconds(interval);
			print($"Return WaitForSeconds Coroutine~~~~~~~~~~~~~~~~~~~~~ {Time.time}");
		}
		print("Return WaitForSeconds Coroutine End");
	}


	// yield return new WaitForSecondsRealtime(�Ķ����) : ���� �ð��� �������� ���
	// WaitForSeconds�� ������ ������ TimeScale�� ���� ���� �ʴ´�.
	//WaitForSeconds�� Time.TimeScale�� ������ �޴´�.
	private IEnumerator ReturnWaitForSecondsRealtime(float interval, int count)
	{
		print("Return WaitForSecondsRealtime Coroutine Start");
		for (int i = 0; i < count; i++)
		{
			yield return new WaitForSecondsRealtime(interval);
			print($"Return WaitForSecondsRealtime Coroutine~~~~~~~~~~~~~~~~~~~~~ {Time.time}");
		}
		print("Return WaitForSecondsRealtime Coroutine End");
	}

	public bool continueKey;
	private bool IsContinue()
	{
		return continueKey;
	}

	// yield return new WaitUntil / WaitWhile(param) : Ư�� ������ True/False�� �ɶ����� ���
	private IEnumerator ReturnUntilAndWhile()
	{
		print("Return Until Wihle �ڷ�ƾ ����");
		while (true)
		{
			//yield return new WaitUntil(IsContinue);
			// new WaitUntil : �Ű������� �Ѿ �Լ�(�븮��)�� return�� false�� ���� ���, true�� �Ѿ(�����Ӹ��� Ȯ��)
			yield return new WaitUntil(() => continueKey);
			print("��Ƽ�� Ű�� ����");

			// new WaitWhile : �Ű������� �Ѿ �Լ�(�븮��)�� return�� true�� ���� ���, false�� �Ѿ
			yield return new WaitWhile(() => continueKey);
			print("��Ƽ�� Ű�� ������");
		}
	}


	// yield return new (Frame �迭) : �� ������ Ư�� ������ �ڿ� �����
	private IEnumerator ReturnFrames()
	{
		// EndOfFrame : ��� �������� ���� ��(������)���� ��ٸ� (LateUpdate���� �ʰ� ȣ��)
		yield return new WaitForEndOfFrame();
		print("EndOfFrame");
		isFirstFrame = false;
	}

	private IEnumerator ReturnFixedUpdate()
	{
		// FixedUpdate : ���������� ���� ������ ��ٸ�
		yield return new WaitForFixedUpdate();
	}

	bool isFirstFrame = true;
	
	private void Update()
	{
		if (isFirstFrame)
		{
			//print("Update �޽��� �Լ� ȣ��");
		}
	}

	private void LateUpdate()
	{
		if (isFirstFrame)
		{
			//print("LateUpdate �޽��� �Լ� ȣ��");
		}
	}


	//yield return �ڷ�ƾ : �ش� �ڷ�ƾ�� ���������� ���
	private IEnumerator _1st()
	{
		print("1��° �ڷ�ƾ start");
		for(int i = 0; i < 5; i++)
		{
			yield return new WaitForSeconds(1.0f);
			print($"1��° �ڷ�ƾ {i + 1}��° ������");
		}
		// �ڷ�ƾ������ ���������� �����
		print("1��° �ڷ�ƾ 2��° �ڷ�ƾ �����ϰ� ���");
		yield return StartCoroutine(_2nd());
		print("1��° �ڷ�ƾ end");
	}

	Coroutine _3rdCoroutine;

	private IEnumerator _2nd()
	{
		print("2��° �ڷ�ƾ start");
		print("2�� �ڷ�ƾ�� 3��° �ڷ�ƾ �����ϰ� ���");
		_3rdCoroutine =  StartCoroutine(_3rd());
		yield return _3rdCoroutine; 
		for (int i = 0; i <5; i++)
		{
			print($"2��° �ڷ�ƾ{i + 1}��° ������");
			yield return new WaitForSeconds(1.0f);
		}
		print("2��° �ڷ�ƾ end");
	}
	private IEnumerator _3rd() 
	{
		print("3��° �ڷ�ƾ start");
		for (int i = 0; i <5; i++)
		{
			print($"3��° �ڷ�ƾ {i + 1}��° ������");
			yield return new WaitForSeconds(1.0f);
		}
		print("3��° �ڷ�ƾ end");
	}

}