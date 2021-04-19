using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UnityStartMonsterSound : UnityEvent<PlaySoundExample>
{
}

public class PlaySoundExample : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource introSoundSource;
	private AudioClip introSoundClip;

    public AudioSource monsterSoundSource;
    private AudioClip monsterSoundClip;

    [SerializeField] private AudioSource hearthBeatSource;

    [SerializeField] private float monsterSoundHighVolumeTime;

    public UnityStartMonsterSound StartedMonsterAudioEvent;
    public UnityEvent increasedMonsterAudioEvent;
    public UnityEvent stoppedMonsterAudioEvent;

    public bool destroyOnFinishAudio;
    private bool didPlay;
    public bool monsterSoundIsPlaying;
    public bool hearthBeatSoundIsPlaying;
    public float monsterSoundClipTime;

    private void Awake()
    {
	    StartedMonsterAudioEvent = new UnityStartMonsterSound();
    }

    void Start()
    {
	    didPlay = false;
	    monsterSoundIsPlaying = false;
	    hearthBeatSoundIsPlaying = false;

	    introSoundClip = introSoundSource.clip;
	    monsterSoundClip = monsterSoundSource.clip;

	    monsterSoundClipTime = monsterSoundClip.length;
    }

    private void Update()
    {
	    if (monsterSoundIsPlaying)
	    {
		    //Is the current clip time greater than the wished time to increase the volume
		    if (monsterSoundSource.time >= monsterSoundHighVolumeTime && monsterSoundSource.volume < 1)
		    {
			    monsterSoundSource.volume = 1;
			    increasedMonsterAudioEvent.Invoke();

			    if (!hearthBeatSoundIsPlaying)
			    {
				    Debug.Log("play heartbeat");
				    hearthBeatSoundIsPlaying = true;
				    hearthBeatSource.Play();
			    }
		    }
	    }

	    if (monsterSoundSource.time >= monsterSoundClipTime && destroyOnFinishAudio)
	    {
		    stoppedMonsterAudioEvent.Invoke();
		    Destroy(gameObject);
	    }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
	    if (!didPlay)
	    {
		    PlayAudioIntro(introSoundClip);
		    didPlay = true;
	    }
    }

    void PlayAudioIntro(AudioClip clip)
    {
	    float clipLength = clip.length;

	    introSoundSource.Play();
	    StartCoroutine(IntroEndCoroutine(clipLength));
    }

    void PlayMonsterAudio()
    {
	    monsterSoundSource.Play();
	    monsterSoundIsPlaying = true;
	    StartedMonsterAudioEvent.Invoke(this);
    }

    private IEnumerator IntroEndCoroutine(float clipLength)
    {
	    yield return new WaitForSeconds(clipLength);

	    PlayMonsterAudio();
    }
}
