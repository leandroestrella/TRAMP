using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGround : MonoBehaviour {
	
	public Material occlusionMaterial;
	public Material groundMaterial;
	public static bool occlusionGround;
	public Renderer groundRenderer;

	void Awake () {
		occlusionGround = false;
		groundRenderer = GetComponent<Renderer> ();
	}

	void Update () {
		if (occlusionGround){
			groundRenderer.material = occlusionMaterial;
		} else {
			groundRenderer.material = groundMaterial;
			groundRenderer.material.SetFloat("_Cutoff", MaterialCutOff.cutOffValue);
		}
	}
}