using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Element
{
	public string name;
	public Vector3 startPosition;
	public Vector3 startRotation;
	public Mesh mesh;
	public MeshRenderer meshRenderer;
	public Color color;
}

public class ElementTransformer : MonoBehaviour
{
    public MeshFilter[] meshs;
    public Renderer[] rends;
	public Element[] elements;


	private void Start()
    {
        for (int i = 0; i < elements.Length; i++)
		{
			if (rends.Length <= i)
				break;
			meshs[i].mesh = elements[i].mesh;
			rends[i].material.color = elements[i].color;
			rends[i].transform.position = elements[i].startPosition;
			rends[i].transform.rotation = Quaternion.Euler(elements[i].startRotation);
		}
	}

}
