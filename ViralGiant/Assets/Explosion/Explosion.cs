using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public GameObject explosionPrefab;


	public void Explode() {
		Instantiate (explosionPrefab, this.transform.position, Quaternion.identity);
	}
}
