using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderDissapear : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ScareSlider _slider;

    public void SliderDissapearAnimationEvent()
    {
	    _slider.SliderDissapear();
    }
}
