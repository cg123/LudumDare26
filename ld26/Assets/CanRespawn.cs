using UnityEngine;
using System.Collections;

public class CanRespawn : MonoBehaviour {

	private Vector3 initialPos = new Vector3();
	private Quaternion initialRot = new Quaternion();
	private DeathFade[] deathFadeCpts = null;

	void Awake () {
		deathFadeCpts = GetComponentsInChildren<DeathFade>();
	}

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		initialRot = transform.rotation;
	}

	public void Respawn () {
		Debug.Log("Respawn!");
		transform.position = initialPos;
		transform.rotation = initialRot;
		for (int i = 0; i < deathFadeCpts.Length; i++) {
			deathFadeCpts[i].StartDeathFade();
		}
	}
}
