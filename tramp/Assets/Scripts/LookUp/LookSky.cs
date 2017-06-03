using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookSky : MonoBehaviour
{
	
	private GameObject firstPersonCharacter;
	private GameObject fpsController;
	private GameObject skyCamera;
	private GameObject target;

	private CharacterController characterController;

	private Camera camera1;
	private Camera camera2;
	private Camera camera3;

	private Quaternion RotationTar;
	private Quaternion originalRotation;
	private Vector3 relativePos;

	public float EjeY = 0.0f;
	public float EjeX = 0.0f;
	int Timer = 0;

	void Awake ()
	{
		firstPersonCharacter = GameObject.Find ("FPSController/FirstPersonCharacter");
		camera1 = firstPersonCharacter.GetComponent<Camera> ();
		firstPersonCharacter.GetComponent<AudioListener> ().enabled = true;

		fpsController = GameObject.Find ("FPSController");
		camera2 = fpsController.GetComponent<Camera> ();
		characterController = fpsController.GetComponent<CharacterController> ();

		skyCamera = GameObject.Find ("skyCamera");
		camera3 = skyCamera.GetComponent<Camera> ();
		camera3.GetComponent<AudioListener> ().enabled = false;

		target = GameObject.Find ("targetPreFab");
	}

	void Update ()
	{
		originalRotation = camera1.transform.rotation;
		relativePos = (target.transform.position - camera1.transform.position);	//calcula dirección para la rotación
		RotationTar = Quaternion.LookRotation (relativePos);
		RotationTar.y = 0f;	//rotación en eje Y
		EjeX = Input.GetAxis ("Mouse X");
		EjeY = Input.GetAxis ("Mouse Y");

		if (characterController.velocity.sqrMagnitude < 1f && LookActivateScript.StartEffect == false && EjeX == 0f && EjeY == 0f) {
			Timer++;	// start counting

			if (Timer >= 400) {
				fpsController.SetActive (false);
				camera1.gameObject.SetActive (false);
				firstPersonCharacter.SetActive (false);
				camera2.gameObject.SetActive (false);
				firstPersonCharacter.GetComponent<AudioListener> ().enabled = false;
				camera3.gameObject.SetActive (true);	// Desactiva las cámaras del FPS y activa la cámara auxiliar de rotación.
				camera3.GetComponent<AudioListener> ().enabled = true;

				if (camera3.fieldOfView < 179f) {
					camera3.fieldOfView = camera3.fieldOfView + 0.05f;
					//Debug.Log (camera3.fieldOfView);
				} else {
					camera3.fieldOfView = 179f;
				}
				transform.rotation = Quaternion.Slerp (transform.rotation, RotationTar, 0.05f * Time.deltaTime); // se ejecuta la rotacióon
			}
		}

		if (Input.anyKey || EjeX != 0f || EjeY != 0f) {
			Timer = 0;	// reset timer

			transform.rotation = originalRotation;
			fpsController.SetActive (true);
			camera1.gameObject.SetActive (true);

			firstPersonCharacter.SetActive (true);
			camera2.gameObject.SetActive (true);
			firstPersonCharacter.GetComponent<AudioListener> ().enabled = true;

			camera3.fieldOfView = 80f;
			// camera3.gameObject.SetActive (false);
			camera3.GetComponent<AudioListener> ().enabled = false;
		}

		if (characterController.velocity.sqrMagnitude > 1f) {
			Timer = 0;	// reset timer
			fpsController.SetActive (true);
			camera1.gameObject.SetActive (true);

			firstPersonCharacter.SetActive (true);
			camera2.gameObject.SetActive (true);
		}
	}
}