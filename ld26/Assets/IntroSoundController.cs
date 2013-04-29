using UnityEngine;
using System.Collections;

public class IntroSoundController : MonoBehaviour {

	void Awake () {
		 DontDestroyOnLoad(gameObject);
	}

	void Update () {
		if (!audio.isPlaying) {
			Destroy(gameObject);
		}
	}
	

}
