using UnityEngine;
using UnityEngine.UI;

public class AttributeControllerTest : MonoBehaviour
{
	[Color(0,1,0,1), Size(2)]
	public Renderer rend;
	[SerializeField, Color(r:1, b:0.5f), Size(4)]
	public Graphic graphic; //UI Image는 Graphic을 상속받음
	[Color]
	public float notRendererOrGraphic;
}