using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxScript : MonoBehaviour {

	public Material defaultSky;
	public Material occlusionSky;
	public Material wrongSky;					// hacer array
	public static Material defaultStaticSky;
	public static Material occlusionStaticSky;
	public static Material wrongStaticSky;

	void Awake () {
		defaultStaticSky = defaultSky;
		wrongStaticSky = wrongSky;				// corregir
		occlusionStaticSky = occlusionSky;
	}

	void Start () {
		RenderSettings.skybox = defaultSky;
	}
}