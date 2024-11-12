using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyProject
{
	public class EventTriggerTest : MonoBehaviour
	{
		public void OnClick()
		{
			Debug.Log("OnClick");
		}

		public void OnEnter()
		{
			Debug.Log("OnEnter");
		}

		public void OnExit()
		{
			Debug.Log("OnExit");
		}

		public void OnAnyEvent(BaseEventData eventData)
		{
			print($"some event called, {eventData.GetType()}");
			print($"some event called, {(eventData as PointerEventData).position}");
		}
	}
}
