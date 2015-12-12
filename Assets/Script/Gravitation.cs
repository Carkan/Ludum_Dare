using UnityEngine;
using System.Collections;

public class Gravitation : MonoBehaviour {

    public float pullForce = 100;

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("PLANETE ATTAQUE");
            // calcule de la direction dans laquel le joueur vient vers la planète
            Vector3 forceDirection = transform.position - col.transform.position;

            // ajoute la force dans la direction de la planète
            col.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
        }
    }

}
