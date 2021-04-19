using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScareSlider : MonoBehaviour
{
    // Start is called before the first frame update
    public PlaySoundExample[] monsterAnimationEvents;
    private PlaySoundExample currentPlaySoundExample;
    private bool newSoundPlaying = false;

    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI textInstruction;

    private bool increasedMonsterAudio;
    private Animator _animator;
    void Start()
    {
	    slider.gameObject.SetActive(false);
	    textInstruction.gameObject.SetActive(false);
	    _animator = slider.GetComponent<Animator>();


	    foreach (var monsterAnimationEvent in monsterAnimationEvents)
	    {
		    monsterAnimationEvent.StartedMonsterAudioEvent.AddListener(StartedMonsterAudio);
		    monsterAnimationEvent.increasedMonsterAudioEvent.AddListener(SliderChangeColor);
		    monsterAnimationEvent.stoppedMonsterAudioEvent.AddListener(ResetSlider);
	    }
    }

    // Update is called once per frame
    void Update()
    {
	    if (newSoundPlaying)
	    {
		    if (currentPlaySoundExample.monsterSoundIsPlaying && currentPlaySoundExample != null)
		    {
			    slider.value = currentPlaySoundExample.monsterSoundSource.time;
		    }
	    }
    }

    void StartedMonsterAudio(PlaySoundExample playSoundExample)
    {
	    newSoundPlaying = true;
	    currentPlaySoundExample = playSoundExample;
	    slider.minValue = 0;
	    slider.maxValue = currentPlaySoundExample.monsterSoundSource.clip.length;

	    slider.gameObject.SetActive(true);
	    _animator.Play("Appear");
    }

    void SliderChangeColor()
    {
	    Debug.Log("CHANGE COLOR");
	    textInstruction.gameObject.SetActive(true);
	    _animator.Play("IncreasedVolume");
    }

    void ResetSlider()
    {
	    newSoundPlaying = false;
	    _animator.Play("Dissapear");
    }

    public void SliderDissapear()
    {
	    slider.gameObject.SetActive(false);
	    textInstruction.gameObject.SetActive(false);
    }

}
