using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolO : MonoBehaviour {
	
	// static means that the object will exist kind of forever
	public static int numObjects = GenerateTerrain.objectsToCreate;	// how many objects to create
	public GameObject objectPrefab;
	static GameObject[] objects;		// array of objects

	void Start () {

		objects = new GameObject[numObjects];	// set array for number of objects
		for(int i = 0; i < numObjects; i++)		// create specified number of objects
		{
			objects[i] = (GameObject) Instantiate(objectPrefab, Vector3.zero, Quaternion.identity);
			objects[i].SetActive(false);	// they are created but invisible
		}

	}

	static public GameObject getObject()
	{
		for(int i = 0; i < numObjects; i++)
		{
			if(!objects[i].activeSelf)
			{
				return objects[i];
			}
		}
		return null;
	}
}
