using UnityEngine;
using System.Collections;

public class PositionalRespawn : MonoBehaviour {
	private Vector3 initialPos = new Vector3();
	private Quaternion initialRot = new Quaternion();
	

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		initialRot = transform.rotation;
	}

	public void Respawn () {
		transform.position = initialPos;
		transform.rotation = initialRot;
	}
}
