﻿using UnityEngine;
using System.Collections;

public class HeroControl : MonoBehaviour, IGoal {

	private Vector3 moveDirection = Vector3.zero;
	public float speed;
	public float angle;
	Rigidbody2D rigidBody;
	private Vector3 _destination = default(Vector3);
	public bool simpleControls;
	public int death = 0;
	private Vector2 orgPosition;
	public int born = 0;
	Animator animator;

	// Use this for initialization
	void Start () {
		moveDirection = new Vector3();
		rigidBody = GetComponent<Rigidbody2D> ();
		if (simpleControls) {
			//rigidBody.freezeRotation = true;
		}
		orgPosition = rigidBody.position;
		born = 100;

		animator = GetComponent<Animator>();
	}

	void birth() {
		GetComponents<AudioSource>()[1].Play();
		GetComponents<AudioSource> () [3].Play ();
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (this.death>0 || born>0) {
			return;
		}
		if (other.tag == "Bullet" && other.GetComponent<Projectile>().lifeTime > other.GetComponent<Projectile>().initialTime ) {
			this.death = 300;
			Destroy (other);

			Follower[] followers = GameObject.FindObjectsOfType<Follower> ();
			for (int i=0 ; i<followers.Length; i++) {
				if(followers[i].found) {
					followers[i].death = 300;
				}
			}

			GetComponent<Explosion>().Explode();
			GetComponents<AudioSource>()[0].Play();
			GetComponents<AudioSource> () [3].Pause();
        }
		//Debug.Log (other);
		//		Destroy(gameObject);
	}



	void FixedUpdate() {
		if (born > 0) {
			born--;
			return;
		}
		if (death > 0) {
			//Debug.Log (death);
			this.GetComponent<Renderer>().enabled = false;
			death--;
			if (death == 0) {
				this.GetComponent<Renderer>().enabled = true;
//				rigidBody.MovePosition(orgPosition);
				born = 100;
				birth();
			}
			return;
		}
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (death + ", " + born);
		if (death > 0) {
			return;
		}
		if (simpleControls) {
			moveDirection.Set (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		} else {
			rigidBody.MoveRotation (rigidBody.rotation - Input.GetAxis("Horizontal") * angle);
			moveDirection.Set (0, Input.GetAxis("Vertical"), 0);
        }
        moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;


		//rigidBody.isKinematic = false;
		rigidBody.AddForce(moveDirection * Time.deltaTime * 500.0f);
		//rigidBody.isKinematic = true;

		if (animator) {
			if (animator.GetBool("Swimming") == false && (Input.GetAxis ("Vertical") != 0)) {
				animator.SetBool("Swimming", true);
			} else if (animator.GetBool("Swimming") && Input.GetAxis ("Vertical") == 0) {
				animator.SetBool("Swimming", false);
			}
		}

//		if (Input.GetKeyDown ("space") && Time.frameCount > lastTrigger + 10) {
//			lastTrigger = Time.frameCount;
//			GetComponents<AudioSource>()[2].Play();
//        }
	}

	static int lastTrigger = 0;

	public Vector3 destination {
		get {
			return _destination;
		}
	}
	public bool AtDestination() {
		return Vector3.SqrMagnitude (destination - this.transform.position) < 0.001;
	}
}
