using UnityEngine;
using System.Collections;

public class CanRespawn : MonoBehaviour {

	public void BeginRespawn () {
		gameObject.SendMessage("Respawn", SendMessageOptions.DontRequireReceiver);
	}

	public void BeginResume () {
		gameObject.SendMessage("Resume", SendMessageOptions.DontRequireReceiver);
	}
}
