using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class RespawnPlayerOnHit : MonoBehaviour {

	public AudioClip collisionSound;
	private ContextualNarration narrator = null;
	private Respawner respawner = null;


	void Awake () {
		narrator = transform.parent.GetComponentInChildren<ContextualNarration>();	
		respawner = GameObject.FindWithTag("Respawn").GetComponent<Respawner>();
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			AudioSource.PlayClipAtPoint(collisionSound, other.transform.position);
			if (respawner) {
				respawner.RespawnAll();
			}
			if (narrator != null) {
				narrator.Hurt();
			}
		}
	}
}
