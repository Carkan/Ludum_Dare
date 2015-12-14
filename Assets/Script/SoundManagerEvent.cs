﻿using UnityEngine;
using System.Collections;

/*
 * Comment émettre un event:
		SoundManagerEvent.emit(SoundManagerType.NOMDUSON);
 * 
 * Comment traiter un event (dans un start ou un initialisation)
		EventManagerScript.onEvent += (EventManagerType emt, GameObject go) => {
			if (emt == EventManagerType.ENEMY_HIT)
			{
				//SpawnFXAt(go.transform.position);
			}
		};
 * ou:
		void maCallback(EventManagerType emt, GameObject go) => {
			if (emt == EventManagerType.ENEMY_HIT)
			{
				//SpawnFXAt(go.transform.position);
			}
		};
		EventManagerScript.onEvent += maCallback;
 * 
 * qui permet de:
		EventManagerScript.onEvent -= maCallback; //Retire l'appel
 */

public enum SoundManagerType
{
	MOVE,
    MOVE_FAST,
    PLANETE_EXPLOSION,
    FLECHE_LOADED,
    STOP_FLECHE_LOADED,
    MORCEAUX_RECUP,
    LEVEL_UP,
    DESTROY_PLAYER
}

public class SoundManagerEvent : MonoBehaviour
{
    public delegate void EventAction(SoundManagerType emt);
	public static event EventAction onEvent;

	#region Singleton
	static private SoundManagerEvent s_Instance;
	static public SoundManagerEvent instance
	{
		get
		{
			return s_Instance;
		}
	}
	


	void Awake()
	{
		if (s_Instance == null)
			s_Instance = this;
		//DontDestroyOnLoad(this);
	}
    #endregion
    void Start()
	{
		SoundManagerEvent.onEvent += (SoundManagerType emt) => { Debug.Log(""); };
	}

	public static void emit(SoundManagerType emt)	{
		
		if (onEvent != null)
		{
			onEvent(emt);
		}
	}



}
