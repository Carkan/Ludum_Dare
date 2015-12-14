using UnityEngine;
using System.Collections;

public class ShipDestruction : MonoBehaviour {

    Vector3 targetPos;
    Vector3 Distance;

	void Start ()
    {

        StartCoroutine(Animation());

    }

    void Update ()
    {
        targetPos = transform.parent.transform.position;
    }
	
    IEnumerator Animation()
    {
        Vector3 initPos = transform.localPosition;
        float time = 0f;
        float timeMax = 1f;
        //transform.LookAt(transform.parent);
        while (time < timeMax)
        {
            Debug.Log(transform.localPosition);
            transform.localPosition = Vector3.Lerp(initPos, new Vector3(initPos.x, initPos.y, initPos.z - 190), time / timeMax);
            time += Time.deltaTime;
            yield return 0;
        }

        transform.GetChild(2).gameObject.SetActive(true);
    }

}
