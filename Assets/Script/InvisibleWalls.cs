using UnityEngine;
using System.Collections;

public class InvisibleWalls : MonoBehaviour
{

    bool isOut;
    public Animator myAnimator;

    // Update is called once per frame
    void OnTriggerExit(Collider col)
    {
        if (col.name == "Comète")
        {
            Debug.Log("Sorti !");
            myAnimator.SetBool("Start_Alert", true);
            StartCoroutine("PlayerOut");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Comète")
        {
            myAnimator.SetBool("Start_Alert", false);
            StopAllCoroutines();
        }
    }


    IEnumerator PlayerOut()
    {
        float time = 0;
        float timeMax = 10;
        while (time < timeMax)
        {
            time += Time.deltaTime;
            yield return 0;
        }
        myAnimator.SetBool("Start_Alert", false);
    }
}
