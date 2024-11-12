using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyProject
{
	[Serializable]
	public class ShapeData
	{
		public enum Shape
		{
			Cube,
			Sphere,
			Capsule,
		}
		public Shape shape;
		public float scale;
		public Color color;
	}

	public class PhysicsRayCasterTest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
	{
		public ShapeData shapeData;

		public void OnPointerEnter(PointerEventData eventData)
		{
			EventSystemTestManager.Instance.ShowTooltip(shapeData);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			EventSystemTestManager.Instance.HideTooltip();
		}

		public void OnPointerMove(PointerEventData eventData)
		{
			//EventSystemTestManager.Instance.tooltip.GetComponent<RectTransform>().anchoredPosition += (Vector3)eventData.delta;
			EventSystemTestManager.Instance.tooltip.GetComponent<RectTransform>().anchoredPosition = eventData.position;
			// screen의 왼쪽 아래 끝이 (0, 0)인 좌표 기준으로 마우스 포인터의 위치를 나타냄

		}

		public void Start()
		{
			GetComponentInParent<Renderer>().material.color = shapeData.color;
			transform.parent.localScale = shapeData.scale * Vector3.one;
		}
	}
}
