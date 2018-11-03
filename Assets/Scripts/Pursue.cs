using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : MovementPlanningController{
	public override void Start () {
        actionController = GetComponent<Seek>();
	}
}
