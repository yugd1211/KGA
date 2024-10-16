using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionVariableTest : MonoBehaviour
{

    public string[] stringArray;
    public List<string> stringList;
    public LinkedList<string> stringLList;
    public Queue<string> stringQueue;
	public Stack<string> stringStack;
    public Dictionary<string, string> stringDictionary;

	void Start()
    {
        //stringArray = new string[3];

        foreach (string item in stringArray)
		{
			Debug.Log(item);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
