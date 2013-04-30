using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {
	public string nextLevelName = "";

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player")) {
			Instantiate(Resources.Load("OneTimeSuccess"));
			if (nextLevelName != "") {
				if (nextLevelName == "ClosingScreen") {
					foreach (DeathFade fade in other.GetComponentsInChildren<DeathFade>()) {
						fade.StartWhiteFade(true);
					}
				}
				Application.LoadLevel(nextLevelName);	
			}
		}
	}
}
