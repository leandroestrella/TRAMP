using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScripts : MonoBehaviour
{
	void Start ()
	{
		GetComponent<LookSky> ().enabled = true;
	}
}
