using UnityEngine;
using System.Collections;

public class AvatarController : MonoBehaviour {
	public GameObject riftCam = null;
	public GameObject stdCam = null;
	public GameObject fwdDir = null;
	public float moveSpeed = 0.0f;
	public float turnSpeed = 0.0f;
	private CharacterController charController = null;
	private OVRCameraController camController = null;
	public float yRotOffset = 0.0f;

	void Awake () {
		if (PlayerPrefs.HasKey("UseRift")) {
			SwitchToRiftCam();
		} else {
			SwitchToStandardCam();
		}

		yRotOffset = transform.eulerAngles.y;

		charController = GetComponent<CharacterController>();
	}

	private void SwitchToStandardCam () {
		riftCam.SetActive(false);
		stdCam.SetActive(true);
		camController = null;
	}

	private void SwitchToRiftCam () {
		riftCam.SetActive(true);
		stdCam.SetActive(false);
		camController = GetComponentInChildren<OVRCameraController>();
	}

	void Update () {
		float fwd = Input.GetAxis ("Vertical") * moveSpeed;
		float turn = Input.GetAxis ("Horizontal") * turnSpeed;
		charController.Move(fwdDir.transform.forward * fwd * Time.deltaTime);
		
		if (camController != null) {
			fwdDir.transform.rotation = camController.gameObject.transform.rotation;
			camController.SetYRotation(yRotOffset);	
		} else {
			Vector3 desOrientation = new Vector3(0.0f, yRotOffset, 0.0f);
			fwdDir.transform.eulerAngles = desOrientation;
			stdCam.transform.eulerAngles = desOrientation;
		}
		
		yRotOffset += turn * Time.deltaTime;
	}
}
