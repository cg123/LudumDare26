using UnityEngine;
using System.Collections;

public class DeathFade : MonoBehaviour {

	//private enum FadeTypes {Inward=1, Outward};
	private Texture2D fadeTex;
	
	private float timeElapsed = 0.0f;
	private float startDuration = 0.0f;
	private float pauseDuration = 0.0f;
	private float endDuration = 0.0f;
	//private FadeTypes fadeType = FadeTypes.Inward;

	void Awake () {
		fadeTex = new Texture2D(1, 1);
	}

	void SetTextureColor (Color newScreenOverlayColor) {
		fadeTex.SetPixel(0, 0, newScreenOverlayColor);
		fadeTex.Apply();
	}

	void SideBlinds (float completionAmount) {
		float HALFWIDTH = Mathf.Round(Screen.width/2.0f);
		GUI.DrawTexture(new Rect(0, 0, HALFWIDTH * (1.0f - completionAmount), Screen.height), fadeTex);
		GUI.DrawTexture(new Rect(HALFWIDTH + HALFWIDTH * completionAmount, 0, 
					             HALFWIDTH * (1.0f - completionAmount), Screen.height), fadeTex);
	}

	public void StartDeathFade () {
		SetTextureColor(Color.black);
		timeElapsed = 0.0f;
		startDuration = 1.0f;
		pauseDuration = 2.0f;
		endDuration = 1.0f;
	}

	void OnGUI () {
		timeElapsed += Time.deltaTime;
		if (timeElapsed < startDuration) {
			SideBlinds(1.0f-timeElapsed/startDuration);
		} else if (timeElapsed < startDuration + pauseDuration) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTex);
		} else if (timeElapsed < startDuration + pauseDuration + endDuration) {
			SideBlinds((timeElapsed-startDuration-pauseDuration)/endDuration);
		}

	}
}
