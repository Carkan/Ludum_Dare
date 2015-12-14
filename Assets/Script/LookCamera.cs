using UnityEngine;
using System.Collections;

public class LookCamera : MonoBehaviour {

    public GameObject m_Camera;

    void Start()
    {
        
    }


    void Update()
    {
        transform.LookAt(m_Camera.transform);
        //transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            //m_Camera.transform.rotation * Vector3.up);
    }
}
