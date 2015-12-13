using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour {

    bool aboutToShoot;
    bool isMoving;
    float speed;
    float speedMax;
    public GameObject fxComete;
    public GameObject myCamera;
    
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


        if (!isMoving)
        {
            if (Input.GetAxis("L_YAxis_1") > 0.9f)
            {
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
                Debug.Log(transform.eulerAngles);
                GameObject particles = Instantiate(fxComete, m_ParticuleCanon.transform.position, m_ParticuleCanon.transform.rotation) as GameObject;
                particles.GetComponent<TaleManager>().target = asteroid.transform;
                StartCoroutine(ParticleManager(particles));
                speed = 0;
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
        Destroy(pParticles);
    }
}
