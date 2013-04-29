using UnityEngine;
using System.Collections;

public class BlinkTexture : MonoBehaviour {

	public Texture2D[] texArray = null;
	public float displayDuration = 0.0f;
	private float elapsedTime = 0.0f;
	public int currIdx = 0;

	void Awake () {
		elapsedTime = 0.0f;
		currIdx = 0;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (elapsedTime >= displayDuration) {
			if (texArray != null) {
				renderer.material.mainTexture = texArray[currIdx];
				currIdx++;
				currIdx = currIdx % (texArray.Length);
				elapsedTime = 0.0f;
			}
		}
		elapsedTime += Time.deltaTime;
		
	}
}
