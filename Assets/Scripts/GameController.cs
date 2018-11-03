using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public enum PlayMode
    {
        REAL_TIME,
        TURN_BASED
    }

    public enum TurnStatus
    {
        PLAYER_TURN,
        PLAYER_ENEMY_TRANSITION,
        ENEMY_TURN,
        ENEMY_PLAYER_TRANSITION
    }

    public static GameController instance;

    public PlayMode playMode = PlayMode.REAL_TIME;
    public TurnStatus turn = TurnStatus.PLAYER_TURN;

    // Use this for initialization
    private void Awake () {
		if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public PlayMode GetPlayMode()
    {
        return playMode;
    }

    public TurnStatus GetTurn()
    {
        return turn;
    }

    public void EndTurn()
    {
        turn++;
        if (turn.Equals(TurnStatus.ENEMY_PLAYER_TRANSITION) || turn.Equals(TurnStatus.PLAYER_ENEMY_TRANSITION))
        {
            StartCoroutine(DelayTwoSecondsThenSuspendPhysics());
        }
    }

    public void PlayerSeen()
    {
        playMode = PlayMode.TURN_BASED;
        Physics2D.autoSimulation = false;
    }

    IEnumerator DelayTwoSecondsThenSuspendPhysics()
    {
        yield return new WaitForSeconds(1);
        EndTurn();
        Physics2D.autoSimulation = false;
    }
}
