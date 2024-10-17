using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class BuiltinClassesTest : MonoBehaviour
{
    // ����Ƽ �������� �����ϴ� ���̺귯�� ����� Ŭ������ Ȱ��

    // Debug : ����뿡 ���Ǵ� ����� �����ϴ� Ŭ����
    // Mathf : ����Ƽ���� �����ϴ� �پ��� ���� ���� �Լ��� ���Ե� Ŭ����

    public void Start()
    {
        Debug.DrawRay(transform.position, Vector3.up * 3, Color.red, 5f);

        float a = -0.3f;
        a = Mathf.Abs(a);
        print(a);
        //Mathf.Approximately(); // �ٻ簪 �� �Լ�(�Ǽ��� �ڷ����� �ε��Ҽ������� �����ϱ� ������ ��Ȯ�� ���� �������� �ʴ´�. ������ �ٻ簪 �񱳷� �Ѵ�.)
        //Mathf.Lerp(a, b, t) : ���� ���� (Linear Interpolation) :
        // a ���� b������ t�� ������ŭ�� ��ġ�ϴ� ��(0 < t < 1)

        print(Mathf.Lerp(-1f, 1f, 0.5f)); // 0

		// Lerp(���� ����) �Լ��� Color, Vector(2, 3, 4), Material, Transform �� �پ��� Ÿ�Կ� ��� ����
	}

	public void Update()
    {
	}
}
