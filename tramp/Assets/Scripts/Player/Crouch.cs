using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
	CharacterController characterController;

	void Awake ()
	{
		characterController = gameObject.GetComponent<CharacterController> ();
	}

	void Update ()
	{
		if (Input.GetKey (KeyCode.C)) {
			characterController.height = 0f;
		} else {
			characterController.height = 1.8f;
		}
	}
}
