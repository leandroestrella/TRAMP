using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour {

	private GameObject player;
	private Vector3 offset;		// distance between camera and player

	void Start () {
		player = GameObject.Find("FirstPersonCharacter");	// find FirstPersonCharacter
		/* calculate and store the offset value by getting the distance
		 		between the player's position and the camera's position */
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () {
		/* set the position of the camera's transform to be the same as the
		 			player's, but offset by the calculated offset distance */
		transform.position = player.transform.position + offset;

		if (player.transform.position.y <= -0.5 || player.transform.position.y >= 0.5) {
			transform.position = new Vector3(player.transform.position.x,100,player.transform.position.z);
		}
	}
}
