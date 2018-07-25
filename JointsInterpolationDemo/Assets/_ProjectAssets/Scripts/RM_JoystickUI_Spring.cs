using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_JoystickUI_Spring : MonoBehaviour
{
    public string Axis = "Horizontal";

    private RM_Controller_Spring controller;

    private bool goodToGo = false;

	// Use this for initialization
	void Start ()
	{
	    controller = GetComponent<RM_Controller_Spring>();

	    goodToGo = controller != null;
	}
	
	// Update is called once per frame
	void Update () {
	    if (goodToGo)
	    {
	        controller.IntentToRotateBoom = Input.GetAxis(Axis);
	    }
	}
}
