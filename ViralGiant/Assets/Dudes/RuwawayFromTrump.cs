using UnityEngine;
using System.Collections;

public class RuwawayFromTrump : MonoBehaviour {

	public Transform trump;
	public float sightDistance;
	public float repelDistance;
	Rigidbody2D rigidBody;
	Vector2 randomMovement;
	bool scared = false;
	public int death = 0;
	private Vector2 orgPosition;
	private AudioSource firedAudio;
	private AudioSource loserAudio;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		trump = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		orgPosition = rigidBody.position;
		firedAudio = GetComponents<AudioSource> ()[0];
		loserAudio = GetComponents<AudioSource> () [1];
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Collider2D other = collision.collider;
		if (this.death>0) {
			return;
		}
		if (other.tag == "Player" || other.tag == "Follower") {
			this.death = 300;
			this.GetComponent<Explosion>().Explode();
			if (other.tag == "Player") {
				firedAudio.Play();
			} else {
				loserAudio.Play ();
			}
		}
//		Debug.Log (other);
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
			}
			return;
		}
	}


	// Update is called once per frame
	void Update () {
		if (death > 0) {
			return;
		}
		float distance = Vector3.Distance (trump.position, this.transform.position);
		if (distance < sightDistance) {
			Vector3 repel = this.transform.position - trump.position;
			repel.Normalize ();
			rigidBody.AddRelativeForce (repel * Time.deltaTime * repelDistance);
			scared = true;
//			Debug.Log ("I see trump!");
		} else if (scared) {
			if(rigidBody.velocity.magnitude < .01f) {
				scared = false;
            }
        } else {
			if (Random.value < .005) {
				randomMovement = Random.insideUnitCircle;
            }
			rigidBody.AddRelativeForce(randomMovement * 50f);
        }
	}
}
