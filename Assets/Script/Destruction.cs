using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour {

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            Debug.Log("Game Over");
        }
    }

}
