using UnityEngine;
using System.Collections;

public class OneShotSound : MonoBehaviour {

	public AudioClip sound = null;

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		audio.clip = sound;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying) {
			Destroy(gameObject);
		}
	}
}
