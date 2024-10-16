using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityAttributeTest : MonoBehaviour
{


    // 유니티에서 제공하는 어트리뷰트(Attribute)

    // 1. SerializeField : 일반적으로 인스펙터에서 가려져야 하는 private 또는 Protected 변수를 Inspecter에서 접근 가능하도록 하는 기능
    [SerializeField]
    private int privateIntvar;


	// 2. TextArea : Inspecter에서 문자열 입력란을 1줄이 아니라 여러 줄로 입력이 가능하도록 하는 기능
	[TextArea(2, 5)]
    public string text;


	//3. Header : Inspecter에서 변수들을 그룹화하여 보기 쉽도록 하는 기능
	[Header("헤더 테스트")]
	public int otherIntVar;

	// 4. Space : Inspecter에서 변수들 사이에 여백을 넣어주는 기능
	[Space(1)]
    public float floatVar;

	// 5. Range : Inspecter에서 int 혹은 float 변수의 값을 범위(최소, 최대)로 제한하고 이를 슬라이더로 지정할 수 있도록 하는 기능
	[Range(0, 100)]
	public int rangeVar;

	[Range(0, 100)]
	public float rangeVar2;

	// 6. Tooltip : Inspecter에서 변수에 마우스를 올려놓으면 해당 변수에 대한 설명을 볼 수 있도록 하는 기능
	[Tooltip("이것은 툴팁입니다.")]
	public string tooltipVar;

	//7. HideInInspector : Inspecter에서 해당 변수를 숨기는 기능
	[HideInInspector]
	public string hideVar;


	// internal 접근지정자 : 같은 어셈블리(네임스페이스) 내에서만 접근 가능한 접근지정자
	internal int internalVar;


	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
