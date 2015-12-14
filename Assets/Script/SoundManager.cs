using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;


//m_AudioMixer.SetFloat("MasterVolume", -80f);

public class SoundManager : MonoBehaviour {
	#region Members

	[Header("MUSICS")]
	public List<AudioClip> Music = new List<AudioClip>();

	[Header("SOUNDS")]

	public List<AudioClip> Sound= new List<AudioClip>();
	
	[Header("VOICES")]
	public List<AudioClip> Voice = new List<AudioClip>();

	[Header("Sound Listeners")]
	public List<AudioSource> Source = new List<AudioSource>();

    public AudioMixer m_AudioMixer;

    #endregion




    // Use this for initialization
    void Start()
	{
		SoundManagerEvent.onEvent += Play;
        SoundManagerEvent.onEvent += Stop;
    }

	void OnDestroy()
	{
		SoundManagerEvent.onEvent -= Play;
        SoundManagerEvent.onEvent -= Stop;
	}

	public void Play(SoundManagerType emt)
	{
		switch (emt)
		{
			case SoundManagerType.MOVE:
                Source[0].Stop();
				Source[0].clip = Sound[0];
				Source[0].Play();
                break;

            case SoundManagerType.MOVE_FAST:
                Source[1].Stop();
                Source[1].clip = Sound[1];
                Source[1].Play();
                break;

            case SoundManagerType.PLANETE_EXPLOSION:
                Source[2].Stop();
                Source[2].clip = Sound[2];
                Source[2].Play();
                break;

            case SoundManagerType.FLECHE_LOADED:
                Source[3].Stop();
                Source[3].clip = Sound[3];
                Source[3].Play();
                break;

            case SoundManagerType.MORCEAUX_RECUP:
                Source[4].Stop();
                Source[4].clip = Sound[4];
                Source[4].Play();
                break;

            case SoundManagerType.LEVEL_UP:
                Source[5].Stop();
                Source[5].clip = Sound[5];
                Source[5].Play();
                break;

            case SoundManagerType.DESTROY_PLAYER:
                Source[6].Stop();
                Source[6].clip = Sound[6];
                Source[6].Play();
                break;

        }
	}



    public void Stop(SoundManagerType emt)
    {
        switch (emt)
        {
            case SoundManagerType.STOP_FLECHE_LOADED:
                Source[3].Stop();
                break;

        }
    }
}
