using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;


// 이 클래스의 값을 다른 어셈블리에서 접근하기 위해서는 "직렬화" 과정이 필요하다.]
//[] C# Attribute : 특정 요소(클래스, 변수, 함수)에 대한 메타데이터를 정의
[Serializable]
public class MyClass
{
    // 객체를 직렬화하고, 이를 List에 저장했을떄, 첫번째 멤버변수가 string이라면, 해당 노드의 값이 해당 string으로 보인다.
    public string name;
    public int id;
    public Sprite sprite;
}


public class ReferenceVariableTest : MonoBehaviour
{
    public MyClass myClass;

    public List<MyClass> myClasses;
    void Start()
    {
        foreach (MyClass item in myClasses)
		{
			print($"{item.name} : {item.id}, {item.sprite}");
		}
	}

    void Update()
    {
        
    }
}
