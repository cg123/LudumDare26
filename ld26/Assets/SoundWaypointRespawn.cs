using UnityEngine;
using System.Collections;

public class SoundWaypointRespawn : MonoBehaviour {
	public void Respawn() {
		SoundWaypoint[] waypts = GetComponentsInChildren<SoundWaypoint>();
		for (int i = 0; i < waypts.Length; i++) {
			waypts[i].Respawn();
		}
	}
}
