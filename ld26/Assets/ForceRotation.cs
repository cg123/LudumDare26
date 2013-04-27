using UnityEngine;
using System.Collections;

public class ForceRotation : MonoBehaviour {
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 currRot = transform.eulerAngles;
		transform.eulerAngles = new Vector3(currRot.x,0,currRot.z);
	}
}
