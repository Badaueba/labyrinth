using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public States state;

	void Start () {
		state = States.RUNNING;
	}
		
	public enum States {
		RUNNING,
		GAME_OVER
	}

}