using UnityEngine;
using System.Collections;

public class WaypointFollower : MonoBehaviour {

	public Waypoint[] waypointList = null;
	public int firstIdx = 0;
	private int currIdx = 0;
	public float moveSpeed = 0.0f;
	public float confirmationDist = 0.0f;
	public int initialDir = 1;
	private int dir = 1;
	private bool pingPong = true;
	private AudioSource sound = null;

	void Awake () {
		sound = GetComponent<AudioSource>();
		currIdx = firstIdx;
		dir = initialDir;
		if (waypointList[0] == waypointList[waypointList.Length-1]) {
			pingPong = false;
		} else {
			pingPong = true;
		}
	}

	void ReachedWaypoint () {
		if (sound) {
			//sound.Play();
		}
		bool reachedEnd = currIdx + dir > waypointList.Length-1;
		bool reachedStart = currIdx + dir < 0;
		if (reachedStart || reachedEnd) {
			if (pingPong) {
				dir *= -1;
			} else {
				if (dir == -1) {
					currIdx = waypointList.Length-1;		
				} else {
					currIdx = 0;
				}
			}
		}
		currIdx += dir;
	}

	// Update is called once per frame
	void Update () {
		// Got to waypoint?
		if ((transform.position - waypointList[currIdx].gameObject.transform.position).magnitude <= confirmationDist) {
			ReachedWaypoint();		
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

	public void Respawn () {
		currIdx = firstIdx;
		dir = initialDir;
	}

}
