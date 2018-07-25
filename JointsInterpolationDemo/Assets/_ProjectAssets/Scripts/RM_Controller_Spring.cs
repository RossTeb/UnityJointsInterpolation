using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_Controller_Spring: MonoBehaviour
{
    public float IntentToRotateBoom;
    public float RotateBoomMagnitude = 5;
    public float BoomMinAngle = 0;
    public float BoomMaxAngle = 10;

    public GameObject Boom;

    private HingeJoint BoomJoint;
    private float CurrentBoomAngle = 0;

    private bool goodToGo = false;

	// Use this for initialization
	void Start ()
	{
	    if (Boom != null)
	        BoomJoint = Boom.GetComponent<HingeJoint>();

	    goodToGo = BoomJoint != null;

        if (goodToGo)
        {
            CurrentBoomAngle = BoomJoint.spring.targetPosition;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if (goodToGo)
	    {
	        CurrentBoomAngle = CurrentBoomAngle + IntentToRotateBoom*RotateBoomMagnitude*Time.deltaTime;
	        CurrentBoomAngle = Mathf.Clamp(CurrentBoomAngle, BoomMinAngle, BoomMaxAngle);

            JointSpring spring = BoomJoint.spring;
            spring.targetPosition = CurrentBoomAngle;
	        BoomJoint.spring = spring;
	    }
	}
}
