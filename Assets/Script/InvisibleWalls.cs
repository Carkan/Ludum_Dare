using UnityEngine;
using System.Collections;

public class InvisibleWalls : MonoBehaviour
{

    bool isOut;
    public Animator myAnimator;
    public GameObject vaisseaux;
    public GameObject player;
    public GameObject asteroid;
    Rigidbody rb;

    void Start()
    {
        rb = asteroid.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void OnTriggerExit(Collider col)
    {
        if (col.name == "Comète")
        {
            Debug.Log("Sorti !");
            myAnimator.SetBool("Start_Alert", true);
            StartCoroutine("PlayerOut");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Comète")
        {
            myAnimator.SetBool("Start_Alert", false);
            StopAllCoroutines();
        }
    }


    IEnumerator PlayerOut()
    {
        float time = 0;
        float timeMax = 5;
        while (time < timeMax)
        {
            time += Time.deltaTime;

            yield return 0;
        }
        myAnimator.SetBool("Start_Alert", false);
        MovePlayer.instance.animatorFleche1.SetBool("Start_Anim", false);
        MovePlayer.instance.animatorFleche2.SetBool("Start_Anim", false);
        MovePlayer.instance.animatorFleche3.SetBool("Start_Anim", false);
        MovePlayer.instance.animatorFleche4.SetBool("Start_Anim", false);
        MovePlayer.instance.canMove = false;
        player.GetComponent<CameraManager>().speed = 0;
        player.transform.GetChild(5).gameObject.SetActive(true);


        //fwd = transform.TransformDirection(Vector3.forward) * unit;
        //offset = transform.position + fwd;
        //if (Input.GetKeyDown(KeyCode.E) && canPlaceObject)
        //{
        //    clone = Instantiate(prefabObject, offset, transform.rotation);


    }
}
