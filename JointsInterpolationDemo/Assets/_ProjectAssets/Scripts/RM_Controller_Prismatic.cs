using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_Controller_Prismatic: MonoBehaviour
{
    public float IntentToExpandPiston;
    public float PistonExpansionMagnitude = 5;
    public float PistonMinDistance = 0;
    public float PistonMaxDistance = 10;

    public GameObject Arm1Piston;
    public GameObject Arm2Piston;

    private ConfigurableJoint PistonJoint;
    private ConfigurableJoint PistonJoint2;

    public float CurrentPistonDistance = 0;
    public float CurrentPistonDistance2 = 0;

    private bool goodToGo = false;

	// Use this for initialization
	void Start ()
	{
	    if (Arm1Piston != null && Arm2Piston!=null)
	        PistonJoint = Arm1Piston.GetComponent<ConfigurableJoint>();
            PistonJoint2 = Arm2Piston.GetComponent<ConfigurableJoint>();

        goodToGo = PistonJoint != null;

        if (goodToGo)
        {
            CurrentPistonDistance = PistonJoint.targetPosition.y;
            CurrentPistonDistance2 = PistonJoint2.targetPosition.y;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if (goodToGo)
	    {
	        CurrentPistonDistance = CurrentPistonDistance + IntentToExpandPiston * PistonExpansionMagnitude*Time.deltaTime;
	        CurrentPistonDistance = Mathf.Clamp(CurrentPistonDistance, PistonMinDistance, PistonMaxDistance);

            CurrentPistonDistance2 = CurrentPistonDistance2 + IntentToExpandPiston * PistonExpansionMagnitude * Time.deltaTime;
            CurrentPistonDistance2 = Mathf.Clamp(CurrentPistonDistance2, PistonMinDistance, PistonMaxDistance);

            PistonJoint.targetPosition = new Vector3(0, CurrentPistonDistance, 0);
            PistonJoint2.targetPosition = new Vector3(0, CurrentPistonDistance2, 0);
        }
	}
}
