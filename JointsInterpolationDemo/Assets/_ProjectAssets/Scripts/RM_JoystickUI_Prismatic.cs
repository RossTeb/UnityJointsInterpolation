using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_JoystickUI_Prismatic : MonoBehaviour
{
    public string Axis = "Horizontal";

    private RM_Controller_Prismatic controller;

    private bool goodToGo = false;
    private float speed = 1;
	// Use this for initialization
	void Start ()
	{
	    controller = GetComponent<RM_Controller_Prismatic>();

	    goodToGo = controller != null;
	}
	
	// Update is called once per frame
	void Update () {
	    if (goodToGo)
	    {
	        controller.IntentToExpandPiston = Input.GetAxis(Axis);
           /* if (Input.GetKeyDown(KeyCode.W))
            {
                controller.IntentToExpandPiston += 1f;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                controller.IntentToExpandPiston -= 1f;
            }
            */
        }
	}
}
