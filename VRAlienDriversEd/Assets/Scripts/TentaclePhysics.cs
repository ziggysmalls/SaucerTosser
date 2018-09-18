using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaclePhysics : MonoBehaviour {

	public float speed = 5;
	public Transform target;
	
	// Update is called once per frame
	void Update () {

		float step = speed * Time.deltaTime;
		gameObject.transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}
}
