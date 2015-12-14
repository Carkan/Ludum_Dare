using UnityEngine;
using System.Collections;

public class ShipDestruction : MonoBehaviour {

    Vector3 targetPos;
    Vector3 Distance;

	void Start () {

        StartCoroutine(Animation());

    }

    void Update ()
    {
        targetPos = transform.parent.transform.position;
        if (Vector3.Distance(targetPos, transform.localPosition) < 60)
        {
            StopCoroutine(Animation());
        }
        Debug.Log(Vector3.Distance(targetPos, transform.localPosition));
    }
	
    IEnumerator Animation()
    {
        while (true)
        {
            transform.LookAt(transform.parent);
            transform.localPosition = transform.localPosition + (Vector3.back) * 0.2f;
            //transform.eulerAngles = transform.eulerAngles + new Vector3(0, 90, 0);
            if (Vector3.Distance(targetPos, transform.localPosition) < 60)
            {
                StopCoroutine(Animation());
            }
            yield return null;
        }
    }

}
