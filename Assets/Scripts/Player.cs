using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed;
	Rigidbody body;
	GameState gameState;
	void Awake () {
		gameState = Component.FindObjectOfType<GameState> ();
		body = GetComponent<Rigidbody> ();
	}

	void Update () {
		if (gameState.state == GameState.States.RUNNING)
			Move ();
	}
	void Move() { 
		body.velocity = new Vector3(Input.GetAxis("Horizontal"),
			0,Input.GetAxis("Vertical")) * Time.deltaTime * speed;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.transform.tag == "end")
			Application.LoadLevel ("victory");
		Debug.Log ("collision");
	}
}
