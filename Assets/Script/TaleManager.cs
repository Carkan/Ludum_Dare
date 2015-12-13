using UnityEngine;
using System.Collections;

public class TaleManager : MonoBehaviour {

    public Transform target;

	
	// Update is called once per frame
	void Update () 
    {
        transform.position = target.position;
	}
}
