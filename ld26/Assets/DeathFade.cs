using UnityEngine;
using System.Collections;

public class DeathFade : MonoBehaviour {

	//private enum FadeTypes {Inward=1, Outward};
	private Texture2D fadeTex;
	
	private bool reverse = false;
	private bool vertical = false;
	private float timeElapsed = 0.0f;
	private float startDuration = 0.0f;
	private float pauseDuration = 0.0f;
	private float endDuration = 0.0f;
	//private FadeTypes fadeType = FadeTypes.Inward;
	private string goalLevel = "";

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
	void VerticalBlinds (float completionAmount) {
		float HALFHEIGHT = Mathf.Round(Screen.height/2.0f);
		GUI.DrawTexture(new Rect(0, 0, Screen.width, HALFHEIGHT * (1.0f - completionAmount)), fadeTex);
		GUI.DrawTexture(new Rect(0, HALFHEIGHT + HALFHEIGHT * completionAmount, Screen.width,
					             HALFHEIGHT * (1.0f - completionAmount)), fadeTex);
	}
	
	void Blinds(float completionAmount) {
		float realTime;
		if (reverse) {
			realTime = 1.0f - completionAmount;
		}
		else {
			realTime = completionAmount;
		}
		if (vertical) {
			VerticalBlinds(realTime);
		}
		else {
			SideBlinds(realTime);
		}
	}

	public void StartDeathFade () {
		SetTextureColor(Color.black);
		vertical = false;
		timeElapsed = 0.0f;
		startDuration = 1.0f;
		pauseDuration = 2.0f;
		endDuration = 1.0f;
		goalLevel = "";
	}

	public void StartWhiteFadeAndSwitch (string level, bool reverse = false) {
		this.reverse = reverse;
		vertical = true;
		SetTextureColor(Color.white);
		timeElapsed = 0.0f;
		startDuration = 1.0f;
		pauseDuration = 2.0f;
		endDuration = 1.0f;
		goalLevel = level;
	}

	public float StartWhiteFade (bool reverse=false) {
		this.reverse = reverse;
		vertical = true;
		SetTextureColor(Color.white);
		timeElapsed = 0.0f;
		startDuration = 1.0f;
		pauseDuration = 2.0f;
		endDuration = 1.0f;
		return startDuration+pauseDuration+endDuration;
	}

	void OnGUI () {
		timeElapsed += Time.deltaTime;
		if (timeElapsed < startDuration) {
			Blinds(1.0f-timeElapsed/startDuration);
		} else if (timeElapsed < startDuration + pauseDuration) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTex);
		} else if (timeElapsed < startDuration + pauseDuration + endDuration) {
			if (goalLevel != "") {
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTex);
				Application.LoadLevel(goalLevel);
			}
			Blinds((timeElapsed-startDuration-pauseDuration)/endDuration);
		}

	}
}
