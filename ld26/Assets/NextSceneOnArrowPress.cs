using UnityEngine;
using System.Collections;

public class NextSceneOnArrowPress : MonoBehaviour {
	public string nextLevelName;
	public GameObject avatar = null;

	private DeathFade[] fadeCpts = null;
	private bool switchActivated = false;

	void Awake () {
		fadeCpts = avatar.GetComponentsInChildren<DeathFade>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
			if (!switchActivated) {
				//float fadeDuration = 0.0f;
				for (int i = 0; i < fadeCpts.Length; i++) {
					fadeCpts[i].StartWhiteFadeAndSwitch(nextLevelName);
					//Debug.Log("Call Switch Scene " + fadeDuration);
				}	
				//StartCoroutine(SwitchScene(1.0f));
				switchActivated = true;
			}
		}
	}

	/*IEnumerator SwitchScene(float dur) {
		Debug.Log("Switch Scene");
        yield return new WaitForSeconds(dur);
        Application.LoadLevel(nextLevelName);
    }*/

}
