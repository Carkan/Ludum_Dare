using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    float rotationX;
    float rotationY;
    public int speed;

    public GameObject camera;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate((Vector3.right * -Input.GetAxis("R_YAxis_1")) * speed
                        + Vector3.up * Input.GetAxis("R_XAxis_1") * speed);
        //camera.transform.Rotate((Vector3.right * -Input.GetAxis("R_YAxis_1")) + Vector3.up * Input.GetAxis("R_XAxis_1"));
	}
}
