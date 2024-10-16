using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;


// �� Ŭ������ ���� �ٸ� ��������� �����ϱ� ���ؼ��� "����ȭ" ������ �ʿ��ϴ�.]
//[] C# Attribute : Ư�� ���(Ŭ����, ����, �Լ�)�� ���� ��Ÿ�����͸� ����
[Serializable]
public class MyClass
{
    // ��ü�� ����ȭ�ϰ�, �̸� List�� ����������, ù��° ��������� string�̶��, �ش� ����� ���� �ش� string���� ���δ�.
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
