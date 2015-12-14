using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{

    #region Singleton
    public static CameraManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    bool screenShake;

    float rotationX;
    float rotationY;
    public int speed;

    public GameObject cameraPlayer;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((Vector3.right * -Input.GetAxis("R_YAxis_1")) * speed
                        + Vector3.up * Input.GetAxis("R_XAxis_1") * speed);
    }


    public void LaunchShake(float pTimeMax, float pMagnitude)
    {
        StartCoroutine(Shake(pTimeMax, pMagnitude));
    }

    IEnumerator MoveComete()
    {
        screenShake = true;
        cameraPlayer.GetComponent<Camera>().fieldOfView = 60;
        float myConst = 0;
        float time = 0;
        float timeMax = 0.5f;
        while (time < timeMax)
        {
            myConst = Mathf.Lerp(-1, 0, time / timeMax);
            cameraPlayer.GetComponent<Camera>().fieldOfView = Mathf.Lerp(80, 60, Mathf.Pow(myConst, 2));
            time += Time.deltaTime;
            yield return 0;
        }
    }

    IEnumerator StopComete()
    {
        screenShake = false;
        cameraPlayer.GetComponent<Camera>().fieldOfView = 60;
        float myConst = 0;
        float time = 0;
        float timeMax = 0.2f;
        while (time < timeMax)
        {
            myConst = Mathf.Lerp(-1, 0, time / timeMax);
            cameraPlayer.GetComponent<Camera>().fieldOfView = Mathf.Lerp(60, 80, Mathf.Pow(myConst, 2));
            time += Time.deltaTime;
            yield return 0;
        }
    }


    IEnumerator Shake(float timeMax, float pMagnitude)
    {
        float elapsed = 0.0f;

        Vector3 originalCamPos = cameraPlayer.transform.localPosition;

        while (elapsed < timeMax)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / 1;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= pMagnitude * damper;
            y *= pMagnitude * damper;

            cameraPlayer.transform.localPosition = new Vector3(originalCamPos.x + x, originalCamPos.y + y, originalCamPos.z);

            yield return 0;
        }

        cameraPlayer.transform.localPosition = originalCamPos;
    }
}
