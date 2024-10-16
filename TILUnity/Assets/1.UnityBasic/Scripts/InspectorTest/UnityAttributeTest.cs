using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityAttributeTest : MonoBehaviour
{


    // ����Ƽ���� �����ϴ� ��Ʈ����Ʈ(Attribute)

    // 1. SerializeField : �Ϲ������� �ν����Ϳ��� �������� �ϴ� private �Ǵ� Protected ������ Inspecter���� ���� �����ϵ��� �ϴ� ���
    [SerializeField]
    private int privateIntvar;


	// 2. TextArea : Inspecter���� ���ڿ� �Է¶��� 1���� �ƴ϶� ���� �ٷ� �Է��� �����ϵ��� �ϴ� ���
	[TextArea(2, 5)]
    public string text;


	//3. Header : Inspecter���� �������� �׷�ȭ�Ͽ� ���� ������ �ϴ� ���
	[Header("��� �׽�Ʈ")]
	public int otherIntVar;

	// 4. Space : Inspecter���� ������ ���̿� ������ �־��ִ� ���
	[Space(1)]
    public float floatVar;

	// 5. Range : Inspecter���� int Ȥ�� float ������ ���� ����(�ּ�, �ִ�)�� �����ϰ� �̸� �����̴��� ������ �� �ֵ��� �ϴ� ���
	[Range(0, 100)]
	public int rangeVar;

	[Range(0, 100)]
	public float rangeVar2;

	// 6. Tooltip : Inspecter���� ������ ���콺�� �÷������� �ش� ������ ���� ������ �� �� �ֵ��� �ϴ� ���
	[Tooltip("�̰��� �����Դϴ�.")]
	public string tooltipVar;

	//7. HideInInspector : Inspecter���� �ش� ������ ����� ���
	[HideInInspector]
	public string hideVar;


	// internal ���������� : ���� �����(���ӽ����̽�) �������� ���� ������ ����������
	internal int internalVar;


	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
