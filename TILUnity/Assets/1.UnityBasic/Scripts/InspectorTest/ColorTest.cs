using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTest : MonoBehaviour
{
    // Start is called before the first frame update

    public Color targetColor;

    public Renderer targetRenderer;

    private void Update()
    {
        targetRenderer.material.color = targetColor;
	}

}
