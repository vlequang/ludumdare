using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

	public Transform trump;
	Rigidbody2D rigidBody;
	public float trumpTooFar;
	public float trumpTooClose;
	public float followSpeed;
	public bool found;
	public Vector3 offset;
	public int death = 0;
	private Vector2 orgPosition;

	void Start() {
		trump = GameObject.FindGameObjectWithTag ("Virus").GetComponent<Transform>();
		rigidBody = GetComponent<Rigidbody2D> ();
		trumpTooFar += Random.Range (-.5f, .5f);
		trumpTooClose += Random.Range (-.5f, .5f);
		followSpeed += Random.Range (-200f, 200f);
		orgPosition = rigidBody.position;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (this.death>0) {
			return;
		}
		if (other.tag == "Bullet") {
			this.death = 300;
			found = false;
			this.GetComponent<Explosion>().Explode();
			Destroy (other);
			this.GetComponents<AudioSource>()[1].Play ();
		}
		//Debug.Log (other);
		//		Destroy(gameObject);
	}


	void FixedUpdate() {
		if (death > 0) {
			//Debug.Log (death);
			this.GetComponent<Renderer>().enabled = false;
			death--;
			if (death == 0) {
				this.GetComponent<Renderer>().enabled = true;
				rigidBody.MovePosition(orgPosition);
				found = false;
			}
			return;
		}
	}


	// Update is called once per frame
	void Update () {
		if (death > 0) {
			return;
		}
		if (found) {
			{
				Vector3 destination = trump.position + offset;

				float distance = Vector3.Distance (destination, this.transform.position);
				if (distance > trumpTooFar) {
					Vector3 attract = destination - this.transform.position;
					rigidBody.AddRelativeForce (attract * Time.deltaTime * followSpeed);
				} else if (distance < trumpTooClose) {
					Vector3 repel = this.transform.position - trump.position;
					rigidBody.AddRelativeForce (repel * Time.deltaTime * followSpeed*5);
				} else {
					offset = Random.insideUnitCircle * Vector3.Distance (trump.position, this.transform.position);;
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
				this.GetComponents<AudioSource>()[0].Play ();
			}
            rigidBody.AddRelativeForce (Random.insideUnitCircle * 30);
		}
    }
}
