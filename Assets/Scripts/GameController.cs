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
        ENEMY_TURN
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
    }
}
