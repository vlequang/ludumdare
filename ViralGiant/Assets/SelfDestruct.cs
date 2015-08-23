using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	Animator animator;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (animator.GetCurrentAnimatorStateInfo (0).normalizedTime > 1) {
			this.GetComponent<Renderer>().enabled = false;
			GameObject.DestroyObject(this.gameObject,3);
		}
	}
}
