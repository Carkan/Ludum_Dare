using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

    public static CharacterManager instance;

    public GameObject myCamera;
    public GameObject myCenter;
    public GameObject particlesPiece;
    public GameObject particlesLevel;
    public int level;
    public int morceaux;
    public Mesh mesh1;
    public Mesh mesh2;
    public Mesh mesh3;
    public Mesh mesh4;
    public Mesh mesh5;
    public Mesh mesh6;
    public Mesh mesh7;
    public Mesh mesh8;
    public Mesh mesh9;
    public Mesh mesh10;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start ()
    {
        //morceaux = 0;
        level = 1;
        GetComponent<MeshFilter>().mesh = mesh1;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Morceau")
        {
            if (col.GetComponent<MorceauDelais>().prenable)
            {
                SoundManagerEvent.emit(SoundManagerType.MORCEAUX_RECUP);
                StartCoroutine("LaunchParticlesPiece");
                Destroy(col.gameObject);
                AddMorceau();
            }
        }
    }

    void LevelUp ()
    {
        //Mettre un switch qui fait le level up en fonction des morceaux (si morceaux > 8 && < 20, level = 1)
        SoundManagerEvent.emit(SoundManagerType.LEVEL_UP);
        level++;
        StartCoroutine("LaunchParticlesLevel");
        CameraManager.instance.LaunchShake(120, 0.3f);
        StartCoroutine("RescalePlayer"); 
        StartCoroutine("RescaleCenter");
    }

    IEnumerator RescaleCenter ()
    {
        
        Vector3 initScale = myCenter.transform.localScale;
        yield return new WaitForSeconds(2f);
        float myConst = 0;
        float time = 0;
        float timeMax = 4;
        while(time < timeMax)
        {
            myConst = Mathf.Lerp(-1, 0, time / timeMax);
            myCenter.transform.localScale = Vector3.Lerp(initScale + new Vector3(0.5f, 0.5f, 0.5f), initScale, Mathf.Pow(myConst, 2));
            time += Time.deltaTime;
            yield return 0;
        }
    }

    IEnumerator RescalePlayer()
    {
        Vector3 initScale = transform.localScale;
        float myConst = 0;
        float time = 0;
        float timeMax = 4;
        while (time < timeMax)
        {
            myConst = Mathf.Lerp(-1, 0, time / timeMax);
            transform.localScale = Vector3.Lerp(initScale + new Vector3(0.5f, 0.5f, 0.5f), initScale, Mathf.Pow(myConst, 2));
            time += Time.deltaTime;
            yield return 0;
        }
    }


    IEnumerator LaunchParticlesPiece()
    {
        GameObject particles = Instantiate(particlesPiece, transform.position, transform.rotation) as GameObject;
        particles.GetComponent<FollowTarget>().target = gameObject;
        yield return new WaitForSeconds(1);
        Destroy(particles);
    }

    IEnumerator LaunchParticlesLevel()
    {
        GameObject particles = Instantiate(particlesLevel, transform.position, transform.rotation) as GameObject;
        particles.GetComponent<FollowTarget>().target = gameObject;
        yield return new WaitForSeconds(1);
        Destroy(particles);
    }

    void AddMorceau ()
    {
        morceaux++;
        if (morceaux >= 8 && level == 1)
        {
            LevelUp();
            GetComponent<MeshFilter>().mesh = mesh2;
        }
        if (morceaux >= 20 && level == 2)
        {
            LevelUp();
            GetComponent<MeshFilter>().mesh = mesh3;
        }
        if (morceaux >= 32 && level == 3 )
        {
            LevelUp();
            GetComponent<MeshFilter>().mesh = mesh4;
        }
        if (morceaux >= 46 && level == 4)
        {
            LevelUp();
            GetComponent<MeshFilter>().mesh = mesh5;
        }
        if (morceaux >= 52 && level == 5)
        {
            LevelUp();
            GetComponent<MeshFilter>().mesh = mesh6;
        }
        if (morceaux >= 60 && level == 6)
        {
            LevelUp();
            GetComponent<MeshFilter>().mesh = mesh7;
        }
        if (morceaux >= 67 && level == 7)
        {
            LevelUp();
            GetComponent<MeshFilter>().mesh = mesh8;
        }
        if (morceaux >= 74 && level == 8)
        {
            LevelUp();
            GetComponent<MeshFilter>().mesh = mesh9;
        }
        if (morceaux >= 80 && level == 9)
        {
            LevelUp();
            GetComponent<MeshFilter>().mesh = mesh10;
        }
        if (morceaux >= 83)
        {
            Debug.Log("FELICITATION T'ES TROP FORT");
        }

    }
}
