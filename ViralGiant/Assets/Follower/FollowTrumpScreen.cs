using UnityEngine;
using System.Collections;

public class FollowTrumpScreen : MonoBehaviour {

	public Transform player;
	private Vector3 destination;
	private Quaternion targetRotation;
	private bool destinationSet;
	public float speed = 10;
	public float rotationSpeed = 10;
	private Rigidbody2D rigidBody;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	public void SetFocusPoint(Vector3 point) {
		point = Camera.main.WorldToScreenPoint (point);
		destination = Camera.main.WorldToScreenPoint(this.transform.position);
		while (point.x < destination.x - Screen.width / 2) {
			destination.x -= Screen.width;
			destinationSet = true;
		}
		while (point.x > destination.x + Screen.width / 2) {
			destination.x += Screen.width;
			destinationSet = true;
		}
		while (point.y < destination.y - Screen.height / 2) {
			destination.y -= Screen.height;
			destinationSet = true;
		}
		while (point.y > destination.y + Screen.height / 2) {
			destination.y += Screen.height;
			destinationSet = true;
		}
		destination = Camera.main.ScreenToWorldPoint (destination);
	}

	// Update is called once per frame
	void Update () {
		destination = player.position;
		targetRotation = player.rotation;

		Vector3 direction = (destination - transform.position);
		direction.Normalize ();
		rigidBody.AddForce (direction * Time.deltaTime * speed);

//		float step = 5 * Time.deltaTime;
//		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

		float selfAngle = transform.rotation.eulerAngles.z;
		float targetAngle = targetRotation.eulerAngles.z;
		float angleDiff = targetAngle - selfAngle;
		if (angleDiff > 180) {
			angleDiff -= 360;
		} else if (angleDiff < -180) {
			angleDiff += 180;
		}
		//Debug.Log (rigidBody.inertia);
		rigidBody.AddTorque (angleDiff * Time.deltaTime * 0.5F);


//		Quaternion angleDiff = Quaternion.RotateTowards(transform.rotation, targetRotation, .1F);
//		float angle = 0;
//		Vector3 axis = Vector3.zero;
//		angleDiff.ToAngleAxis (out angle, out axis);
//		Debug.Log (angle);
		//rigidBody.AddTorque (rigidBody.inertia * angle * 0.1F);


		//		if (trump != null && !destinationSet) {
//			SetFocusPoint (trump.position);
//		} else {
//			if (Vector3.SqrMagnitude (destination - this.transform.position) > 0.01) {
//				this.transform.position = (destination * 0.2f + this.transform.position * 0.8f);
//			} else {
//				this.transform.position = destination;
//				destinationSet = false;
//			}
//		}
	}
}
