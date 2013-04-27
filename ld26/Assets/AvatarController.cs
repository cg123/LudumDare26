using UnityEngine;
using System.Collections;

public class AvatarController : MonoBehaviour {

	// Initial direction of controller (passed down into CameraController)
	//private Quaternion OrientationOffset = Quaternion.identity;			
	// Rotation amount from inputs (passed down into CameraController)
	//private float YRotation = 0.0f;

	//public GameObject fwdDir = null;
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
		//float rot = 0.0f;
		//camController.SetYRotation(0.0f);
		//Debug.Log(rot);
		//Vector3 currAngle = camController.transform.eulerAngles;
		//transform.eulerAngles = currAngle;
		float fwd = Input.GetAxis ("Vertical") * moveSpeed;
		float turn = Input.GetAxis ("Horizontal") * turnSpeed;
		charController.Move(transform.forward * fwd * Time.deltaTime);
		
		transform.eulerAngles = camController.gameObject.transform.localRotation.eulerAngles + new Vector3(0.0f,yRotOffset,0.0f);
		//transform.position += transform.forward * fwd * Time.deltaTime;
		yRotOffset += turn * Time.deltaTime;
		//fwdDir.transform.Rotate(Vector3.up * );
	}
}
