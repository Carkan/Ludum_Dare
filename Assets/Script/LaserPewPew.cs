using UnityEngine;
using System.Collections;

public class LaserPewPew : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {

        transform.LookAt(target.transform.position);
        StartCoroutine(DestructionPlayer());
    }
	

    IEnumerator DestructionPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        target.GetComponent<ExplosionPlayer>().StartCoroutine("DeathPlayer");
    }

}
