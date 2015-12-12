using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

    public static CharacterManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }



    public int level;
    public int morceaux;

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
                morceaux++;
                Debug.Log(morceaux);
                Destroy(col.gameObject);
                LevelUp();
            }
        }
    }

    void LevelUp ()
    {
        //Mettre un switch qui fait le level up en fonction des morceaux (si morceaux > 8 && < 20, level = 1)
        if (morceaux < 8)
        {
            level = 1;
        }
        if ( morceaux >= 8 && morceaux <20)
        {
            level = 2;
        }
        if (morceaux >= 20 && morceaux < 32 )
        {
            level = 3;
        }
        if (morceaux >= 32 && morceaux < 46)
        {
            level = 4;
        }
        if (morceaux >= 46 && morceaux < 52)
        {
            level = 5;
        }
        if (morceaux >= 52 && morceaux < 60 )
        {
            level = 6;
        }
        if (morceaux >= 60 && morceaux < 67)
        {
            level = 7;
        }
        if (morceaux >= 67 && morceaux < 74)
        {
            level = 8;
        }
        if (morceaux >= 74 && morceaux < 80)
        {
            level = 9;
        }
        if (morceaux >=80)
        {
            level = 10;
        }
    }
}
