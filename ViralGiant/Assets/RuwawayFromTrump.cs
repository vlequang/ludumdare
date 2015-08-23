﻿using UnityEngine;
using System.Collections;

public class RuwawayFromTrump : MonoBehaviour {

	public Transform trump;
	public float sightDistance;
	public float repelDistance;
	Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		trump = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();

	}

	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (trump.position, this.transform.position);
		if (distance < sightDistance) {
			Vector3 repel = this.transform.position - trump.position;
			repel.Normalize ();
			rigidBody.AddRelativeForce(repel * Time.deltaTime * repelDistance);
			//Debug.Log ("I see trump!");
		} else {

		}
	}
}
