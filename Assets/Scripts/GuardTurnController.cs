using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardTurnController : MonoBehaviour {
    public enum GuardIntent
    {
        SHOOT,
        PURSUE
    }

    public GuardIntent intent;
    public GameObject target;

    private Pursue pursuitController;

	void Start () {
        pursuitController = GetComponent<Pursue>();
	}
	
	void FixedUpdate () {
        if (GameController.instance.GetPlayMode().Equals(GameController.PlayMode.TURN_BASED)
            && GameController.instance.GetTurn().Equals(GameController.TurnStatus.ENEMY_TURN))
        {
            Physics2D.autoSimulation = true;
            if (intent.Equals(GuardIntent.PURSUE))
            {
                pursuitController.enabled = true;
                pursuitController.target = target;
                GameController.instance.EndTurn();
            }
        }
        else if (GameController.instance.GetPlayMode().Equals(GameController.PlayMode.TURN_BASED)
            && GameController.instance.GetTurn().Equals(GameController.TurnStatus.PLAYER_TURN))
        {
            pursuitController.enabled = false;
        }
	}
}
