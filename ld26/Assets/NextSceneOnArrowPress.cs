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
				for (int i = 0; i < fadeCpts.Length; i++) {
					float fadeDuration = fadeCpts[i].StartWhiteFade();
					Debug.Log("Call Switch Scene " + fadeDuration);
					SwitchScene(fadeDuration);
				}	
				switchActivated = true;
			}
		}
	}

	IEnumerator SwitchScene(float dur) {
		Debug.Log("Switch Scene");
        yield return new WaitForSeconds(dur);
        Application.LoadLevel(nextLevelName);
    }

}
