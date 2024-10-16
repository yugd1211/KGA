using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityStructTest : MonoBehaviour
{

    // ����Ƽ ���� ����ü : ����Ƽ�� ������ ���� ���� �󿡼� ����ϰ� ���̴� ������ ����ü
    // 1. Vector2 : 2���� ����

    public Vector2 vector2;

	// 2. Vector3 : 3���� ����
	public Vector3 vector3;

	// 3. Vector4 : 4���� ����
	public Vector4 vector4;

	// 4. Quaternion : ���ʹϾ� 4����, 3���� ���� ���� 1���� ����θ� �̿��Ͽ� 3���� �������� ���� ���� ���� ��ġ�� "������" ������ �����ϱ� ���� Rotation ������ ���
	public Quaternion quaternion;

	// 5. Vector2Int : 2���� ���� ����
	public Vector2Int v2Int;

	// 6. Vector3Int : 3���� ���� ����
	public Vector3Int V3Int;

	// 7. Color : ������ ��Ÿ���� ����ü
	public Color color;


	// Start is called before the first frame update
	void Start()
    {
        print(transform.position);
        // �ش� rotation���� vector3(�ν����� â�� ���̴�)���� ���Ϸ����� �����Ͽ� ���� ���̴�.
		print(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
