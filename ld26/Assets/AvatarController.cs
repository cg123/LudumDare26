using UnityEngine;
using System.Collections;

public class AvatarController : OVRPlayerController {

	// Initial direction of controller (passed down into CameraController)
	//private Quaternion OrientationOffset = Quaternion.identity;			
	// Rotation amount from inputs (passed down into CameraController)
	//private float YRotation = 0.0f;

	public GameObject fwdDir = null;
	public float moveSpeed = 0.0f;
	public float turnSpeed = 0.0f;
	private CharacterController charController = null;
	private OVRCameraController camController = null;

	new void Awake () {
		base.Awake();
		charController = GetComponent<CharacterController>();
	}

	new void Update () {
		base.Update();
		//float rot = 0.0f;
		//camController.SetYRotation(0.0f);
		//Debug.Log(rot);
		//Vector3 currAngle = camController.transform.eulerAngles;
		//transform.eulerAngles = currAngle;
		float fwd = Input.GetAxis ("Vertical") * moveSpeed;
		float turn = Input.GetAxis ("Horizontal") * turnSpeed;
		charController.Move(fwdDir.transform.forward * fwd * Time.deltaTime);
		//transform.position += transform.forward * fwd * Time.deltaTime;
		fwdDir.transform.Rotate(Vector3.up * turn * Time.deltaTime);
	}


	/*

	void Start () {
		SetCameras();
		InitializeInputs();
	}

	// Use this for initialization


	void OnDrawGizmos () {
		Gizmos.DrawWireSphere(transform.position, 1.0f);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
	}

	// InitializeInputs
	public void InitializeInputs () {
		// Get our start direction
		OrientationOffset = transform.rotation;
		// Make sure to set y rotation to 0 degrees
		YRotation = 0.0f;
	}

	// SetCameras
	public void SetCameras () {
		if(camController != null) {
			// Make sure to set the initial direction of the camera 
			// to match the game player direction
			camController.SetOrientationOffset(OrientationOffset);
			camController.SetYRotation(YRotation);
		}
	}*/

}
