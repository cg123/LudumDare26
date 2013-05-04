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
	private float initialYRotOffset = 0.0f;
	private bool movementEnabled = true;

	void Awake () {
		movementEnabled = true;
		if (PlayerPrefs.HasKey("UseRift")) {
			SwitchToRiftCam();
		} else {
			SwitchToStandardCam();
		}

		yRotOffset = transform.eulerAngles.y;
		initialYRotOffset = yRotOffset;

		charController = gameObject.GetComponent<CharacterController>();
	}

	private void SwitchToStandardCam () {
		riftCam.SetActive(false);
		stdCam.SetActive(true);
		camController = null;
	}

	private void SwitchToRiftCam () {
		riftCam.SetActive(true);
		stdCam.SetActive(false);
		camController = gameObject.GetComponentInChildren<OVRCameraController>();
	}

	void Update () {
			float fwd = 0.0f;
			float turn = 0.0f;

			if (movementEnabled) {
				fwd = Input.GetAxis ("Vertical") * moveSpeed;
				turn = Input.GetAxis ("Horizontal") * turnSpeed;
			}
			
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

	public void Respawn () {
		yRotOffset = initialYRotOffset;
		movementEnabled = false;
	}

	public void Resume () {
		movementEnabled = true;
	}
}
