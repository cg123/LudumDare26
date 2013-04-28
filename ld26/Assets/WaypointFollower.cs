using UnityEngine;
using System.Collections;

public class WaypointFollower : MonoBehaviour {

	public Waypoint[] waypointList = null;
	private int currIdx = 0;
	public float moveSpeed = 0.0f;
	public float confirmationDist = 0.0f;
	public int dir = 1;

	// Update is called once per frame
	void Update () {
		// Got to waypoint?
		if ((transform.position - waypointList[currIdx].gameObject.transform.position).magnitude <= confirmationDist) {
			
			if (currIdx + dir < 0 || currIdx + dir > waypointList.Length-1) {
				dir *= -1;
			}
			currIdx += dir;
			
		} else {
			transform.position += (waypointList[currIdx].gameObject.transform.position - transform.position) * Time.deltaTime * moveSpeed;
			transform.LookAt(waypointList[currIdx].gameObject.transform.position);
		}
	}

	void OnDrawGizmos () {
		for (int i = 1; i < waypointList.Length; i++) {
			if (waypointList[i] != null) {
				Gizmos.DrawLine(waypointList[i-1].gameObject.transform.position, waypointList[i].gameObject.transform.position);
			}
		}
	}	

}
