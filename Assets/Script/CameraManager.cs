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

    public GameObject camera;


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

    IEnumerator MoveComete()
    {
        screenShake = true;
        camera.GetComponent<Camera>().fieldOfView = 60;
        float myConst = 0;
        float time = 0;
        float timeMax = 0.5f;
        while (time < timeMax)
        {
            myConst = Mathf.Lerp(-1, 0, time / timeMax);
            camera.GetComponent<Camera>().fieldOfView = Mathf.Lerp(80, 60, Mathf.Pow(myConst, 2));
            time += Time.deltaTime;
            yield return 0;
        }
    }

    IEnumerator StopComete()
    {
        screenShake = false;
        camera.GetComponent<Camera>().fieldOfView = 60;
        float myConst = 0;
        float time = 0;
        float timeMax = 0.2f;
        while (time < timeMax)
        {
            myConst = Mathf.Lerp(-1, 0, time / timeMax);
            camera.GetComponent<Camera>().fieldOfView = Mathf.Lerp(60, 80, Mathf.Pow(myConst, 2));
            time += Time.deltaTime;
            yield return 0;
        }
    }


    IEnumerator Shake()
    {
        float magnitude = 0.1f;

        float elapsed = 0.0f;

        Vector3 originalCamPos = camera.transform.localPosition;

        while (elapsed < 1)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / 1;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            camera.transform.localPosition = new Vector3(originalCamPos.x + x, originalCamPos.y + y, originalCamPos.z);

            yield return null;
        }

        camera.transform.localPosition = originalCamPos;
    }
}
