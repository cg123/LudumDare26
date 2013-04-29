using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class RespawnPlayerOnHit : MonoBehaviour {

	public AudioClip collisionSound;
	private ContextualNarration narrator = null;


	void Awake () {
		narrator = transform.parent.GetComponentInChildren<ContextualNarration>();	
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			AudioSource.PlayClipAtPoint(collisionSound, other.transform.position);
			other.gameObject.SendMessage("Respawn");
			if (narrator != null) {
				narrator.Hurt();
			}
		}
	}
}
