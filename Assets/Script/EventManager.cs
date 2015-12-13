using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{


    //#region Singleton
    //public static EventManager instance;

    //void Awake()
    //{
    //    if(instance == null)
    //    {
    //        instance = this;
    //    }
    //}
    //#endregion


    public delegate void IsLoaded();
    public static event IsLoaded ArrowIsLoaded;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (MovePlayer.instance.speed >= MovePlayer.instance.speedMax)
        {
            if (ArrowIsLoaded != null)
            {
                ArrowIsLoaded();
            }
        }
	}
}
