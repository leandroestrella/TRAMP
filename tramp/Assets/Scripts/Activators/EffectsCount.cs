using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsCount : MonoBehaviour
{

	public static int activeEffects;
	public static bool denyEffects;
	public static bool slitscanFX, kinematicFX, datamoshFX, transparencyFX, analogFX, sphereFX, visionFX, planeFX, occlusionFX, skyboxFX, solarFX, heightFX, detailFX;

	void Awake ()
	{
		activeEffects = 0;
		denyEffects = false;
		/* fx switchs */
		slitscanFX = true;
		kinematicFX = true;
		datamoshFX = true;
		transparencyFX = true;
		analogFX = true;
		sphereFX = true;
		visionFX = true;
		planeFX = true;
		occlusionFX = true;
		skyboxFX = true;
		solarFX = true;
		heightFX = true;
		detailFX = true;
	}

	void Update ()
	{
		if (activeEffects < 0) {
			activeEffects = 0;
		}

		/* count effects */
		/*
		if (LookActivateScript.StartEffect && LookActivateScript.Timer == 1) {
			activeEffects++;
			Debug.Log ("Active Effects = " + activeEffects);
		}
		*/
		if (LookActivateScript.Timer == LookActivateScript.EffectTime) {
			activeEffects--;
			Debug.Log ("Active Effects = " + activeEffects);
		}

		/* limit effects */
		if (activeEffects >= 2) {
			denyEffects = true;
			//Debug.Log ("Effects Limit Reached");
		} else {
			denyEffects = false;
		}

		/* effects switch */

	}
}
