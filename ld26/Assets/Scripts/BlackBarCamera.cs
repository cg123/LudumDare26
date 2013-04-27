using UnityEngine;
using System.Collections;

public class BlackBarCamera : OVRCamera {
	
	public Texture2D blackTexture;
	new void Awake() {
		blackTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
		blackTexture.SetPixel(0, 0, Color.black);
		blackTexture.Apply();
		base.Awake();
	}

	private int    	StereoSpreadX 	= -40;
	
	public int displayPixels = 5;
	
	// GUIStereoBox - Values based on pixels in DK1 resolution of W: (1280 / 2) H: 800
	void GUIStereoBox(int X, int Y, int wX, int wY, string text, Color color)
	{
		float ploLeft = 0, ploRight = 0;
		float sSX = (float)Screen.width / 1280.0f;
		
		float sSY = ((float)Screen.height / 800.0f);
		OVRDevice.GetPhysicalLensOffsets(ref ploLeft, ref ploRight); 
		int xL = (int)((float)X * sSX);
		int sSpreadX = (int)((float)StereoSpreadX * sSX);
		int xR = (Screen.width / 2) + xL + sSpreadX - 
			      // required to adjust for physical lens shift
			      (int)(ploLeft * (float)Screen.width / 2);
		int y = (int)((float)Y * sSY);
		
		GUI.contentColor = color;
		
		int sWX = (int)((float)wX * sSX);
		int sWY = (int)((float)wY * sSY);
		
		GUI.DrawTexture(new Rect(xL, y, sWX, sWY), blackTexture);
		GUI.DrawTexture(new Rect(xR, y, sWX, sWY), blackTexture);			
	}
	
	void OnGUI()
	{
		GUIStereoBox(0, 0, 1280, 400 - Mathf.FloorToInt(displayPixels / 2.0f), "", Color.black);
		GUIStereoBox(0, 400 + Mathf.CeilToInt(displayPixels / 2.0f), 1280, 400 - Mathf.CeilToInt(displayPixels / 2.0f), "", Color.black);
	}
}
