using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiteralVariableTest : MonoBehaviour
{
    public GameObject testObject;

    public Transform cubeTransform;
    public MeshRenderer cubeMeshRenderer;
    public MeshFilter cubeMeshFilter;
    public BoxCollider cubeBoxCollider;
    public BoxCollider cubeBoxCollider2;

    public object systemObject; // c# system.object

    public Object unityObject; // Unity UnityEngine.Object
	private void Start()
    {
        Debug.Log($"Test Object value : {testObject}");

        Debug.Log($"BoxCollider 1 {cubeBoxCollider.size}");
        Debug.Log($"BoxCollider 2 {cubeBoxCollider2.size}");
	}

	// Update is called once per frame
	private void Update()
    {
        
    }
}
