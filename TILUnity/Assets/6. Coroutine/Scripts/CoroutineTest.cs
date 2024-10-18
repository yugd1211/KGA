using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    private MeshRenderer mr;
	private Material stoneMaterial;

    public Material material;
	public Material redMaterial;
	public Transform transformTest;
	private Coroutine materialCoroutine;

	void Start()
	{
		////List<int> intList = new List<int>() { 1, 2, 3 };
		////foreach(int somInt in intList)
		////{
		////	print(somInt);
		////}
		//foreach (Transform someTransform in transformTest)
		//{
		//	print(someTransform.name);
		//}
		mr = GetComponent<MeshRenderer>();
		stoneMaterial = mr.material;
		materialCoroutine = StartCoroutine(MaterialChange(redMaterial, 2.0f));
	}

	// Update is called once per frame
	void Update()
    {
		//if (Time.time > 3.0f)
		//{
		//          mr.material = material;
		//    //3�� �Ŀ� MeshRenderer�� Material�� ����
		//	//StartCoroutine(ChangeMaterial());
		//}

        if (Input.GetButtonDown("Jump")) 
        {
			mr.material = stoneMaterial;
        }

		if (Input.GetKeyDown(KeyCode.I))
		{
			print("�ڷ�ƾ ��ž");
			StopCoroutine(materialCoroutine);
		}
	}

	private IEnumerator StringEnumerator()
	{
		yield return "a";
		yield return "b";
		yield return "materialCoroutine";
	}

	private IEnumerator MaterialChange(Material mat, float interval)
    {
		while (true)
		{
			yield return new WaitForSeconds(interval);
			mr.material = mat;
		}
	}

}
