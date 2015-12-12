using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    float rotationX;
    float rotationY;

    public GameObject camera;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        rotationX = -Input.GetAxis("R_YAxis_1");
        rotationY = Input.GetAxis("R_XAxis_1");

        //Debug.Log(rotationX);

        //transform.eulerAngles += new Vector3(rotationX, rotationY, 0f);
        transform.Rotate((Vector3.right * -Input.GetAxis("R_YAxis_1")) + Vector3.up * Input.GetAxis("R_XAxis_1"));
        //camera.transform.Rotate((Vector3.right * -Input.GetAxis("R_YAxis_1")) + Vector3.up * Input.GetAxis("R_XAxis_1"));
	}
}
