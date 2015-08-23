using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

	public Transform trump;
	Rigidbody2D rigidBody;
	public float trumpTooFar;
	public float trumpTooClose;
	public float followSpeed;
	public bool found;

	void Start() {
		trump = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		rigidBody = GetComponent<Rigidbody2D> ();
		trumpTooFar += Random.Range (-.5f, .5f);
		trumpTooClose += Random.Range (-.5f, .5f);
		followSpeed += Random.Range (-200f, 200f);
	}

	// Update is called once per frame
	void Update () {
		if (found) {
			{
				float distance = Vector3.Distance (trump.position, this.transform.position);
				if (distance > trumpTooFar) {
					Vector3 attract = trump.position - this.transform.position;
					rigidBody.AddRelativeForce (attract * Time.deltaTime * followSpeed);
				} else if (distance < trumpTooClose) {
					Vector3 repel = this.transform.position - trump.position;
					rigidBody.AddRelativeForce (repel * Time.deltaTime * followSpeed);
				}
			}

			Follower[] followers = GameObject.FindObjectsOfType<Follower> ();
			Follower otherFollower = followers[Random.Range(0,followers.Length)];
			if (otherFollower != this) {
				float distance = Vector3.Distance (otherFollower.rigidBody.position, this.transform.position);
				if (distance < trumpTooClose) {
					Vector3 repel = this.rigidBody.position - otherFollower.rigidBody.position;
                    rigidBody.AddRelativeForce (repel * Time.deltaTime * followSpeed/2);
                }
            }

            rigidBody.AddRelativeForce (Random.insideUnitCircle * 100);
		} else {
			float distance = Vector3.Distance (trump.position, this.transform.position);
			if (distance < 10) {
				found = true;
			}
            rigidBody.AddRelativeForce (Random.insideUnitCircle * 30);
		}
    }
}
