using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {

	private Animator anim;

	private Vector3 lastPos;
	private float lastSpeed;
	public float velocityMultiplier = 20f;
	public float interpolationFactor = 30f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		lastPos = transform.position;
		lastSpeed = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		Vector3 velocity = pos - lastPos;
		Vector3 direction = velocity.normalized;
	

		Vector3 localVel = transform.InverseTransformDirection (velocity);

		//handle the fact that the avatars are flipped 180 in Y (necessary because vives are wierd)
		localVel = -localVel;

		if (localVel.z > 0) {
			print ("forward:" + localVel.z);
		} else if (localVel.z < 0) {
			print ("backward:" + localVel.z);
		}

		float speed = localVel.z * velocityMultiplier;
		speed = Mathf.Clamp (speed, -1, 1);

		speed = Mathf.Lerp (lastSpeed, speed, Time.deltaTime * interpolationFactor);
		anim.SetFloat ("Speed", speed);

		lastSpeed = speed;
		lastPos = pos;
	}
}
