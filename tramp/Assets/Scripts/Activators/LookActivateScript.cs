using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LookActivateScript : MonoBehaviour
{
	
	private GameObject player;
	// to get FirstPersonCharacter
	private GameObject fps;
	// to get FPSController
	private GameObject sphere;
	// to show or hide the sphere
	public static bool StartEffect = false;
	// activate/desactivate effect
	bool ObjectLooking = false;
	// activate/desactivate effect
	public static int Timer = 0;
	// for timer count
	int LookLimit = 50;
	// time to stay looking for effect to start
	public static int EffectTime = 325;
	// duration of effect
	int randomValue;
	// random value to choose effect
	int planeChange = -14;
	// value to add or substract from planeSize
	bool planeSwitch = false;
	// to add or substract from plane

	/* audio variables */
	public AudioMixer mixer;
	public string parameterName = "DistortionLevel";

	protected float Parameter {
		get {
			float parameter;
			mixer.GetFloat (parameterName, out parameter);
			return parameter;
		}
		set {
			mixer.SetFloat (parameterName, value);
		}
	}

	void Awake ()
	{
		fps = GameObject.Find ("FPSController");							// find FPSController
		player = GameObject.Find ("FirstPersonCharacter");				// find FirstPersonCharacter
		player.GetComponent<Kino.Slitscan> ().enabled = false;			// disable slitscan effect
		player.GetComponent<Kino.Datamosh> ().enabled = false;			// disable datamosh effect
		player.GetComponent<Kino.AnalogGlitch> ().enabled = false;		// disable analog glitch effect
		player.GetComponent<Kino.Vision> ().enabled = false;			// disable vision effect
		sphere = GameObject.Find ("spherePreFab");						// find Sphere
		sphere.SetActive (false);										// disable sphere
	}

	void Update ()
	{
		if (StartEffect) {
			Timer++;	// starts counting

			if (Timer == 1) {
				randomValue = Random.Range (1, 14);	// creates random value to choose effect (the last value is not taken in consideration)
			}

			// boolean switch for plane size
			if (GenerateInfinite.planeSize == -14) {
				planeSwitch = true;
			}
			if (GenerateInfinite.planeSize == 14) {
				planeSwitch = false;
			}
			// size conditions for plane size
			if (GenerateInfinite.planeSize == 2) {
				GenerateInfinite.planeSize = -8;
			}
			if (GenerateInfinite.planeSize == -2) {
				GenerateInfinite.planeSize = 8;
			}

			// effects switch
			if (Timer < EffectTime) {
				if (Timer == 1) {
					if (EffectsCount.denyEffects == false) {
						EffectsCount.activeEffects++;
						Debug.Log ("Effects Count = " + EffectsCount.activeEffects);

						switch (randomValue) {
						// slitscan fx
						case 1:
							if (EffectsCount.slitscanFX) {
								player.GetComponent<Kino.Slitscan> ().enabled = true;	// enable slitscan effect
								Debug.Log ("slitscan enabled");
								EffectsCount.slitscanFX = false;
							} else {
								Timer = 1;
							}
							break;
						// kinematic
						case 2:
							if (EffectsCount.kinematicFX) {
								fps.GetComponent<Rigidbody> ().isKinematic = false;	// disable kinematic from FPSController
								Debug.Log ("FPS kinematic disabled");
								EffectsCount.kinematicFX = false;
							} else {
								Timer = 1;
							}
							break;
						// datamosh fx
						case 3:
							if (EffectsCount.datamoshFX) {
								player.GetComponent<Kino.Datamosh> ().enabled = true;	// enable datamosh effect
								player.GetComponent<Kino.Datamosh> ().Glitch ();		// start datamosh effect
								Debug.Log ("datamosh enabled");
								EffectsCount.datamoshFX = false;
							} else {
								Timer = 1;
							}
							break;
						// ground transparency
						case 4:
							if (EffectsCount.transparencyFX) {
								MaterialCutOff.cutOffValue = 1f;
								Debug.Log ("ground cut off = " + MaterialCutOff.cutOffValue);
								EffectsCount.transparencyFX = false;
							} else {
								Timer = 1;
							}
							break;
						// analog glitch fx
						case 5:
							if (EffectsCount.analogFX) {
								player.GetComponent<Kino.AnalogGlitch> ().enabled = true;	// enable analog glitch effect
								Debug.Log ("analog glitch enabled");
								EffectsCount.analogFX = false;
							} else {
								Timer = 1;
							}
							break;
						// sphere
						case 6:
							if (EffectsCount.sphereFX) {
								sphere.SetActive (true);
								Debug.Log ("sphere enabled");
								EffectsCount.sphereFX = false;
							} else {
								Timer = 1;
							}
							break;
						// vision fx
						case 7:
							if (EffectsCount.visionFX) {
								player.GetComponent<Kino.Vision> ().enabled = true;	// enable vision effect
								Debug.Log ("vision enabled");
								EffectsCount.visionFX = false;
							} else {
								Timer = 1;
							}
							break;
						// chunks distance
						case 8:
							if (EffectsCount.planeFX) {
								if (planeSwitch == true) {
									planeChange = 4;
								} else if (planeSwitch == false) {
									planeChange = -4;
								}
								GenerateInfinite.planeSize = GenerateInfinite.planeSize + planeChange;	// change plane size
								EffectsCount.activeEffects--;
								Debug.Log ("plane size changed = " + GenerateInfinite.planeSize);
								EffectsCount.planeFX = false;
							} else {
								Timer = 1;
							}
							break;
						// occlusion skybox
						case 9:
							if (EffectsCount.occlusionFX) {
								RenderSettings.skybox = SkyboxScript.occlusionStaticSky;	// enable occlusion skybox
								ChangeGround.occlusionGround = true;						// enable occlusion ground
								Debug.Log ("occlusion skybox and ground enabled");
								EffectsCount.occlusionFX = false;
							} else {
								Timer = 1;
							}
							break;
						// wireframe skybox
						case 10:
							if (EffectsCount.skyboxFX) {
								RenderSettings.skybox = SkyboxScript.wrongStaticSky;	// enable wrong skybox
								Debug.Log ("wrong skybox enabled");
								EffectsCount.skyboxFX = false;
							} else {
								Timer = 1;
							}
							break;
						// day time
						case 11:
							if (EffectsCount.solarFX) {
								CycleDay.tiempochequeo = 500;
								CycleDay.solar = Random.Range (0, 24);	// random change solar time
								EffectsCount.activeEffects--;
								Debug.Log ("solar time changed = " + CycleDay.solar);
								EffectsCount.solarFX = false;
							} else {
								Timer = 1;
							}
							break;
						// terrain height
						case 12:
							if (EffectsCount.heightFX) {
								GenerateTerrain.heightScale = Random.Range (2, 10);	// random terrain height scale
								EffectsCount.activeEffects--;
								Debug.Log ("terrain height scale changed = " + GenerateTerrain.heightScale);
								EffectsCount.heightFX = false;
							} else {
								Timer = 1;
							}
							break;
						// terrain detail
						case 13:
							if (EffectsCount.detailFX) {
								GenerateTerrain.detailScale = Random.Range (1.0f, 10.0f);	// random terrain detail
								EffectsCount.activeEffects--;
								Debug.Log ("terrain detail changed = " + GenerateTerrain.detailScale);
								EffectsCount.detailFX = false;
							} else {
								Timer = 1;
							}
							break;

						default:
							player.GetComponent<Kino.Slitscan> ().enabled = false;		// disable slitscan effect
							player.GetComponent<Kino.Datamosh> ().Reset ();				// stop datamosh effect
							player.GetComponent<Kino.Datamosh> ().enabled = false;		// disable datamosh effect
							player.GetComponent<Kino.AnalogGlitch> ().enabled = false;	// disable analog glitch effect
							player.GetComponent<Kino.Vision> ().enabled = false;		// disable vision effect
							sphere.SetActive (false);									// disable sphere
							RenderSettings.skybox = SkyboxScript.defaultStaticSky;		// enable default skybox
							ChangeGround.occlusionGround = false;						// disable occlusion ground
							CycleDay.solar = System.DateTime.Now.Hour;					// system time
							GenerateTerrain.heightScale = 1;							// default terrain height scale
							GenerateTerrain.detailScale = 10.0f;						// default terrain detail
							Parameter = 0.0f;											// audio fx return to default
							Debug.Log ("effects disabled");
							break;
						}
					}
				}
			} else {
				StartEffect = false;
				Timer = 0;	// reset timer
				player.GetComponent<Kino.Slitscan> ().enabled = false;		// disable slitscan effect
				player.GetComponent<Kino.Datamosh> ().Reset ();				// stop datamosh effect
				player.GetComponent<Kino.Datamosh> ().enabled = false;		// disable datamosh effect
				player.GetComponent<Kino.AnalogGlitch> ().enabled = false;	// disable analog glitch effect
				player.GetComponent<Kino.Vision> ().enabled = false;		// disable vision effect
				sphere.SetActive (false);									// disable sphere
				RenderSettings.skybox = SkyboxScript.defaultStaticSky;		// enable default skybox
				ChangeGround.occlusionGround = false;						// disable occlusion ground
				CycleDay.solar = System.DateTime.Now.Hour;					// system time
				GenerateTerrain.heightScale = 1;							// default terrain height scale
				GenerateTerrain.detailScale = 10.0f;						// default terrain detail
				Parameter = 0.0f;											// audio fx return to default
				//Debug.Log ("effect disabled = " + EffectsCount.activeEffects);
			}
			if (Timer == EffectTime) {
				EffectsCount.activeEffects--;
				Debug.Log ("effect disabled = " + EffectsCount.activeEffects);
				EffectsCount.slitscanFX = true;
				EffectsCount.kinematicFX = true;
				EffectsCount.datamoshFX = true;
				EffectsCount.transparencyFX = true;
				EffectsCount.analogFX = true;
				EffectsCount.sphereFX = true;
				EffectsCount.visionFX = true;
				EffectsCount.planeFX = true;
				EffectsCount.occlusionFX = true;
				EffectsCount.skyboxFX = true;
				EffectsCount.solarFX = true;
				EffectsCount.heightFX = true;
				EffectsCount.detailFX = true;
			}
			//Debug.Log ("effect enabled timer: " + Timer);
		}
	}

	void OnMouseOver ()
	{
		if (Time.realtimeSinceStartup >= 10.0f) {
			ObjectLooking = true;
			if (ObjectLooking) {
				player.GetComponent<Camera> ().fieldOfView = player.GetComponent<Camera> ().fieldOfView - 0.05f;	// field of view zoom

				if (Parameter < 0.9f) {			// change audio fx value
					Parameter = Parameter + 0.0005f;
				} else {
					Parameter = 0.9f;
				}
				//Debug.Log ("Audio FX: " + Parameter);

				Timer++;	// starts counting
				if ((Timer > LookLimit) && (StartEffect == false)) {
					StartEffect = true;
					Timer = 0;
				}
				//Debug.Log ("object lookin timer: " + Timer);
			}
		}
	}

	void OnMouseExit ()
	{
		if (Time.realtimeSinceStartup >= 10.0f) {
			ObjectLooking = false;
			if (StartEffect == false) {
				Timer = 0;
				Parameter = 0.0f;	// audio fx return to default
			}
			player.GetComponent<Camera> ().fieldOfView = 80f;	// field of view reset
		}
	}
}