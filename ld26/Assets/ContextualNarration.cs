using UnityEngine;
using System.Collections;

public class ContextualNarration : MonoBehaviour {

	private int timesPassedTriangle = 0;
	private int timesHurt = 0;
	public AudioClip passedSound = null;
	public AudioClip hurtSound = null;

	public void Hurt () {
		//Debug.Log("HURT!");
		timesHurt ++;
		if (timesHurt == 1) {
			StartCoroutine(PlayASAP(hurtSound));
		}
	}

	IEnumerator PlayASAP(AudioClip clip) {
		yield return new WaitForSeconds(0.1f);
		if (!audio.isPlaying) {
			//Debug.Log("PLAYED "+clip.name);
			audio.clip = clip;	
			audio.Play();
			yield return null;
		} else {
			yield return StartCoroutine(PlayASAP(clip));
		}		
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			timesPassedTriangle++;
			if (timesPassedTriangle == 1) {
				StartCoroutine(PlayASAP(passedSound));
			}
		}
	}
}
