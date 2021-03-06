using UnityEngine;
using System.Collections;

public class CycleThroughTitleScreens : MonoBehaviour {

	public Texture2D[] screenArray = null;
	public float displayDuration = 0.0f;
	private float elapsedTime = 0.0f;
	private float totalElapsedTime = 0.0f;
	private int currIdx = 0;
	public string nextLevelName = "";
	private Texture2D blackTex = null;
	public AudioClip interruptSound = null;
	private bool isInterrupted = false;

	void Awake () {
		currIdx = 0;
		blackTex = new Texture2D(1,1);
	}

	// Use this for initialization
	void Start () {
		elapsedTime = 0.0f;
		totalElapsedTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetTextureColor (Color newScreenOverlayColor) {
		blackTex.SetPixel(0, 0, newScreenOverlayColor);
		blackTex.Apply();
	}

	void OnGUI () {
		if (totalElapsedTime > 1.0f) {
			if (Input.anyKey && !isInterrupted) {
				audio.Stop();
				audio.clip = interruptSound;
				audio.Play();
				isInterrupted = true;
			}
			if (!audio.isPlaying) {
				Application.LoadLevel(nextLevelName);
			}	
		}

		if (currIdx < screenArray.Length) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), screenArray[Mathf.Min(currIdx, screenArray.Length-1)]);
			SetTextureColor(new Color(0.0f,0.0f,0.0f,elapsedTime/displayDuration));
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTex);
		} else {
			//SetTextureColor(Color.black);
			//GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTex);
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), screenArray[Mathf.Min(currIdx, screenArray.Length-1)]);
		}
		
		if (elapsedTime >= displayDuration) {
			if (screenArray != null) {
				currIdx++;
				if (currIdx >= screenArray.Length) {

				}
				elapsedTime = 0.0f;
			}
		}
		elapsedTime += Time.deltaTime;
		totalElapsedTime += Time.deltaTime;
	}
}
