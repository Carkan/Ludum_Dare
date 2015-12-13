using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

    public static CharacterManager instance;

    public GameObject myCamera;
    public GameObject myCenter;
    public int level;
    public int morceaux;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start ()
    {
        morceaux = 0;
        level = 1;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Morceau")
        {
            if (col.GetComponent<MorceauDelais>().prenable)
            {
                SoundManagerEvent.emit(SoundManagerType.MORCEAUX_RECUP);
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
        RescalePlayer();
        RescaleCenter();
    }

    void RescaleCenter ()
    {
        myCenter.transform.localScale = myCenter.transform.localScale + new Vector3(0.5f, 0.5f, 0.5f);
    }

    void RescalePlayer()
    {
        transform.localScale = transform.localScale + new Vector3(0.5f, 0.5f, 0.5f);
    }

    void AddMorceau ()
    {
        morceaux++;
        if (morceaux >= 8 && level == 1)
        {
            LevelUp();
        }
        if (morceaux >= 20 && level == 2)
        {
            LevelUp();
        }
        if (morceaux >= 32 && level == 3 )
        {
            LevelUp();
        }
        if (morceaux >= 46 && level == 4)
        {
            LevelUp();
        }
        if (morceaux >= 52 && level == 5)
        {
            LevelUp();
        }
        if (morceaux >= 60 && level == 6)
        {
            LevelUp();
        }
        if (morceaux >= 67 && level == 7)
        {
            LevelUp();
        }
        if (morceaux >= 74 && level == 8)
        {
            LevelUp();
        }
        if (morceaux >= 80 && level == 9)
        {
            LevelUp();
        }

    }
}
