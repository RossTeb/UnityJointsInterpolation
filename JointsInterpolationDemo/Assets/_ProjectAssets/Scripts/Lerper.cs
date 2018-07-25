using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerper : MonoBehaviour {

    public float positionDuration;
    public float rotationDuration;
    public Transform start;
    public Transform end;

    bool goodToGo = false;
    bool animate = false;
    float tPos = 0;
    float tRot = 0;

    // Use this for initialization
    void Start () {
        goodToGo = start != null && end != null;

        //start.gameObject.SetActive(false);
        //end.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if( goodToGo )
        {
            if( Input.GetKeyDown(KeyCode.I))
            {
                animate = true;
            }

            if( animate )
            {
                this.transform.position = Vector3.Lerp(start.position, end.position, tPos);
                this.transform.rotation = Quaternion.Lerp(start.rotation, end.rotation, tRot);

                tPos += Time.deltaTime / positionDuration;
                tRot += Time.deltaTime / rotationDuration;
            }

           // start.Rotate(Random.Range(0,2), Random.Range(0,5), Random.Range(0,1));
            end.Rotate(Random.Range(-2, 0), Random.Range(-5, 0), Random.Range(-1, 0));
        }
    }
}
