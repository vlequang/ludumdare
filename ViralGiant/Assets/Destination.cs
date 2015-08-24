using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {
	public GameObject Heart;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag=="Virus" && Heart != null) {
			Heart.GetComponent<Animator>().SetTrigger("Win");
		}
	}

}
