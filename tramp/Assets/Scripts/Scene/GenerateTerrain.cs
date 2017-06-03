using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour {

	public static int heightScale = 1;
	public static float detailScale = 10.0f;
	List<GameObject> myObjects = new List<GameObject>(); // so the terrain keeps track of the objects that it owns
	public static int holesToCreate = 4;		// how many holes to create in null pool
	public static int objectsToCreate = 1;		// how many objects to create in each pool
	public static float objectChance = 0.1f;		// objects chance % to take from pool
	public static int nullsToCreate = 4;		// how many nulls to create in null pool
	public static int nullAndEmptyChance = 1;	// null and empty objects chance % to take from pool

	void Start () {
		Mesh mesh = this.GetComponent<MeshFilter>().mesh;
		// we calculate the new vertices (we change the y value)
		Vector3[] vertices = mesh.vertices;

		// object pool 0 (hole)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and nullChance% chance that will generate an object
			if (vertices [v].y > 0.95 && Random.Range (0, 100) < nullAndEmptyChance) {

				GameObject newObject0 = ObjectPool0.getObject ();
				if (newObject0 != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y, // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObject0.transform.position = objectPos;	// set the object on the position calculated

					newObject0.SetActive (true);	// make object visible
					myObjects.Add (newObject0);	// add object to the list
				}
			}
		}

		// object pool a (banana)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
												(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;

			// if is taller than 0.8 and 1% chance that will generate an object
			if (vertices [v].y > 0.9 && Random.Range (0f, 100f) < objectChance) {
				// perlin noise to calculate position of objects similiar to the creation of the terrain
				//if(vertices[v].y > 0.8 && Mathf.PerlinNoise((vertices[v].x+5)/10,(vertices[v].z+5)/10)*10 > 4.6){
				GameObject newObject = ObjectPoolA.getObject ();
				if (newObject != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
						                    		 vertices [v].y + Random.Range (-0.5f, 0.5f), // to put the object lower than the terrain
						                    		 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObject.transform.position = objectPos;	// set the object on the position calculated
					newObject.transform.rotation = Quaternion.Euler (Random.Range (-180, 181), Random.Range (-180, 181), Random.Range (-180, 181));	// set the object on the position calculated

					newObject.SetActive (true);	// make object visible
					myObjects.Add (newObject);	// add object to the list
				}
			}
		}

		// object pool b (bike)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
												(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.8 && Random.Range (0f, 100f) < objectChance) {
				
				GameObject newObjectB = ObjectPoolB.getObject ();
				if (newObjectB != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 1.75f), // to put the object lower than the terrain
						                    		 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectB.transform.position = objectPos;	// set the object on the position calculated
					newObjectB.transform.rotation = Quaternion.Euler (Random.Range (-15, 16), Random.Range (-180, 181), Random.Range (-180, 181));	// set the object on the position calculated

					newObjectB.SetActive (true);	// make object visible
					myObjects.Add (newObjectB);	// add object to the list
				}
			}
		}

		// object pool c (sardine fish)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
												(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.4 and 1% chance that will generate an object
			if (vertices [v].y > 0.7 && Random.Range (0f, 100f) < nullAndEmptyChance) {

				GameObject newObjectC = ObjectPoolC.getObject ();
				if (newObjectC != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x,
													 vertices [v].y + Random.Range (-0.5f, 0.25f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z);
					newObjectC.transform.position = objectPos;	// set the object on the position calculated
					newObjectC.transform.rotation = Quaternion.Euler (Random.Range (-180, 181), Random.Range (-180, 181), Random.Range (-180, 181));	// set the object on the position calculated

					newObjectC.SetActive (true);	// make object visible
					myObjects.Add (newObjectC);	// add object to the list
				}
			}
		}

		// object pool d (empty trigger)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
												(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.6 && Random.Range (0, 100) < nullAndEmptyChance) {

				GameObject newObjectD = ObjectPoolD.getObject ();
				if (newObjectD != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x,
													 vertices [v].y, // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z);
					newObjectD.transform.position = objectPos;	// set the object on the position calculated

					newObjectD.SetActive (true);	// make object visible
					myObjects.Add (newObjectD);	// add object to the list
				}
			}
		}

		// object pool e (boiler)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
												(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.5 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectE = ObjectPoolE.getObject ();
				if (newObjectE != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 0.25f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectE.transform.position = objectPos;	// set the object on the position calculated
					newObjectE.transform.rotation = Quaternion.Euler (Random.Range (-15, 16), Random.Range (-180, 181), Random.Range (-180, 181));	// set the object on the position calculated

					newObjectE.SetActive (true);	// make object visible
					myObjects.Add (newObjectE);	// add object to the list
				}
			}
		}

		// object pool f (strawberry)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
												(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.4 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectF = ObjectPoolF.getObject ();
				if (newObjectF != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 0.15f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectF.transform.position = objectPos;	// set the object on the position calculated
					newObjectF.transform.rotation = Quaternion.Euler (Random.Range (-15, 16), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectF.SetActive (true);	// make object visible
					myObjects.Add (newObjectF);	// add object to the list
				}
			}
		}

		// object pool g (book libro)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
												(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.3 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectG = ObjectPoolG.getObject ();
				if (newObjectG != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 0.56f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectG.transform.position = objectPos;	// set the object on the position calculated
					newObjectG.transform.rotation = Quaternion.Euler (Random.Range (-15, 16), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectG.SetActive (true);	// make object visible
					myObjects.Add (newObjectG);	// add object to the list
				}
			}
		}

		// object pool h (moka closed)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
												(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.2 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectH = ObjectPoolH.getObject ();
				if (newObjectH != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 0.51f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectH.transform.position = objectPos;	// set the object on the position calculated
					newObjectH.transform.rotation = Quaternion.Euler (Random.Range (-15, 16), Random.Range (-180, 181), Random.Range (-180, 181));	// set the object on the position calculated

					newObjectH.SetActive (true);	// make object visible
					myObjects.Add (newObjectH);	// add object to the list
				}
			}
		}

		// object pool i (moka open)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
												(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.1 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectI = ObjectPoolI.getObject ();
				if (newObjectI != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 0.51f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectI.transform.position = objectPos;	// set the object on the position calculated
					newObjectI.transform.rotation = Quaternion.Euler (Random.Range (-15, 16), Random.Range (-180, 181), Random.Range (-180, 181));	// set the object on the position calculated

					newObjectI.SetActive (true);	// make object visible
					myObjects.Add (newObjectI);	// add object to the list
				}
			}
		}

		// object pool j (chair)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.15 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectJ = ObjectPoolJ.getObject ();
				if (newObjectJ != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 1.86f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectJ.transform.position = objectPos;	// set the object on the position calculated
					newObjectJ.transform.rotation = Quaternion.Euler (Random.Range (-15, 16), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectJ.SetActive (true);	// make object visible
					myObjects.Add (newObjectJ);	// add object to the list
				}
			}
		}
		// object pool k (tv)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectK = ObjectPoolK.getObject ();
				if (newObjectK != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 1.01f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectK.transform.position = objectPos;	// set the object on the position calculated
					newObjectK.transform.rotation = Quaternion.Euler (Random.Range (-15, 16), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectK.SetActive (true);	// make object visible
					myObjects.Add (newObjectK);	// add object to the list
				}
			}
		}
		// object pool l (escalera)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectL = ObjectPoolL.getObject ();
				if (newObjectL != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (-4.0f, 0.1f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectL.transform.position = objectPos;	// set the object on the position calculated
					newObjectL.transform.rotation = Quaternion.Euler (Random.Range (-75, 76), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectL.SetActive (true);	// make object visible
					myObjects.Add (newObjectL);	// add object to the list
				}
			}
		}
		// object pool m (planta1)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectM = ObjectPoolM.getObject ();
				if (newObjectM != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x,
													 vertices [v].y - Random.Range (0.1f, 0.6f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z);
					newObjectM.transform.position = objectPos;	// set the object on the position calculated
					newObjectM.transform.rotation = Quaternion.Euler (Random.Range (-15, 16), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectM.SetActive (true);	// make object visible
					myObjects.Add (newObjectM);	// add object to the list
				}
			}
		}
		// object pool n (planta2)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectN = ObjectPoolN.getObject ();
				if (newObjectN != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x ,
													 vertices [v].y - Random.Range (0.1f, 0.6f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z);
					newObjectN.transform.position = objectPos;	// set the object on the position calculated
					newObjectN.transform.rotation = Quaternion.Euler (Random.Range (-15, 16), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectN.SetActive (true);	// make object visible
					myObjects.Add (newObjectN);	// add object to the list
				}
			}
		}
		// object pool o (speaker chair)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectO = ObjectPoolO.getObject ();
				if (newObjectO != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 0.25f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectO.transform.position = objectPos;	// set the object on the position calculated
					newObjectO.transform.rotation = Quaternion.Euler (Random.Range (-15, 16), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectO.SetActive (true);	// make object visible
					myObjects.Add (newObjectO);	// add object to the list
				}
			}
		}
		// object pool p (talco bottle)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectP = ObjectPoolP.getObject ();
				if (newObjectP != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 0.25f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectP.transform.position = objectPos;	// set the object on the position calculated
					newObjectP.transform.rotation = Quaternion.Euler (Random.Range (-180, 181), Random.Range (-180, 181), Random.Range (-180, 181));	// set the object on the position calculated

					newObjectP.SetActive (true);	// make object visible
					myObjects.Add (newObjectP);	// add object to the list
				}
			}
		}
		// object pool q (office chair)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectQ = ObjectPoolQ.getObject ();
				if (newObjectQ != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 2.16f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectQ.transform.position = objectPos;	// set the object on the position calculated
					newObjectQ.transform.rotation = Quaternion.Euler (Random.Range (-75, 76), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectQ.SetActive (true);	// make object visible
					myObjects.Add (newObjectQ);	// add object to the list
				}
			}
		}
		// object pool r (air fan)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectR = ObjectPoolR.getObject ();
				if (newObjectR != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 2.01f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectR.transform.position = objectPos;	// set the object on the position calculated
					newObjectR.transform.rotation = Quaternion.Euler (Random.Range (-75, 76), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectR.SetActive (true);	// make object visible
					myObjects.Add (newObjectR);	// add object to the list
				}
			}
		}
		// object pool s (tendedero)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectS = ObjectPoolS.getObject ();
				if (newObjectS != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 3.1f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectS.transform.position = objectPos;	// set the object on the position calculated
					newObjectS.transform.rotation = Quaternion.Euler (Random.Range (-75, 76), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectS.SetActive (true);	// make object visible
					myObjects.Add (newObjectS);	// add object to the list
				}
			}
		}
		// object pool t (cow toy)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectT = ObjectPoolT.getObject ();
				if (newObjectT != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 0.25f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectT.transform.position = objectPos;	// set the object on the position calculated
					newObjectT.transform.rotation = Quaternion.Euler (Random.Range (-75, 76), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectT.SetActive (true);	// make object visible
					myObjects.Add (newObjectT);	// add object to the list
				}
			}
		}
		// object pool u (elephant toy)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectU = ObjectPoolU.getObject ();
				if (newObjectU != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 0.25f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectU.transform.position = objectPos;	// set the object on the position calculated
					newObjectU.transform.rotation = Quaternion.Euler (Random.Range (-75, 76), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectU.SetActive (true);	// make object visible
					myObjects.Add (newObjectU);	// add object to the list
				}
			}
		}
		// object pool v (gas)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectV = ObjectPoolV.getObject ();
				if (newObjectV != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 0.25f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectV.transform.position = objectPos;	// set the object on the position calculated
					newObjectV.transform.rotation = Quaternion.Euler (Random.Range (-75, 76), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectV.SetActive (true);	// make object visible
					myObjects.Add (newObjectV);	// add object to the list
				}
			}
		}
		// object pool w (plush head)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectW = ObjectPoolW.getObject ();
				if (newObjectW != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 0.25f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectW.transform.position = objectPos;	// set the object on the position calculated
					newObjectW.transform.rotation = Quaternion.Euler (Random.Range (-75, 76), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectW.SetActive (true);	// make object visible
					myObjects.Add (newObjectW);	// add object to the list
				}
			}
		}
		// object pool x (roof lamp)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
				(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectX = ObjectPoolX.getObject ();
				if (newObjectX != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 0.25f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectX.transform.position = objectPos;	// set the object on the position calculated
					newObjectX.transform.rotation = Quaternion.Euler (Random.Range (-180, 181), Random.Range (-180, 181), Random.Range (-180, 181));	// set the object on the position calculated

					newObjectX.SetActive (true);	// make object visible
					myObjects.Add (newObjectX);	// add object to the list
				}
			}
		}
		// object pool y (balloons)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
												(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectY = ObjectPoolY.getObject ();
				if (newObjectY != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 0.25f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectY.transform.position = objectPos;	// set the object on the position calculated
					newObjectY.transform.rotation = Quaternion.Euler (Random.Range (-75, 76), Random.Range (-180, 181), Random.Range (-15, 16));	// set the object on the position calculated

					newObjectY.SetActive (true);	// make object visible
					myObjects.Add (newObjectY);	// add object to the list
				}
			}
		}
		// object pool z (adrian)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
												(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectZ = ObjectPoolZ.getObject ();
				if (newObjectZ != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 4.51f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectZ.transform.position = objectPos;	// set the object on the position calculated
					newObjectZ.transform.rotation = Quaternion.Euler (Random.Range (-180, 181), Random.Range (-180, 181), Random.Range (-180, 181));	// set the object on the position calculated

					newObjectZ.SetActive (true);	// make object visible
					myObjects.Add (newObjectZ);	// add object to the list
				}
			}
		}
		// object pool ll (laura)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
												(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectLL = ObjectPoolLL.getObject ();
				if (newObjectLL != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 3.96f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectLL.transform.position = objectPos;	// set the object on the position calculated
					newObjectLL.transform.rotation = Quaternion.Euler (Random.Range (-90, 91), Random.Range (-180, 181), Random.Range (-90, 91));	// set the object on the position calculated

					newObjectLL.SetActive (true);	// make object visible
					myObjects.Add (newObjectLL);	// add object to the list
				}
			}
		}
		// object pool gn (leandro)
		for (int v = 0; v < vertices.Length; v++)
		{	// lift up each Y vertex on the grid
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / detailScale,
												(vertices [v].z + this.transform.position.z) / detailScale) * heightScale;
			// if is taller than 0.6 and 1% chance that will generate an object
			if (vertices [v].y > 0.25 && Random.Range (0f, 100f) < objectChance) {

				GameObject newObjectGN = ObjectPoolGN.getObject ();
				if (newObjectGN != null) {	// if objects from the pool are available create them
					// calculate position
					Vector3 objectPos = new Vector3 (vertices [v].x + this.transform.position.x + Random.Range (-175.0f, 175.1f),
													 vertices [v].y + Random.Range (0.0f, 1.86f), // to put the object lower than the terrain
													 vertices [v].z + this.transform.position.z + Random.Range (-175.0f, 175.1f));
					newObjectGN.transform.position = objectPos;	// set the object on the position calculated
					newObjectGN.transform.rotation = Quaternion.Euler (Random.Range (-90, 91), Random.Range (-180, 181), Random.Range (-90, 91));	// set the object on the position calculated

					newObjectGN.SetActive (true);	// make object visible
					myObjects.Add (newObjectGN);	// add object to the list
				}
			}
		}
		// update the real mesh and we apply the new vertexs to the real mesh
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		this.gameObject.AddComponent<MeshCollider>();
	}

	// hide objects when you go away from the plane
	void OnDestroy() {
		for (int i = 0; i < myObjects.Count; i++) {
			if (myObjects [i] != null) {			// if the object exists
				myObjects [i].SetActive (false);	// hide the object
			}
		}
		myObjects.Clear ();
	}
}
