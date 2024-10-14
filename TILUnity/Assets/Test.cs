using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("¾Æ¤»¤»");
	}

    // Update is called once per frame
    void Update()
    {
        i++;
        if (i % 2 == 0)
            Debug.Log(i);
        else
            Debug.LogError(i);
	}

    private int i;
}
