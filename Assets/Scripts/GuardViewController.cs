using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardViewController : MonoBehaviour {

    private const int playerActiveLayerMask = 1 << 8;

    private GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (player != null)
        {
            FindPlayerInLOS();
        }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player = collision.gameObject;
        }
    }

    private void FindPlayerInLOS()
    {
        Vector2 rayCastDirection = player.transform.position - transform.position;
        if (transform.lossyScale.x < 0 ^ rayCastDirection.x < 0)
        {
            Debug.Log("Guard facing wrong direction");
            return;
        }
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            rayCastDirection,
            Mathf.Infinity,
            ~(LayerMask.GetMask("Enemy")|LayerMask.GetMask("Ignore Raycast")));
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (GameController.instance.playMode.Equals(GameController.PlayMode.REAL_TIME))
                {
                    GameController.instance.PlayerSeen();
                }
            }
        }
    }
}
