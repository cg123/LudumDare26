using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(transform.position, Vector3.one * 0.2f);
	}
}
