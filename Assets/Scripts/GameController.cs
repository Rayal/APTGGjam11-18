using System;
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
		if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0
            || GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            Application.Quit();
        }
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
        if (turn < TurnStatus.ENEMY_PLAYER_TRANSITION)
        {
            turn++;
        }
        else
        {
            turn = TurnStatus.PLAYER_TURN;
        }

        if (turn.Equals(TurnStatus.PLAYER_ENEMY_TRANSITION))
        {
            StartCoroutine(DelayTwoSecondsThenSuspendPhysics(1));
        }
        else if (turn.Equals(TurnStatus.ENEMY_PLAYER_TRANSITION))
        {
            StartCoroutine(DelayTwoSecondsThenSuspendPhysics(2));
        }
    }

    public void PlayerHit()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    public void PlayerSeen()
    {
        playMode = PlayMode.TURN_BASED;
        Physics2D.autoSimulation = false;
    }

    IEnumerator DelayTwoSecondsThenSuspendPhysics(float time)
    {
        yield return new WaitForSeconds(time);
        Physics2D.autoSimulation = false;
        EndTurn();
    }
}
