using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUIInteraction : MonoBehaviour
{
	// Button 컴포넌트의 OnClick() 이벤트에 할당하여 해당 버튼이 클릭 될 때마다 호출 되도록
	// 유니티 엔진이 Inspector에 할당된 대로 의존성을 주입해준다.
	// 함수의 접근지정자가 public 이어야 참조가능하다.
	public void ButtonClick()
	{
		print("버튼 클릭");
	}

	public void ButtonClickWithParam(string param)
	{
		print($"버튼 클릭: {param}");
	}

	public void ButtonClicWithFloatParam(float param)
	{
		print($"버튼 클릭 float: {param}");
	}
}
