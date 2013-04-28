using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	void OnDrawGizmos () {
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, 0.2f);
	}
}
