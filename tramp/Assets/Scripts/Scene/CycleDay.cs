using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Light))]

public class CycleDay : MonoBehaviour
{
	
	public float tiempoSegundos = 0;
	public static int solar = 0;
	public static int tiempochequeo;
	public GameObject player;
	public Light LT;

	void Awake ()
	{
		player = GameObject.Find ("FPSController");
		solar = System.DateTime.Now.Hour;	// system time

		//inicializar sistema para que el sol se coloque en posicion correcta al arrancar el juego.
		//horas a lo largo del dia para cambiar posicion del sol y hacer una rotacion entre ellas.
		switch (solar) {
		case 7:
			transform.rotation = Quaternion.Euler (100, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 0.75f;
			tiempochequeo = 0;
			break;

		case 8:
			transform.rotation = Quaternion.Euler (100, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 1.2f;
			tiempochequeo = 0;
			break;

		case 9:
			transform.rotation = Quaternion.Euler (100, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 1.4f;
			tiempochequeo = 0;
			break;

		case 10:
			transform.rotation = Quaternion.Euler (110, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 1.5f;
			tiempochequeo = 0;
			break;

		case 11:
			transform.rotation = Quaternion.Euler (115, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 1.7f;
			tiempochequeo = 0;
			break;

		case 12:
			transform.rotation = Quaternion.Euler (120, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 1.9f;
			tiempochequeo = 0;
			break;

		case 13:
			transform.rotation = Quaternion.Euler (125, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 2.1f;		
			tiempochequeo = 0;
			break;

		case 14:
			transform.rotation = Quaternion.Euler (130, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 2.3f;
			tiempochequeo = 0;
			break;

		case 15:
			transform.rotation = Quaternion.Euler (135, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 2.3f;
			tiempochequeo = 0;
			break;

		case 16:
			transform.rotation = Quaternion.Euler (140, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 2.1f;			
			tiempochequeo = 0;
			break;

		case 17:
			transform.rotation = Quaternion.Euler (150, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 2;
			tiempochequeo = 0;
			break;

		case 18:
			transform.rotation = Quaternion.Euler (155, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 1.8f;
			tiempochequeo = 0;
			break;

		case 19:
			transform.rotation = Quaternion.Euler (160, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 1.6f;
			tiempochequeo = 0;
			break;

		case 20:
			transform.rotation = Quaternion.Euler (170, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 1;
			tiempochequeo = 0;
			break;

		case 21:
			transform.rotation = Quaternion.Euler (175, 0, 90);
			LT.color = new Color32 (255, 244, 214, 255);
			LT.intensity = 0.75f;
			tiempochequeo = 0;
			break;

		case 22:
			transform.rotation = Quaternion.Euler (175, 0, 90);
			LT.intensity = 0.5f;
			LT.color = new Color32 (61, 68, 141, 255);
			tiempochequeo = 0;
			break;

		case 23:
			transform.rotation = Quaternion.Euler (175, 0, 90);
			LT.intensity = 0.5f;
			LT.color = new Color32 (61, 68, 141, 255);
			tiempochequeo = 0;
			break;

		case 0:
			transform.rotation = Quaternion.Euler (175, 0, 90);
			LT.intensity = 0.5f;
			LT.color = new Color32 (61, 68, 141, 255);
			tiempochequeo = 0;
			break;

		case 1:
			transform.rotation = Quaternion.Euler (175, 0, 90);
			LT.intensity = 0.5f;
			LT.color = new Color32 (61, 68, 141, 255);
			tiempochequeo = 0;
			break;

		case 2:
			transform.rotation = Quaternion.Euler (175, 0, 90);
			LT.intensity = 0.5f;
			LT.color = new Color32 (61, 68, 141, 255);
			tiempochequeo = 0;
			break;

		case 3:
			transform.rotation = Quaternion.Euler (35, 0, 90);
			LT.intensity = 0.5f;
			LT.color = new Color32 (61, 68, 141, 255);
			tiempochequeo = 0;
			break;

		case 4:
			transform.rotation = Quaternion.Euler (35, 0, 90);
			LT.intensity = 0.5f;
			LT.color = new Color32 (61, 68, 141, 255);
			tiempochequeo = 0;
			break;

		case 5:
			transform.rotation = Quaternion.Euler (175, 0, 90);
			LT.intensity = 0.5f;
			LT.color = new Color32 (61, 68, 141, 255);
			tiempochequeo = 0;
			break;

		case 6:
			transform.rotation = Quaternion.Euler (175, 0, 90);
			LT.intensity = 0.5f;
			LT.color = new Color32 (61, 68, 141, 255);
			tiempochequeo = 0;
			break;
		}
	}

	void Update ()
	{
		tiempochequeo++;

		// Bucle para comprobar que se realiza la posición solar de manera correcta a lo largo de las horas del día.
		if (tiempochequeo >= 500) {
			//solar = System.DateTime.Now.Hour;
			switch (solar) {
			case 7:
				transform.rotation = Quaternion.Euler (100, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 0.75f;
				tiempochequeo = 0;
				break;

			case 8:
				transform.rotation = Quaternion.Euler (100, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 1.2f;
				tiempochequeo = 0;
				break;

			case 9:
				transform.rotation = Quaternion.Euler (100, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 1.4f;
				tiempochequeo = 0;
				break;

			case 10:
				transform.rotation = Quaternion.Euler (110, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 1.5f;
				tiempochequeo = 0;
				break;

			case 11:
				transform.rotation = Quaternion.Euler (115, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 1.7f;
				tiempochequeo = 0;
				break;

			case 12:
				transform.rotation = Quaternion.Euler (120, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 1.9f;
				tiempochequeo = 0;
				break;

			case 13:
				transform.rotation = Quaternion.Euler (125, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 2.1f;		
				tiempochequeo = 0;
				break;

			case 14:
				transform.rotation = Quaternion.Euler (130, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 2.3f;
				tiempochequeo = 0;
				break;

			case 15:
				transform.rotation = Quaternion.Euler (135, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 2.3f;
				tiempochequeo = 0;
				break;

			case 16:
				transform.rotation = Quaternion.Euler (140, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 2.1f;			
				tiempochequeo = 0;
				break;

			case 17:
				transform.rotation = Quaternion.Euler (150, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 2;
				tiempochequeo = 0;
				break;

			case 18:
				transform.rotation = Quaternion.Euler (155, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 1.8f;
				tiempochequeo = 0;
				break;

			case 19:
				transform.rotation = Quaternion.Euler (160, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 1.6f;
				tiempochequeo = 0;
				break;

			case 20:
				transform.rotation = Quaternion.Euler (170, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 1;
				tiempochequeo = 0;
				break;

			case 21:
				transform.rotation = Quaternion.Euler (175, 0, 90);
				LT.color = new Color32 (255, 244, 214, 255);
				LT.intensity = 0.75f;
				tiempochequeo = 0;
				break;

			case 22:
				transform.rotation = Quaternion.Euler (175, 0, 90);
				LT.intensity = 0.5f;
				LT.color = new Color32 (61, 68, 141, 255);
				tiempochequeo = 0;
				break;

			case 23:
				transform.rotation = Quaternion.Euler (175, 0, 90);
				LT.intensity = 0.5f;
				LT.color = new Color32 (61, 68, 141, 255);
				tiempochequeo = 0;
				break;

			case 0:
				transform.rotation = Quaternion.Euler (175, 0, 90);
				LT.intensity = 0.5f;
				LT.color = new Color32 (61, 68, 141, 255);
				tiempochequeo = 0;
				break;

			case 1:
				transform.rotation = Quaternion.Euler (175, 0, 90);
				LT.intensity = 0.5f;
				LT.color = new Color32 (61, 68, 141, 255);
				tiempochequeo = 0;
				break;

			case 2:
				transform.rotation = Quaternion.Euler (175, 0, 90);
				LT.intensity = 0.5f;
				LT.color = new Color32 (61, 68, 141, 255);
				tiempochequeo = 0;
				break;

			case 3:
				transform.rotation = Quaternion.Euler (35, 0, 90);
				LT.intensity = 0.5f;
				LT.color = new Color32 (61, 68, 141, 255);
				tiempochequeo = 0;
				break;

			case 4:
				transform.rotation = Quaternion.Euler (35, 0, 90);
				LT.intensity = 0.5f;
				LT.color = new Color32 (61, 68, 141, 255);
				tiempochequeo = 0;
				break;

			case 5:
				transform.rotation = Quaternion.Euler (175, 0, 90);
				LT.intensity = 0.5f;
				LT.color = new Color32 (61, 68, 141, 255);
				tiempochequeo = 0;
				break;

			case 6:
				transform.rotation = Quaternion.Euler (175, 0, 90);
				LT.intensity = 0.5f;
				LT.color = new Color32 (61, 68, 141, 255);
				tiempochequeo = 0;
				break;
			}
		}
	}
}
	