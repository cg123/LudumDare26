using UnityEngine;
using System.Collections;

public class CanRespawn : MonoBehaviour {

	public void BeginRespawn () {
		gameObject.SendMessage("Respawn");
	}
}
