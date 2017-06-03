using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCutOff : MonoBehaviour {

	public Renderer planeRenderer;
	public static float cutOffValue;

	void Start () {
		planeRenderer = GetComponent<Renderer>();
	}
	
	void Update () {
		planeRenderer.material.SetFloat("_Cutoff", cutOffValue);
	}
}
