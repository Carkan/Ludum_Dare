using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour {

    int leLevel;
    public ProceduralMaterial destroyShader;
    public int levelNeeded;

  
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Player" && CharacterManager.instance.level < levelNeeded)
        {
            col.gameObject.SetActive(false);
            SoundManagerEvent.emit(SoundManagerType.DESTROY_PLAYER);

            Debug.Log("Game Over");
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
            SoundManagerEvent.emit(SoundManagerType.PLANETE_EXPLOSION);
            Destroy(gameObject);
        }
    }

}
