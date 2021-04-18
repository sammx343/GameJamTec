using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySouncExample : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource introSoundSource;
    [SerializeField] private AudioClip introSoundClip;

    [SerializeField] private AudioSource monsterSoundSource;
    [SerializeField] private float monsterSoundHighVolumeTime;

    private bool destroyOnFinishAudio;
    private bool didPlay;
    private bool monsterSoundIsPlaying;

    void Start()
    {
	    didPlay = false;
	    monsterSoundIsPlaying = false;
    }

    private void Update()
    {
	    if (monsterSoundIsPlaying)
	    {
		    if (monsterSoundSource.time >= monsterSoundHighVolumeTime && monsterSoundSource.volume < 1)
		    {
			    monsterSoundSource.volume = 1;
		    }
	    }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
	    Debug.Log("On Trigger");
	    PlayAudioIntro(introSoundClip);
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
    }

    private IEnumerator IntroEndCoroutine(float clipLength)
    {
	    yield return new WaitForSeconds(clipLength);

	    PlayMonsterAudio();
    }
}
