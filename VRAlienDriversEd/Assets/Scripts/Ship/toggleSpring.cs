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

	void OnCollisionEnter( Collision col){
		if (col.gameObject == triggerObject) {
			hinge.useSpring = false;
			Debug.Log ("FIRING");
		}
	}

	void OnCollisionLeave (Collision col){
		if (col.gameObject == triggerObject) {
			hinge.useSpring = true;
		}
	}

	void Update(){
		//Debug.Log (hinge.useSpring);
	}
}
