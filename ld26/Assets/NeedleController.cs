using UnityEngine;
using System.Collections;

public class NeedleController : MonoBehaviour {
	public Transform target = null;
	public float rotationSpeed = 0.0f;
	public float movementSpeed = 0.0f;
	public float confirmationRotation = 1.0f;
	public float chargeTime = 0.5f;
	private float currChargeLevel = 0.0f;
	
	public float recoverTime = 2.0f;
	private float currRecoverTime = 0.0f;
	
	public AudioClip chargingSound = null;
	public AudioClip strikingSound = null;
	public enum NeedleState {facing = 0, charging, striking, recovering};
	public NeedleState needleState = NeedleState.facing;
	private Rigidbody rigidBody = null;
	private BoxCollider boxCollider = null;

	void Respawn () {
		needleState = NeedleState.recovering;
		currRecoverTime = 0.0f;
		currChargeLevel = 0.0f;
	}

	void Awake () {
		rigidBody = gameObject.GetComponent<Rigidbody>();
	}
	
	void BeginCharging () {
		currChargeLevel = 0.0f;
		needleState = NeedleState.charging;
		audio.clip = chargingSound;
		audio.Play();
		//AudioSource.PlayClipAtPoint(chargingSound, transform.position);
	}

	void BeginStriking () {
		needleState = NeedleState.striking;
		rigidBody.AddForce(transform.forward * movementSpeed);
		audio.clip = strikingSound;
		audio.Play();
		//AudioSource.PlayClipAtPoint(strikingSound, transform.position);
	}

	void BeginFacing () {
		needleState = NeedleState.facing;
	}

	void BeginRecovering () {
		needleState = NeedleState.recovering;
		currRecoverTime = 0.0f;
	}

	void OnCollisionEnter(Collision collision) {
		BeginRecovering();
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
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Mathf.Min (rotationSpeed * Time.deltaTime, 1));
				// In Range?
				if (Mathf.Abs(transform.eulerAngles.y - targetRotation.eulerAngles.y) <= confirmationRotation) {
					transform.rotation = targetRotation;
					BeginCharging();
				}
				break;
			case NeedleState.charging:
				//currChargeLevel += Time.deltaTime;
				if (!audio.isPlaying) {
				//if (currChargeLevel >= chargeTime) {
					BeginStriking();
				}
				break;
			case NeedleState.striking:
				//transform.position += transform.forward * movementSpeed * Time.deltaTime;
				break;
			case NeedleState.recovering:
				rigidBody.velocity = new Vector3(0,0,0);
				rigidBody.angularVelocity = new Vector3(0,0,0);
				currRecoverTime += Time.deltaTime;
				if (currRecoverTime >= recoverTime) {
					BeginFacing();
				}
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
