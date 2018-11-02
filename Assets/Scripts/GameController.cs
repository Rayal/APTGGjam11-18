using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public enum PlayMode
    {
        REAL_TIME,
        TURN_BASED
    }

    private static GameController instance;

    private PlayMode playMode = PlayMode.REAL_TIME;

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
}
