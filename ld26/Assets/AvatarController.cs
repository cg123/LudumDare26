using UnityEngine;
using System.Collections;

public class AvatarController : MonoBehaviour {
	public GameObject fwdDir = null;
	public float moveSpeed = 0.0f;
	public float turnSpeed = 0.0f;
	private CharacterController charController = null;
	private OVRCameraController camController = null;
	private float yRotOffset = 0.0f;

	void Awake () {
		charController = GetComponent<CharacterController>();
		camController = GetComponentInChildren<OVRCameraController>();
	}

	void Update () {
		float fwd = Input.GetAxis ("Vertical") * moveSpeed;
		float turn = Input.GetAxis ("Horizontal") * turnSpeed;
		charController.Move(fwdDir.transform.forward * fwd * Time.deltaTime);
		
		fwdDir.transform.rotation = camController.gameObject.transform.rotation;
		camController.SetYRotation(yRotOffset);
		yRotOffset += turn * Time.deltaTime;
	}
}
