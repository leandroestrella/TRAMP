using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireframeTexture : MonoBehaviour {

	void OnPreRender() {
		GL.wireframe = true;
	}

	void OnPostRender() {
		GL.wireframe = false;
		GL.Clear (false, true, Color.white);
	}
}