using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMassGravity : MonoBehaviour {

	public Rigidbody rb;
	
	void Awake () {
		rb = GetComponent<Rigidbody> ();
		rb.mass = Random.Range (1, 10);
		rb.isKinematic = (Random.value > 0.5f);
	}
}
