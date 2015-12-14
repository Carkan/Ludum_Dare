using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour {

    int leLevel;
    public Material destroyShader;
    public int levelNeeded;
    public GameObject particlesExplosion;

  
    void OnCollisionEnter (Collision col)
    {
        Debug.Log(transform.gameObject.name);
        if (col.gameObject.tag == "Player" && CharacterManager.instance.level < levelNeeded)
        {
            
            SoundManagerEvent.emit(SoundManagerType.DESTROY_PLAYER);
            col.gameObject.GetComponent<ExplosionPlayer>().coroutinestartTAMERE();
        }

        if (col.gameObject.tag == "Player" && CharacterManager.instance.level >= levelNeeded)
        {
            int numberChildren = transform.childCount;
            for (int i = 0; i < numberChildren - 1; i++)
            {
                transform.GetChild(0).GetComponent<Rigidbody>().AddForce(new Vector3 (Random.Range(5, 20), Random.Range(5, 20), Random.Range(5, 20)) * 25 );
                transform.GetChild(0).GetComponent<CapsuleCollider>().enabled = true;
                transform.GetChild(0).GetComponent<Renderer>().material = destroyShader;
                transform.GetChild(0).GetComponent<MorceauDelais>().StartCoroutine("Delais");
                transform.GetChild(0).parent = null;
            }
            Destroy(transform.GetChild(0).gameObject);
            StartCoroutine("LaunchParticles");
            
        }
    }


    IEnumerator LaunchParticles()
    {
        SoundManagerEvent.emit(SoundManagerType.PLANETE_EXPLOSION);
        GameObject particles = Instantiate(particlesExplosion, transform.position, transform.rotation) as GameObject;
        yield return new WaitForSeconds(2);
        Destroy(particles);
        Destroy(gameObject);
    }
}
