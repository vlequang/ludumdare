using UnityEngine;
using System.Collections;

public class HeroControl : MonoBehaviour, IGoal {

	private Vector3 moveDirection = Vector3.zero;
	public float speed = 6.0f;
	public float angle = 45.0f;
	Rigidbody2D rigidBody;
	private Vector3 _destination = default(Vector3);

	// Use this for initialization
	void Start () {
		moveDirection = new Vector3();
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		moveDirection.Set (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //moveDirection.Set (0, Input.GetAxis("Vertical"), 0);
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;

//		rigidBody.MoveRotation (- Input.GetAxis("Horizontal") * angle);
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
