using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour {

	GameObject player;	// to get FPS character
	private GameObject playerCamera;	// to get FPS character
	float playerPositionX, playerPositionY, playerPositionZ;

	void Awake () {
		player = GameObject.Find ("FPSController");	// find FirstPersonCharacter
		player.transform.position = new Vector3(0, 0, 0);
		playerCamera = GameObject.Find ("FirstPersonCharacter");
	}

	void Update () {
		playerPositionX = player.transform.position.x;
		playerPositionY = player.transform.position.y;
		playerPositionZ = player.transform.position.z;

		if (playerPositionY <= -25) {
			player.transform.position = new Vector3 (playerPositionX, 100, playerPositionZ);
			player.GetComponent<Rigidbody> ().isKinematic = true;	// enable kinematic from FPSController
			playerCamera.GetComponent<Camera> ().farClipPlane = 100;
			Debug.Log ("kinematic enabled");
		}

		if (playerPositionY >= 0 && playerPositionY <= 2) {
			playerCamera.GetComponent<Camera> ().farClipPlane = 60;
		}

		if (playerPositionY >= 50) {
			playerCamera.GetComponent<Camera> ().farClipPlane = 100;
		}

		//Debug.Log ("playerPositionY " + playerPositionY);
	}
}
