using UnityEngine;
using System.Collections;

public class DustScript : MonoBehaviour {

	//Rigidbody2D rigidBody;
	public Sprite[] possibleSprites;
	private float speed;
	private float moveInterval;
	private Transform player;
	Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		//rigidBody = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Virus").transform;
		moveInterval = Random.Range (1f, 2f);
		if (possibleSprites.Length > 0) {
			GetComponent<SpriteRenderer>().sprite = possibleSprites[Random.Range (0, possibleSprites.Length - 1)];
		}

		moveDirection = new Vector3(Random.Range (-1f, 1f), Random.Range (-1f, 1f), 0);
		StartCoroutine ("move");
	}

	IEnumerator move() 
	{
		while (true) {
			yield return new WaitForSeconds (moveInterval);
			moveDirection = new Vector3(Random.Range (-1f, 1f), Random.Range (-1f, 1f), 0);

			//Vector3 toPlayer = player.position - transform.position;
			//if (toPlayer.magnitude > 5) {
				//moveDirection = toPlayer;
			//}

			//rigidBody.AddForce(moveDirection * Time.deltaTime * speed, ForceMode2D.Impulse);
		}
	}
	
	// Update is called once per frame
	void Update () {
		speed = Random.Range (1f, 2f);
		transform.Translate(moveDirection * Time.deltaTime * speed);
	}
}
