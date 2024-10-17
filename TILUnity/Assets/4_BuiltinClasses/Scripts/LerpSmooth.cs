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

        Mathf.InverseLerp(0, 0, 0); // Lerp의 매개변수가 반대로 a -> b로 수렴하는게 아닌, b -> a로 수렴

        // Mathf.Ceil, Floor, Round : 올림, 내림, 반올림

        float value = 5.5f;
        float ceil = Mathf.Ceil(value); // 6
		float floor = Mathf.Floor(value); // 5
		float round = Mathf.Round(value); // 6
        //print($"ceil : {ceil}, floor : {floor}, round : {round}");
        //Mathf.Sign(); // 부호 반환 함수(plus, minus)
        //Mathf.Sin(); // 사인 함수 ()
        //Mathf.Pow(); 제곱함수
        //Mathf.Sqrt(); 제곱근 함수
        //Mathf.Deg2Rad : 각도를 라디안으로 변환
        //print(Mathf.Sin(45));
		//Mathf.Deg2Rad = 0.0174532924f;

		// Random : 난수 생성 클래스

        // int를 반환하는 Range 함수는 최대값은 제외하고 반환
        int intRandom = Random.Range(0, 10);

        // float을 반환하는 Range 함수는 최대값과 같다고 간주되는 값이 반환 될 수도 있음
        float floatRandom = Random.Range(-1f, 1f);

        float randomValue = Random.value; // == Random.Range(0f, 1f); 백분율 확률을 편하게 사용할 수있음

        Vector3 randomPosition = Random.insideUnitSphere; // 반지름이 1인 구 안에 랜덤한 위치를 반환
        // Vector3(-1~1, -1~1, -1~1);
        //Vector3 randomPosition = Random.insideUnitSphere *5;
		// Vector3(-5~5, -5~5, -5~5);

        Vector3 randomDirection = Random.onUnitSphere; // 랜덤한 Vector3 이지만 길이가 항상 1인 벡터를 반환
                                                       // 랜덤한 "방향"을 반환받고 싶을때 효율적
                                                       // 랜덤한 단위 벡터 = 랜덤한 방향 벡터

        print(Mathf.Sqrt(Mathf.Pow(randomDirection.x, 2) + Mathf.Pow(randomDirection.y, 2) + Mathf.Pow(randomDirection.z, 2)));
        Vector2 randomPosition2D = Random.insideUnitCircle;
        // 2D용 Random Vector


        Random.InitState(12345); // 난수 시드값을 설정하여 동일한 난수를 생성할 수 있음
        // 연산 부하가 많이 걸리는 함수이므로, 제한적으로 사용(씬 로딩 초기때쯤에나) 사용할것

	}

	//Gizmo : Scene창에서만 복 수 있는 "기즈모"를 그리는 클래스(Debug.DrawXX의 확장기능처럼 사용)
	//

	private void Update()
	{
		//Gizmos.DrawCube(Vector3.zero, Vector3.one); // < Update에서 사용못함
	}

	// OnDrawGizmos, OnDrawGizmosSelected, OnSceneGUI등 함수에서만 Gizmo를 그릴 수 있음
    // Scene창과 에디터에서만 활성화 되는 메시지 함수에서만 유효하게 기능함
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
        Gizmos.DrawCube(Vector3.right, Vector3.one);
		Gizmos.color = Color.red;
        Gizmos.DrawSphere(Vector3.left * 3, Mathf.PI);
	}


    // 해당 객체를 선택(인스펙터창에서) 했을때만 기즈모를 그림
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(Vector3.up, 0.5f);
	}
}
