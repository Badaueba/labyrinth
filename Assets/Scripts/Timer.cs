using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public int roomTime = 60;
	public Text timer;
	private GameState gameSate;
	void Awake () {
		gameSate = Component.FindObjectOfType<GameState> ();
	} 
	void Start () {
		StartCoroutine (UpdateTime ());
	}
	IEnumerator UpdateTime () {
		while (roomTime > -1) {
			roomTime--;
			timer.text = "TIME: " + roomTime;
			yield return new WaitForSeconds (1);	
		}

		gameSate.state = GameState.States.GAME_OVER;
		Application.LoadLevel ("gameover");

	}
}
