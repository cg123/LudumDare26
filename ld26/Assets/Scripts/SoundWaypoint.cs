using UnityEngine;
using System.Collections;

public class SoundWaypoint : MonoBehaviour {
	public AudioClip sound;
	public Vector2 size = new Vector2(1, 1);
	public SoundWaypoint[] connections;
	public float followingVolume = 0.5f;
	
	private SoundFloater floater;
	private bool activated;
	private bool grabbed;
	private float oldVolume;
	
	void Start() {
		gameObject.AddComponent(typeof(BoxCollider));
		GetComponent<BoxCollider>().size = new Vector3(size.x, size.y, 0);
		GetComponent<BoxCollider>().isTrigger = true;
		activated = false;
		grabbed = false;
		if (connections.Length == 0) {
			Activate();
		}
	}
	
	void Activate() {
		GameObject floaterObj = new GameObject(gameObject.name + " floater");
		floaterObj.AddComponent(typeof(SoundFloater));
		floater = floaterObj.GetComponent<SoundFloater>();
		floater.transform.parent = transform;
		floater.transform.localPosition = Vector3.zero;
		floater.audio.clip = sound;
		floater.audio.loop = true;
		floater.audio.Play();
		
		activated = true;
	}
	void Deactivate() {
		floater.audio.Stop();
		Destroy (floater.gameObject);
		floater = null;
		
		grabbed = false;
		activated = false;
	}
	
	void Grab(Transform grabber) {
		floater.transform.parent = grabber;
		floater.transform.localPosition = Vector3.forward;
		activated = false;
		grabbed = true;
		oldVolume = floater.audio.volume;
		floater.audio.volume *= followingVolume;
	}
	void Ungrab() {
		floater.transform.parent = transform;
		floater.transform.localPosition = Vector3.zero;
		activated = true;
		grabbed = false;
		floater.audio.volume = oldVolume;
	}
	
	void OnTriggerEnter(Collider c) {
		if (c.GetComponent<AvatarController>() != null) {
			Vector3 fwd = c.GetComponent<AvatarController>().fwdDir.transform.forward;
			float dot = Vector3.Dot(fwd, transform.forward);
			Debug.Log (dot);
			if (activated && dot > 0) {
				Grab(c.GetComponent<AvatarController>().fwdDir.transform);
				foreach (SoundWaypoint wp in connections) {
					wp.Activate();
				}
			}
			else if (grabbed && dot < 0) {
				Ungrab();
				foreach (SoundWaypoint wp in connections) {
					wp.Deactivate();
				}
			}
		}
	}
	
	void OnDrawGizmos() {
		if (activated) {
			Gizmos.color = Color.green;
		}
		else {
			Gizmos.color = Color.gray;
		}
		Gizmos.DrawWireCube(transform.position, transform.rotation * new Vector3(size.x, size.y, 0));
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, transform.position + transform.forward);
	}
}
