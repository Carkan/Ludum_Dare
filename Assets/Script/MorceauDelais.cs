using UnityEngine;
using System.Collections;

public class MorceauDelais : MonoBehaviour {

    public bool prenable;

    public IEnumerator Delais ()
    {
        yield return new WaitForSeconds(0.5f);
        prenable = true;
    }
}
