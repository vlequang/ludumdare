using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public GameObject Heart;
	public int index;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Virus" && Heart != null) {
			switch (index) {
			case 1:
				if (Heart.GetComponent<Animator>().speed == 1f) {
					Heart.GetComponent<Animator>().speed = 1.5f;
					Heart.transform.localScale = new Vector3(1.1f, 1.1f, 0);
				}
				break;
			case 2:
				if (Heart.GetComponent<Animator>().speed == 1.5f) {
					Heart.GetComponent<Animator>().speed = 2f;
					Heart.transform.localScale = new Vector3(1.2f, 1.2f, 0);
				}
				break;
			case 3:
				if (Heart.GetComponent<Animator>().speed == 2f) {
					Heart.GetComponent<Animator>().speed = 2.5f;
					Heart.transform.localScale = new Vector3(1.3f, 1.3f, 0);
				}
				break;
			case 4:
				if (Heart.GetComponent<Animator>().speed == 2.5f) {
					Heart.GetComponent<Animator>().speed = 3f;
					Heart.transform.localScale = new Vector3(1.4f, 1.4f, 0);
				}
				break;
			default:
				break;
			}
		}
	}
}
