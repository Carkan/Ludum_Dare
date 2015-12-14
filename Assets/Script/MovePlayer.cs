using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{

    #region Singleton
    public static MovePlayer instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    #endregion


    bool aboutToShoot;
    bool isMoving;
    public float speed;
    public float speedMax;
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
        EventManager.ArrowIsLoaded += LaunchArrowLoadedSound;
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
                    speed += 100;

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


                if (speed > (speedMax/4)*3)
                {
                    SoundManagerEvent.emit(SoundManagerType.MOVE_FAST);
                    CameraManager.instance.StartCoroutine("MoveComete");
                    CameraManager.instance.LaunchShake(1, 0.1f);
                }
                else
                {
                   // SoundManagerEvent.emit(SoundManagerType.MOVE);
                }

                GameObject particles = Instantiate(fxComete, m_ParticuleCanon.transform.position, m_ParticuleCanon.transform.rotation) as GameObject;
                particles.GetComponent<TaleManager>().target = asteroid.transform;
                SoundManagerEvent.emit(SoundManagerType.STOP_FLECHE_LOADED);
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
        EventManager.ArrowIsLoaded += LaunchArrowLoadedSound;
        Destroy(pParticles);
    }


    void LaunchArrowLoadedSound()
    {
        SoundManagerEvent.emit(SoundManagerType.FLECHE_LOADED);
        EventManager.ArrowIsLoaded -= LaunchArrowLoadedSound;
    }
}
