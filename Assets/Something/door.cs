using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    public Sprite closedDoor;
    public Sprite openDoor;

    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        //sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            sr.sprite = openDoor;
            print(collision.gameObject.name);
            transform.Translate(Vector2.right * 1.3f);
            Destroy(GetComponent<BoxCollider2D>());
        }
        
    }
}
