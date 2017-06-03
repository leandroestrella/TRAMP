using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Video;

public class PlayerSpeed : MonoBehaviour {
	
	public VideoPlayer skyboxVideoPlayer;
	private GameObject player;	// to get FPS character
	int timer = 0;
	private CharacterController characterController;
	FirstPersonController fpc;
	bool incSpeed = false;

	void Awake () {
		player = GameObject.Find("FirstPersonCharacter");				// find FirstPersonCharacter
		player.GetComponent<Kino.Motion> ().enabled = false;			// disable slitscan effect
		characterController = gameObject.GetComponent<CharacterController> ();
		fpc = GameObject.FindObjectOfType<FirstPersonController> ();
	}

	void Update (){
		//Debug.Log (characterController.velocity.sqrMagnitude);
		if (characterController.velocity.sqrMagnitude > 1) {
			incSpeed = true;
			GenerateTerrain.objectChance = fpc.m_WalkSpeed / 10;	// object chance increments with player speed
		} else {
			player.GetComponent<Kino.Motion> ().enabled = false;	// disable slitscan effect
			player.GetComponent<Kino.Motion> ().frameBlending = 0;	// disable slitscan effect
			player.GetComponent<Kino.Motion> ().shutterAngle = 0;	// disable slitscan effect
			incSpeed = false;
			timer = 0;
			fpc.m_WalkSpeed = 6;				// first person controller walk speed
			fpc.m_RunSpeed = fpc.m_WalkSpeed;	// run speed equals walk speed
			fpc.m_JumpSpeed = 10;				// first person controller jump speed
			GenerateTerrain.objectChance = 1;	// set object chance to default
			if (LookActivateScript.StartEffect == false) {
				MaterialCutOff.cutOffValue = 0;
			}
			skyboxVideoPlayer.playbackSpeed = 1;// set skybox video player speed to default
		}

		if (incSpeed) {
			player.GetComponent<Kino.Motion> ().enabled = true;	// enable motion effect
			//Debug.Log ("motion enabled");
			timer++;
			if (timer > 1) {
				player.GetComponent<Kino.Motion> ().frameBlending = player.GetComponent<Kino.Motion> ().frameBlending + 0.0025f;
				player.GetComponent<Kino.Motion> ().shutterAngle++;
				fpc.m_WalkSpeed = fpc.m_WalkSpeed + 0.25f;							// increment speed
				fpc.m_RunSpeed = fpc.m_WalkSpeed;									// run speed equals walk speed
				fpc.m_JumpSpeed = fpc.m_JumpSpeed + 0.25f;							// increment jump
				MaterialCutOff.cutOffValue = MaterialCutOff.cutOffValue + 0.0025f;	// increment ground transparency
				/* increment skybox video player while walking */
				if (skyboxVideoPlayer.playbackSpeed < 7.4f) {
					skyboxVideoPlayer.playbackSpeed = skyboxVideoPlayer.playbackSpeed + 0.01f;
				} else {
					skyboxVideoPlayer.playbackSpeed = 7.4f;
				}
			}
		}
		//Debug.Log ("object chance changed = " + GenerateTerrain.objectChance);
		//Debug.Log (fpc.m_WalkSpeed);
	}
}