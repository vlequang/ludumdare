using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Destination : MonoBehaviour {
	public GameObject Heart;
	public GameObject Movie;
	public float videoDelay = 3f;

	void Start () {
	}


	IEnumerator PlayMovie() {
		yield return new WaitForSeconds(videoDelay);
		if (Movie) {
			Movie.SetActive(true);
			((MovieTexture)Movie.GetComponent<RawImage>().texture).Play();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (Heart) {
			Heart.GetComponent<Animator>().SetTrigger("Win");
			StartCoroutine ("PlayMovie");
		}
	}

}
