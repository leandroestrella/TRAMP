using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipNormals : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//we grab the mesh on the object
		Mesh mesh = this.GetComponent<MeshFilter> ().mesh;
		//then we grab the normals on that object
		Vector3[] normals = mesh.normals;
		//we invert the normals whit -1 (180 degrees)
		for ( int i = 0; i < normals.Length; i++)
			normals[i] = -1 * normals[i];
		//then we apply them back on the object
		mesh.normals = normals;
		//now we loop again around the mesh and we swap the first and the third vertex
		for (int i = 0; i < mesh.subMeshCount; i++)
		{
			int [] tris = mesh.GetTriangles(i);
			for ( int j = 0; j<tris.Length; j +=3)
			{
				//swap order of tri vertices
				int temp = tris[j];
				tris[j] = tris[j+1];
				tris[j+1] = temp;
			}
			//we put back the triangles on the mesh
			mesh.SetTriangles(tris, i);
		}
		
	}

}
