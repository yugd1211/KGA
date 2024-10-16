using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityStructTest : MonoBehaviour
{

    // 유니티 내장 구조체 : 유니티가 생성한 게임 공간 상에서 빈번하게 쓰이는 데이터 구조체
    // 1. Vector2 : 2차원 벡터

    public Vector2 vector2;

	// 2. Vector3 : 3차원 벡터
	public Vector3 vector3;

	// 3. Vector4 : 4차원 벡터
	public Vector4 vector4;

	// 4. Quaternion : 쿼터니언 4원수, 3차원 축의 값과 1개의 허수부를 이용하여 3차원 공간에서 각도 변경 값이 겹치는 "짐벌락" 현상을 방지하기 위해 Rotation 값으로 사용
	public Quaternion quaternion;

	// 5. Vector2Int : 2차원 정수 벡터
	public Vector2Int v2Int;

	// 6. Vector3Int : 3차원 정수 벡터
	public Vector3Int V3Int;

	// 7. Color : 색상을 나타내는 구조체
	public Color color;


	// Start is called before the first frame update
	void Start()
    {
        print(transform.position);
        // 해당 rotation값은 vector3(인스펙터 창에 보이는)값에 오일러각을 적용하여 나온 값이다.
		print(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
