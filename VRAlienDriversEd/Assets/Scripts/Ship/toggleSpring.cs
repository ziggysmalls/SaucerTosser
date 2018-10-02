using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleSpring : MonoBehaviour {

	public GameObject triggerObject;

	bool springActive = true;

	HingeJoint hinge;
	// Use this for initialization
	void Start () {
		hinge = GetComponent<HingeJoint> ();
	}

	void OnCollisionEnter( Collider col){
		if (col == triggerObject) {
			hinge.useSpring = false;
			Debug.Log ("FIRING");
		}
	}

	void OnCollisionLeave (Collider col){
		if (col == triggerObject) {
			hinge.useSpring = true;
		}
	}

	void Update(){
		//Debug.Log (hinge.useSpring);
	}
}
