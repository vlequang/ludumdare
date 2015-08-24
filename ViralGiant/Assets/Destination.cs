using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Reached the end!");
	}

}
