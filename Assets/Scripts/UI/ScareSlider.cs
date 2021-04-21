using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ScareSlider : MonoBehaviour
	{
	    // Start is called before the first frame update
	    [Header("UI Elements")]
	    [SerializeField] private Slider slider;
	    [SerializeField] private TextMeshProUGUI textInstruction;

	    [Header("Scriptable Objects")]
	    [SerializeField] private MonsterUI monsterUi;

	    private Animator _animator;
	    private bool _increasedMonsterAudio;
	    private bool _sliderStartPlaying = false;

	    void Start()
	    {
		    slider.gameObject.SetActive(false);
		    textInstruction.gameObject.SetActive(false);
		    _animator = slider.GetComponent<Animator>();

		    monsterUi.scareEventStarted = new ScareEventStart();

		    monsterUi.scareEventStarted.AddListener(StartedMonsterAudio);
		    monsterUi.scareEventEnded.AddListener(ResetSlider);
		    monsterUi.monsterAttack.AddListener(SliderChangeColor);
	    }

	    // Update is called once per frame
	    void Update()
	    {
		    if (_sliderStartPlaying)
		    {
			    slider.value += Time.deltaTime;
		    }
	    }

	    void StartedMonsterAudio(float sliderMaxValue)
	    {
		    _sliderStartPlaying = true;

		    slider.minValue = 0;
		    slider.maxValue = sliderMaxValue;

		    slider.gameObject.SetActive(true);
		    _animator.Play("Appear");
	    }

	    void SliderChangeColor()
	    {
		    textInstruction.gameObject.SetActive(true);
		    _animator.Play("IncreasedVolume");
	    }

	    void ResetSlider()
	    {
		    _sliderStartPlaying = false;
		    _animator.Play("Disappear");
	    }

	    public void SliderDisappear()
	    {
		    slider.gameObject.SetActive(false);
		    textInstruction.gameObject.SetActive(false);

		    slider.value = 0;
	    }
	}
}
