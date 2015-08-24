using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Destination : MonoBehaviour {
	public GameObject Heart;
	public GameObject Movie;
	public float videoDelay = 3f;
	public float explodeDelay = 2f;
	public GameObject endingCells;

	void Start () {
	}


	IEnumerator PlayMovie() {
		yield return new WaitForSeconds(videoDelay);
		if (Movie) {
			Movie.SetActive(true);
			((MovieTexture)Movie.GetComponent<RawImage>().texture).Play();
		}
	}

	IEnumerator ExplodeCells() {
		yield return new WaitForSeconds(explodeDelay);
		if (endingCells) {
			foreach (Transform child in endingCells.transform) {
				child.GetComponent<Explosion>().Explode();
				Destroy (child.gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag=="Virus" && Heart != null) {
			Heart.GetComponent<Animator>().SetTrigger("Win");
			StartCoroutine ("ExplodeCells");
			StartCoroutine ("PlayMovie");
		}
	}

}
