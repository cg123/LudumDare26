using UnityEngine;
using System.Collections;

public class Respawner : MonoBehaviour {

	public void RespawnAll () {
		CanRespawn[] respawnables = gameObject.GetComponentsInChildren<CanRespawn>();
		for (int i = 0; i < respawnables.Length; i++) {
			respawnables[i].BeginRespawn();
		}
	}

	public void ResumeAll () {
		CanRespawn[] respawnables = gameObject.GetComponentsInChildren<CanRespawn>();
		for (int i = 0; i < respawnables.Length; i++) {
			respawnables[i].BeginResume();
		}	
	}
}
