using UnityEngine;
using System.Collections;

//Force attraction = distance max (planète/trigger) - distanceVaisseau (vaisseau/planète)

public class Gravitation : MonoBehaviour {

    public float pullForce;
    private Transform target;
    Vector3 newPos;
    private float distanceMax;

    void Start ()
    {
        target = transform.parent.transform;
        distanceMax = gameObject.GetComponent<SphereCollider>().radius;        
    }

    void Update ()
    {
        transform.Rotate(0,1,0);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Morceau")
        {
            col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            col.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }


    void OnTriggerStay (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // calcule de la direction dans laquel le joueur vient vers la planète
            Vector3 forceDirection = transform.position - col.transform.position;

            //Calculer la distance entre vaisseau et la planète, l'enlever de la distance max, pour changer la force de pull. 
            pullForce = (distanceMax - (Vector3.Distance(transform.position, col.transform.position))) * 50 ;
            Debug.Log(pullForce);

            // ajoute la force dans la direction de la planète
            col.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);



            //Le player regarde en direction de la planète, puis on change son angle de 90degrés pour le faire tourner.
            col.gameObject.transform.LookAt(target);
            newPos = col.gameObject.transform.eulerAngles + new Vector3(0, 90, 0);
            col.gameObject.transform.eulerAngles = newPos;


        }

        if (col.gameObject.tag == "Morceau")
        {
            col.gameObject.transform.parent = this.gameObject.transform;

        }
    }


}
