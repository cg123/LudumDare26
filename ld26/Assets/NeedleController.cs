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
	private Rigidbody rigidBody = null;
	private BoxCollider boxCollider = null;

	void Awake () {
		rigidBody = gameObject.GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	void BeginCharging () {
		currChargeLevel = 0.0f;
		needleState = NeedleState.charging;
	}

	void BeginStriking () {
		needleState = NeedleState.striking;
		rigidBody.AddForce(transform.forward * movementSpeed);
	}

	void BeginFacing () {
		needleState = NeedleState.facing;
	}

	void OnCollisionEnter(Collision collision) {
		BeginFacing();
	}

	// Update is called once per frame
	void Update () {
		Quaternion targetRotation;
		switch (needleState)
		{
   			case NeedleState.facing:
				rigidBody.velocity = new Vector3(0,0,0);
				rigidBody.angularVelocity = new Vector3(0,0,0);
      			targetRotation = Quaternion.LookRotation(new Vector3(target.position.x,0,target.position.z) - new Vector3(transform.position.x,0,transform.position.z));
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
				//transform.position += transform.forward * movementSpeed * Time.deltaTime;
				break;
			default:
				break;
		}

	}

	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 1.0f);
		Gizmos.color = Color.black;
		Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
		Gizmos.matrix = rotationMatrix;

		if (boxCollider == null) {
			boxCollider = gameObject.GetComponent<BoxCollider>();
		}
		Gizmos.DrawCube(boxCollider.center, boxCollider.size);
		
	}
}
