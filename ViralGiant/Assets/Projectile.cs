using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Vector3 direction = Vector3.zero;
	public float speed = 10.0f;
	Rigidbody2D rigidBody;
	public Collider2D parentCannonCollider;
	public float lifeTime = 10f;
	private float livedTime = 0.0f;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		rigidBody.AddForce(direction * speed * Time.deltaTime * 20);

		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		livedTime += Time.deltaTime;
		if (livedTime >= lifeTime) {

			//Debug.Log ("ExpireDestroy");
			Destroy(gameObject);
		}
	}

/*	void OnTriggerEnter2D(Collider2D other) {
		if (parentCannonCollider && other == parentCannonCollider) {
			return;
		}
		if (other.tag == "Player") {
			other.GetComponent<HeroControl>().death = 300;
			Debug.Log ("Shot!");
		}
		if (other.tag == "Follower") {
			other.GetComponent<HeroControl>().death = 300;
			Debug.Log ("Shot follower!");
		}
		Debug.Log (other);
		Destroy(gameObject);
	}*/

}
