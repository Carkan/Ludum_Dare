using UnityEngine;
using System.Collections;

public class MoveMorceau_Test : MonoBehaviour {

    public int force;

    // Use this for initialization
    void Start () {

        this.GetComponent<Rigidbody>().AddForce(transform.forward * force);
    }
	
	// Update is called once per frame
	void Update () {
       
	}
}
