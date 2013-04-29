using UnityEngine;
using System.Collections;

public class NeedleController : MonoBehaviour {
	public Transform target = null;
	public float rotationSpeed = 0.0f;
	public float movementSpeed = 0.0f;
	public float confirmationRotation = 1.0f;
	public float chargeTime = 0.5f;
	private float currChargeLevel = 0.0f;
	public enum NeedleState {facing = 0, charging, striking};
	public NeedleState needleState = NeedleState.facing;

	// Use this for initialization
	void Start () {
	
	}
	
	void BeginCharging () {
		currChargeLevel = 0.0f;
		needleState = NeedleState.charging;
	}

	void BeginStriking () {
		needleState = NeedleState.striking;
	}

	void OnTriggerEnter (Collider other) {
		needleState = NeedleState.facing;
	}

	// Update is called once per frame
	void Update () {
		Quaternion targetRotation;
		switch (needleState)
		{
   			case NeedleState.facing:
      			targetRotation = Quaternion.LookRotation(target.position - transform.position);
				transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Mathf.Min (rotationSpeed * Time.deltaTime, 1));
				// In Range?
				if (Mathf.Abs(transform.eulerAngles.y - targetRotation.eulerAngles.y) <= confirmationRotation) {
					BeginCharging();
				}
				break;
			case NeedleState.charging:
				currChargeLevel += Time.deltaTime;
				if (currChargeLevel >= chargeTime) {
					BeginStriking();
				}
				break;
			case NeedleState.striking:
				transform.position += transform.forward * movementSpeed * Time.deltaTime;
				break;
			default:
				break;
		}

	}
}
