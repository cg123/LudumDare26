using UnityEngine;
using System.Collections;

public class FadeOnRespawn : MonoBehaviour {

	private DeathFade[] deathFadeCpts = null;

	void Awake () {
		deathFadeCpts = gameObject.GetComponentsInChildren<DeathFade>();
	}

	public void Respawn () {
		if (deathFadeCpts != null) {
			for (int i = 0; i < deathFadeCpts.Length; i++) {
				deathFadeCpts[i].StartDeathFade();
			}	
		}
	}
}
