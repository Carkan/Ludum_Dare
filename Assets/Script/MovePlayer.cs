using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour {

    bool aboutToShoot;
    bool isMoving;
    float speed;
    float fadeSpeed;
    public Image forceGauge;

    public GameObject asteroid;

    Rigidbody rb;



	// Use this for initialization
	void Start ()
    {
        rb = asteroid.GetComponent<Rigidbody>();
        speed = 10;
	}
    
	// Update is called once per frame
	void Update () 
    {
        transform.position = asteroid.transform.position;
        forceGauge.GetComponent<Image>().fillAmount = Input.GetAxis("L_YAxis_1");

        if(Input.GetAxis("L_YAxis_1") > 0)
        {
            aboutToShoot = true;
            speed = Input.GetAxis("L_YAxis_1") * 100;
        }
        else if (aboutToShoot)
        {
            rb.AddForce(transform.forward * speed);
            //StartCoroutine("FadeForce");
            aboutToShoot = false;
        }
	}

    IEnumerator FadeForce()
    {
        while(fadeSpeed < speed)
        {
            rb.AddForce(-transform.forward * fadeSpeed);
            fadeSpeed += 0.1f;
            yield return 0;
        }
    }
}
