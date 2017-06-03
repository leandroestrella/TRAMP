using UnityEngine;
using System.Collections;

public class globalFlock : MonoBehaviour {

	public GameObject fishPrefab;
	//public GameObject goalPrefab;
	public static int tankSize = 1;

	static int numFish = 7;
	public static GameObject[] allFish = new GameObject[numFish];

	public static Vector3 goalPos = Vector3.one;

	void Start () 
	{
		for(int i = 0; i < numFish; i++)
		{
			Vector3 pos = new Vector3(Random.Range(-tankSize,tankSize),
				                      Random.Range(-tankSize,tankSize),
				                      Random.Range(-tankSize,tankSize));
			allFish[i] = (GameObject) Instantiate(fishPrefab, pos, Quaternion.identity);
		}
	}

	void Update ()
	{
		/*if (Random.Range (0, 10000) < 50) {
			goalPos = new Vector3 (Random.Range (-tankSize, tankSize),
								   Random.Range (-tankSize, tankSize),
								   Random.Range (-tankSize, tankSize));
			//goalPrefab.transform.position = goalPos;
		}*/
    }
}
