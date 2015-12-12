using UnityEngine;
using System.Collections;

public class MovePlayer_Test : MonoBehaviour {

    public int force;


	void Start () {

        this.GetComponent<Rigidbody>().AddForce(transform.forward * force);

    }
	
	void Update () {
	
	}
}
