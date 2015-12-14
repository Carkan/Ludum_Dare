using UnityEngine;
using System.Collections;

public class ExplosionPlayer : MonoBehaviour {

    public GameObject particlesLevel;

    public void coroutinestartTAMERE()
    {
        StartCoroutine(DeathPlayer());
    }

    public IEnumerator DeathPlayer()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        GameObject particles = Instantiate(particlesLevel, transform.position, transform.rotation) as GameObject;
        yield return new WaitForSeconds(1);
        Application.LoadLevel("GameOver");
    }
}
