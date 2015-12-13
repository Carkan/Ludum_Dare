using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour {

    bool aboutToShoot;
    bool isMoving;
    float speed;
    float speedMax;
    public GameObject fxComete;

    public Animator animatorFleche1;
    public Animator animatorFleche2;
    public Animator animatorFleche3;
    public Animator animatorFleche4;

    
    public Image forceGauge;

    public GameObject asteroid;

    Rigidbody rb;

    public GameObject m_ParticuleCanon;


	// Use this for initialization
	void Start ()
    {
        rb = asteroid.GetComponent<Rigidbody>();
        speedMax = 5000;
        forceGauge.enabled = false;
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

        if(speed >= speedMax)
        {
            speed = speedMax;
            animatorFleche1.SetBool("isLoaded", true);
            animatorFleche2.SetBool("isLoaded", true);
            animatorFleche3.SetBool("isLoaded", true);
            animatorFleche4.SetBool("isLoaded", true);
        }


        if (!isMoving)
        {
            if (Input.GetAxis("L_YAxis_1") > 0.9f)
            {
                animatorFleche1.SetBool("Start_Anim", true);
                animatorFleche2.SetBool("Start_Anim", true);
                animatorFleche3.SetBool("Start_Anim", true);
                animatorFleche4.SetBool("Start_Anim", true);

                aboutToShoot = true;
                forceGauge.enabled = true;
                if(speed < speedMax)
                {
                    speed += 50;
                }
                
            }
            else if (aboutToShoot)
            {
                
                rb.AddForce(transform.forward * speed);
                isMoving = true;

                animatorFleche1.SetBool("Start_Anim", false);
                animatorFleche2.SetBool("Start_Anim", false);
                animatorFleche3.SetBool("Start_Anim", false);
                animatorFleche4.SetBool("Start_Anim", false);

                animatorFleche1.SetBool("isLoaded", false);
                animatorFleche2.SetBool("isLoaded", false);
                animatorFleche3.SetBool("isLoaded", false);
                animatorFleche4.SetBool("isLoaded", false);
                if(speed > (speedMax/4)*3)
                {
                    CameraManager.instance.StartCoroutine("MoveComete");
                    CameraManager.instance.StartCoroutine("Shake");
                }

                GameObject particles = Instantiate(fxComete, m_ParticuleCanon.transform.position, m_ParticuleCanon.transform.rotation) as GameObject;
                particles.GetComponent<TaleManager>().target = asteroid.transform;
                StartCoroutine(ParticleManager(particles));
                aboutToShoot = false;
            }
        }
        else
        {
            forceGauge.enabled = false;
        }
        
	}

    IEnumerator ParticleManager(GameObject pParticles)
    {
        yield return new WaitForSeconds(1);
        if (speed > (speedMax / 4) * 3)
        {
            CameraManager.instance.StartCoroutine("StopComete");
        }
        speed = 0;
        Destroy(pParticles);
    }
}
