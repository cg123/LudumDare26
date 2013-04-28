using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	public bool playWithRift = false;
	public string nextLevelName;

	void Awake () {
		if (playWithRift) {
			PlayerPrefs.SetString("UseRift", "The way it was meant to be played.");	
		} else {
			if (PlayerPrefs.HasKey("UseRift")) {
				PlayerPrefs.DeleteKey("UseRift");		
			}
		}
	}

	// Use this for initialization
	void Start () {
		Application.LoadLevel(nextLevelName);
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.cyan;
		Gizmos.DrawCube(transform.position, Vector3.one);
	}
}
