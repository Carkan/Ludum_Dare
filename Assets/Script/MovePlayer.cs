using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour {

    bool aboutToShoot;
    bool isMoving;
    float speed;
    
    public Image forceGauge;

    public GameObject asteroid;

    Rigidbody rb;



	// Use this for initialization
	void Start ()
    {
        rb = asteroid.GetComponent<Rigidbody>();
	}
    
	// Update is called once per frame
	void Update () 
    {
        transform.position = asteroid.transform.position;
        

        if(rb.velocity.x < 3f
            && rb.velocity.x > -3f
            && rb.velocity.y < 3f
            && rb.velocity.y > -3f
            && rb.velocity.z < 3f
            && rb.velocity.z > -3f)

        {
            isMoving = false;
        }


        if (!isMoving)
        {
            forceGauge.GetComponent<Image>().fillAmount = Input.GetAxis("L_YAxis_1");
            if (Input.GetAxis("L_YAxis_1") > 0)
            {
                aboutToShoot = true;
                speed = Input.GetAxis("L_YAxis_1") * 500;
            }
            else if (aboutToShoot)
            {

                rb.AddForce(transform.forward * speed);
                isMoving = true;
                //StartCoroutine(FadeForce(-transform.forward, speed));

                aboutToShoot = false;
            }
        }
        else
        {
            forceGauge.GetComponent<Image>().fillAmount = 0;
        }
        
	}

    /*IEnumerator FadeForce(Vector3 direction, float pForce)
    {
        float invertForce = 0;
        
        while(invertForce < pForce/50)
        {
            Debug.Log(invertForce);
            rb.AddForce(direction * invertForce);
            invertForce+=0.1f;
            yield return 0;
        }

        
        
           
    }*/
}
