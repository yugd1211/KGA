using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 함수를 호출 하고난 결과 어떤 다른 함수가 호출되야 할때, 이를 콜백함수라고 한다.
public class Callback : MonoBehaviour
{
	// 일반적으로 특정 함수 수행 후에 다른 함수가 호출되길 원할 때, 그 함수를 c# : delegate 대리자 형태로 넘겨준다.
	// js : 함수
	// c++ : 함수포인터

	public GameObject destroyTarget;
	public CallbackTestPopup popup;
	
	public void OnDestroyButtonClick()
	{
		// popup.ShowPopup((yes) => {
		// 	if (yes)
		// 		Destroy(destroyTarget);
		// 	else
		// 		print("destroy cancel");
		// });
		popup.ShowPopup(OnYes);
	}
	
	public void OnYes(bool yes)
	{
		if (yes)
			Destroy(destroyTarget);
		else
			print("destroy cancel");
	}
	
}
