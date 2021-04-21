using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	public class SliderDisappear : MonoBehaviour
	{
		// Start is called before the first frame update
		[SerializeField] private ScareSlider slider;

		public void SliderDisappearAnimationEvent()
		{
			slider.SliderDisappear();
		}
	}
}


