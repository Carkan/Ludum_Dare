using UnityEngine;
using System.Collections;

public class ChampDeForce : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    public GameObject forceField;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
     
        ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, transform.forward);
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.tag == "ChampDeForce")
            {
                if (hit.collider.gameObject != forceField)
                {
                    forceField = hit.collider.gameObject;
                    forceField.transform.GetChild(0).transform.gameObject.SetActive(true);
                }
               
            }
        }

        if (hit.collider == null)
        {
            Debug.Log("hello");
            if (forceField != null)
            {

                forceField.transform.GetChild(0).transform.gameObject.SetActive(false);
            }
            forceField = null;
        }
	}
}
