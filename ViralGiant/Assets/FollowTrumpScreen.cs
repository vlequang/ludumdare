using UnityEngine;
using System.Collections;

public class FollowTrumpScreen : MonoBehaviour {

	public Transform trump;
	private Vector3 destination;
	private bool destinationSet;

	void Start() {
		trump = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}

	public void SetFocusPoint(Vector3 point) {
		point = Camera.main.WorldToScreenPoint (point);
		destination = Camera.main.WorldToScreenPoint(this.transform.position);
		while (point.x < destination.x - Screen.width / 2) {
			destination.x -= Screen.width;
			destinationSet = true;
		}
		while (point.x > destination.x + Screen.width / 2) {
			destination.x += Screen.width;
			destinationSet = true;
		}
		while (point.y < destination.y - Screen.height / 2) {
			destination.y -= Screen.height;
			destinationSet = true;
		}
		while (point.y > destination.y + Screen.height / 2) {
			destination.y += Screen.height;
			destinationSet = true;
		}
		destination = Camera.main.ScreenToWorldPoint (destination);
	}

	// Update is called once per frame
	void Update () {
		if (trump != null && !destinationSet) {
			SetFocusPoint (trump.position);
		} else {
			if (Vector3.SqrMagnitude (destination - this.transform.position) > 0.01) {
				this.transform.position = (destination * 0.2f + this.transform.position * 0.8f);
			} else {
				this.transform.position = destination;
				destinationSet = false;
			}
		}
	}
}
