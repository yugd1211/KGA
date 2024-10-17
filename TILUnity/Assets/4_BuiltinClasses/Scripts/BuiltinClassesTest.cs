using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class BuiltinClassesTest : MonoBehaviour
{
    // 유니티 엔진에서 제공하는 라이브러에 내장된 클래스를 활용

    // Debug : 디버깅에 사용되는 기능을 제공하는 클래스
    // Mathf : 유니티에서 제공하는 다양한 수학 연산 함수가 포함된 클래스

    public void Start()
    {
        Debug.DrawRay(transform.position, Vector3.up * 3, Color.red, 5f);

        float a = -0.3f;
        a = Mathf.Abs(a);
        print(a);
        //Mathf.Approximately(); // 근사값 비교 함수(실수형 자료형은 부동소수점으로 저장하기 때문에 정확한 값을 저장하지 않는다. 때문에 근사값 비교로 한다.)
        //Mathf.Lerp(a, b, t) : 선형 보간 (Linear Interpolation) :
        // a 값과 b사이의 t의 비율만큼에 위치하는 값(0 < t < 1)

        print(Mathf.Lerp(-1f, 1f, 0.5f)); // 0

		// Lerp(선형 보간) 함수는 Color, Vector(2, 3, 4), Material, Transform 등 다양한 타입에 사용 가능
	}

	public void Update()
    {
	}
}
