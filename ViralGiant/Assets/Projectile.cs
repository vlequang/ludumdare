using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Vector3 direction = Vector3.zero;
	public float speed = 10.0f;
	Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rigidBody.AddForce(direction * speed * Time.deltaTime * 10);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Debug.Log ("Shot!");
		}
	}

}
