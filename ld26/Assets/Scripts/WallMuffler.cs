using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioLowPassFilter))]
public class WallMuffler : MonoBehaviour {
	public Transform playerObject;
	
	// Update is called once per frame
	void Update () {
		RaycastHit hitInfo;
		if (Physics.Raycast(transform.position, (playerObject.position - transform.position).normalized, out hitInfo, 10000, ~LayerMask.NameToLayer("Ignore Raycast"))) {
			if (hitInfo.collider.transform != playerObject) {
				GetComponent<AudioLowPassFilter>().enabled = true;
			}
			else {
				GetComponent<AudioLowPassFilter>().enabled = false;	
			}
		}
		else {
			GetComponent<AudioLowPassFilter>().enabled = false;	
		}
	}
}
