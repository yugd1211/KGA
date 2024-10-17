using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LerpSmooth : MonoBehaviour
{
    public Transform followTarget;
    public float moveSpeed;
    void Start()
    {
        transform.position = Vector3.Lerp(transform.position, followTarget.position, Time.deltaTime * moveSpeed);

        Mathf.InverseLerp(0, 0, 0); // Lerp�� �Ű������� �ݴ�� a -> b�� �����ϴ°� �ƴ�, b -> a�� ����

        // Mathf.Ceil, Floor, Round : �ø�, ����, �ݿø�

        float value = 5.5f;
        float ceil = Mathf.Ceil(value); // 6
		float floor = Mathf.Floor(value); // 5
		float round = Mathf.Round(value); // 6
        //print($"ceil : {ceil}, floor : {floor}, round : {round}");
        //Mathf.Sign(); // ��ȣ ��ȯ �Լ�(plus, minus)
        //Mathf.Sin(); // ���� �Լ� ()
        //Mathf.Pow(); �����Լ�
        //Mathf.Sqrt(); ������ �Լ�
        //Mathf.Deg2Rad : ������ �������� ��ȯ
        //print(Mathf.Sin(45));
		//Mathf.Deg2Rad = 0.0174532924f;

		// Random : ���� ���� Ŭ����

        // int�� ��ȯ�ϴ� Range �Լ��� �ִ밪�� �����ϰ� ��ȯ
        int intRandom = Random.Range(0, 10);

        // float�� ��ȯ�ϴ� Range �Լ��� �ִ밪�� ���ٰ� ���ֵǴ� ���� ��ȯ �� ���� ����
        float floatRandom = Random.Range(-1f, 1f);

        float randomValue = Random.value; // == Random.Range(0f, 1f); ����� Ȯ���� ���ϰ� ����� ������

        Vector3 randomPosition = Random.insideUnitSphere; // �������� 1�� �� �ȿ� ������ ��ġ�� ��ȯ
        // Vector3(-1~1, -1~1, -1~1);
        //Vector3 randomPosition = Random.insideUnitSphere *5;
		// Vector3(-5~5, -5~5, -5~5);

        Vector3 randomDirection = Random.onUnitSphere; // ������ Vector3 ������ ���̰� �׻� 1�� ���͸� ��ȯ
                                                       // ������ "����"�� ��ȯ�ް� ������ ȿ����
                                                       // ������ ���� ���� = ������ ���� ����

        print(Mathf.Sqrt(Mathf.Pow(randomDirection.x, 2) + Mathf.Pow(randomDirection.y, 2) + Mathf.Pow(randomDirection.z, 2)));
        Vector2 randomPosition2D = Random.insideUnitCircle;
        // 2D�� Random Vector


        Random.InitState(12345); // ���� �õ尪�� �����Ͽ� ������ ������ ������ �� ����
        // ���� ���ϰ� ���� �ɸ��� �Լ��̹Ƿ�, ���������� ���(�� �ε� �ʱ⶧�뿡��) ����Ұ�

	}

	//Gizmo : Sceneâ������ �� �� �ִ� "�����"�� �׸��� Ŭ����(Debug.DrawXX�� Ȯ����ó�� ���)
	//

	private void Update()
	{
		//Gizmos.DrawCube(Vector3.zero, Vector3.one); // < Update���� ������
	}

	// OnDrawGizmos, OnDrawGizmosSelected, OnSceneGUI�� �Լ������� Gizmo�� �׸� �� ����
    // Sceneâ�� �����Ϳ����� Ȱ��ȭ �Ǵ� �޽��� �Լ������� ��ȿ�ϰ� �����
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
        Gizmos.DrawCube(Vector3.right, Vector3.one);
		Gizmos.color = Color.red;
        Gizmos.DrawSphere(Vector3.left * 3, Mathf.PI);
	}


    // �ش� ��ü�� ����(�ν�����â����) �������� ����� �׸�
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(Vector3.up, 0.5f);
	}
}
