﻿using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	public GameObject bulletPrefeb;
	public GameObject player;
	public float shootInterval = 1f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Virus");
		StartCoroutine ("shoot");
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator shoot() {
		while (true) {
			yield return new WaitForSeconds(shootInterval);
			if (player && bulletPrefeb) {
				Vector3 direction = (player.transform.position - transform.position);
				direction.Normalize();

				GameObject bullet = (GameObject)Instantiate(bulletPrefeb, transform.position, Quaternion.LookRotation(direction));
				bullet.GetComponent<Projectile>().parentCannonCollider = GetComponent<Collider2D>();
				bullet.GetComponent<Projectile>().direction = direction;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Virus" || other.tag=="Follower") {
			this.GetComponent<Explosion>().Explode();
			DestroyObject(this.gameObject);
        }
        //Debug.Log (other);
        //		Destroy(gameObject);
    }


}
