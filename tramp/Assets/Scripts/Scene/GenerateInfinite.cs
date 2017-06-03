using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Tile	// class to create and keep track of the tiles
{
	public GameObject theTile;
	public float creationTime;

	public Tile(GameObject t, float ct)	// constructor of the class
	{
		theTile = t;		// tile created
		creationTime = ct;	// creation time
	}
}

public class GenerateInfinite : MonoBehaviour {

	GameObject plane;
	GameObject player;

	public static int planeSize = 10;	// size of tile created (was 10)
	int halfTilesX = 8;		// radius of creation
	int halfTilesZ = 8;		// of tiles around the player

	Vector3 startPos;	// to keep track were the player is and where the player was

	Hashtable tiles = new Hashtable(); // to index object acording to z & x position

	void Awake() {
		plane = GameObject.Find ("SmartPlane");
		player = GameObject.Find ("FPSController");
	}

	void Start ()
	{
		this.gameObject.transform.position = Vector3.zero;
		startPos = Vector3.zero;

		float updateTime = Time.realtimeSinceStartup;

		for(int x = -halfTilesX; x < halfTilesX; x++)
		{
			for(int z = -halfTilesZ; z < halfTilesZ; z++)
			{
				Vector3 pos = new Vector3((x * planeSize + startPos.x),
					              			 0,
					              		  (z * planeSize + startPos.z));
				GameObject t = (GameObject) Instantiate(plane, pos,
					               Quaternion.identity);	// here we create the tile

				string tilename = "Tile_" + ((int)(pos.x)).ToString () + "_" + ((int)(pos.z)).ToString ();	// we give name to the tile
				t.name = tilename;
				Tile tile = new Tile(t, updateTime);	// we create another tile with their name and time
				tiles.Add(tilename, tile); // we add the tile to the hashtable
			}
		}
	}
	
	void Update () {
		// determine how far the player has moved since last terrain update
		int xMove = (int)(player.transform.position.x - startPos.x);
		int zMove = (int)(player.transform.position.z - startPos.z);

		if(Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)	// if we move the size of the tile
		{
			float updateTime = Time.realtimeSinceStartup; // we update time so we can give it to the tile name

			// force integer position and round to nearest tilesize
			int playerX = (int)(Mathf.Floor(player.transform.position.x/planeSize)*planeSize);
			int playerZ = (int)(Mathf.Floor(player.transform.position.z/planeSize)*planeSize);

			for(int x = -halfTilesX; x < halfTilesX; x++)
			{
				for(int z = -halfTilesZ; z < halfTilesZ; z++)
				{	// we create the new tiles around the player x and z position
					Vector3 pos = new Vector3((x * planeSize + playerX),
												0,
											  (z * planeSize + playerZ));
					// we set the name of the tile
					string tilename = "Tile_" + ((int)(pos.x)).ToString () + "_" + ((int)(pos.z)).ToString ();

					if (!tiles.ContainsKey (tilename))
					{
						GameObject t = (GameObject)Instantiate (plane, pos,
							               Quaternion.identity);
						t.name = tilename;
						Tile tile = new Tile (t, updateTime);
						tiles.Add (tilename, tile);
					}
					else
					{
						// if tile still relevant change its time stamp
						(tiles [tilename] as Tile).creationTime = updateTime;
					}
				}
			}

			// destroy all tiles not just created or with time updated
			// and put new tiles and tiles to be kepts in a new hashtable
			Hashtable newTerrain = new Hashtable();
			foreach (Tile tls in tiles.Values)
			{
				if (tls.creationTime != updateTime) {
					// delete gameobject
					Destroy (tls.theTile);
				}
				else
				{
					newTerrain.Add (tls.theTile.name, tls);
				}
			}
			// copy new hashtable contents to the working hashtable
			tiles = newTerrain;
			startPos = player.transform.position;
		}
	}
}
