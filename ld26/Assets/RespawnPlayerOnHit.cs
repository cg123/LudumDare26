using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class RespawnPlayerOnHit : MonoBehaviour {

	public AudioClip collisionSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			AudioSource.PlayClipAtPoint(collisionSound, other.transform.position);
			other.gameObject.SendMessage("Respawn");
		}
	}
}
