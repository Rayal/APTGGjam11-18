using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlanningController : MonoBehaviour {
    public GameObject target;

    protected MovementActionController actionController;

    public virtual void Start()
    {
        actionController = GetComponent<MovementActionController>();
    }

	// Update is called once per frame
	void FixedUpdate () {
        actionController.pointOfInterest = target.transform.position;
	}
}
