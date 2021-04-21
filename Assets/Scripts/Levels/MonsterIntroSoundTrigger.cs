using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Levels
{
	[RequireComponent(typeof(MonsterTrigger))]
	public class MonsterIntroSoundTrigger : MonsterSound
	{
		// Start is called before the first frame update
		public UnityEvent monsterIntroAudioFinished;
		private AudioSource _monsterIntro;

		void Start()
		{
			_monsterTrigger.monsterTrigger.AddListener(StartMonsterIntroAudio);
		}

		void StartMonsterIntroAudio()
		{
			_monsterIntro = Instantiate(_monsterAudio.monsterIntro, transform);
			_monsterIntro.Play();

			StartCoroutine(IntroAudioEndCoroutine(_monsterIntro.clip.length));

		}

		private IEnumerator IntroAudioEndCoroutine(float clipLength)
		{
			yield return new WaitForSeconds(clipLength);
			Destroy(_monsterIntro.gameObject);
			monsterIntroAudioFinished.Invoke();
		}

	}
}

