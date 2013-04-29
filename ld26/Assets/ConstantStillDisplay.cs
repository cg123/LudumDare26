using UnityEngine;
using System.Collections;

public class ConstantStillDisplay : MonoBehaviour {

	public Texture2D texToDisplay = null;

	void OnGUI () {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texToDisplay);
	} 
}
