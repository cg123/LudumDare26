using UnityEngine;
using System.Collections;

public class ShowFwdDir : MonoBehaviour {

	void OnDrawGizmos () {
		Gizmos.DrawWireSphere(transform.position, 1.0f);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
	}

}
