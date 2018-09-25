using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpring : MonoBehaviour {

	public GameObject collider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject == collider) {
			HingeJoint hinge = GetComponent<HingeJoint> ();
			hinge.useSpring = false;
			Debug.Log ("False");
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject == collider) {
			HingeJoint hinge = GetComponent<HingeJoint> ();
			hinge.useSpring = true;
			Debug.Log ("True");
		}
	}
}
