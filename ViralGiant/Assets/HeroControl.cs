using UnityEngine;
using System.Collections;

public class HeroControl : MonoBehaviour, IGoal {

	private Vector3 moveDirection = Vector3.zero;
	public float speed;
	public float angle;
	Rigidbody2D rigidBody;
	private Vector3 _destination = default(Vector3);
	public bool simpleControls;

	// Use this for initialization
	void Start () {
		moveDirection = new Vector3();
		rigidBody = GetComponent<Rigidbody2D> ();
		if (simpleControls) {
			rigidBody.freezeRotation = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (simpleControls) {
			moveDirection.Set (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		} else {
			rigidBody.MoveRotation (rigidBody.rotation - Input.GetAxis("Horizontal") * angle);
			moveDirection.Set (0, Input.GetAxis("Vertical"), 0);
        }
        moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;

		rigidBody.AddForce(moveDirection * Time.deltaTime * 500.0f);
	}

	public Vector3 destination {
		get {
			return _destination;
		}
	}
	public bool AtDestination() {
		return Vector3.SqrMagnitude (destination - this.transform.position) < 0.001;
	}

}
