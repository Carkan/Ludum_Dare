using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour {

    GameObject lePlayer;
    int leLevel;
    public ProceduralMaterial destroyShader;

    void Start ()
    {
        lePlayer = GameObject.Find("Asteroïde");
        leLevel = lePlayer.GetComponent<CharacterManager>().level;

    }

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Player" && leLevel < 2)
        {
            Destroy(col.gameObject);
            Debug.Log("Game Over");
        }

        if (col.gameObject.tag == "Player" && leLevel >= 2)
        {
            int numberChildren = transform.childCount;
            for (int i = 0; i < numberChildren - 1; i++)
            {
                transform.GetChild(0).GetComponent<Rigidbody>().AddForce(new Vector3 (Random.Range(5, 10), Random.Range(5, 10), Random.Range(5, 10)) * 10 );
                transform.GetChild(0).GetComponent<CapsuleCollider>().enabled = true;
                transform.GetChild(0).GetComponent<Renderer>().material = destroyShader;
                transform.GetChild(0).parent = null;
            }
            Destroy(transform.GetChild(0).gameObject);
        }
    }

}
