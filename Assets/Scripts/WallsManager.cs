using UnityEngine;
using System.Collections;

public class WallsManager : MonoBehaviour {

	public float timeToChange;
	public float minRange;
	public float maxRange;
	public float speed;
	public bool freezeX;
	private Vector3 target;
	private bool canRandomize = true;

	void Awake () {
		float range = Random.Range (minRange, maxRange);
		if (freezeX)
			target = new Vector3 (transform.position.x, 0, range);
		else
			target = new Vector3 (range, 0, transform.position.z);
		
	}
		
		
	void Update () {

		if (transform.position == target && canRandomize) 
			StartCoroutine ( Sort(timeToChange));

		if (target != Vector3.zero) 
			ChangePosition ();
	}

	IEnumerator Sort(float time) {
		canRandomize = false;
		Debug.Log ("Sort");
		float range = Random.Range (minRange, maxRange);
		if (freezeX)
			target = new Vector3 (transform.position.x, 0, range);
		else
			target = new Vector3 (range, 0, transform.position.z);
		yield return new WaitForSeconds (time);
		canRandomize = true;

	} 

	void ChangePosition () {
		transform.position = Vector3.MoveTowards (transform.position, target, 
				speed * Time.deltaTime);
		
	}
}
