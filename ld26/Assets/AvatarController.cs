using UnityEngine;
using System.Collections;

public class AvatarController : MonoBehaviour {

	public float moveSpeed = 0.0f;
	public float turnSpeed = 0.0f;
	public GameObject camController = null;
	private CharacterController charController = null;

	void Awake () {
		charController = GetComponent<CharacterController>();
	}

	// Use this for initialization
	void Update () {
		//Vector3 currAngle = camController.transform.eulerAngles;
		//transform.eulerAngles = currAngle;
		float fwd = Input.GetAxis ("Vertical") * moveSpeed;
		float turn = Input.GetAxis ("Horizontal") * turnSpeed;
		charController.Move(transform.forward * fwd * Time.deltaTime);
		//transform.position += transform.forward * fwd * Time.deltaTime;
		transform.Rotate(Vector3.up * turn * Time.deltaTime);
	}

	void OnDrawGizmos () {
		Gizmos.DrawWireSphere(transform.position, 1.0f);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
	}

}
