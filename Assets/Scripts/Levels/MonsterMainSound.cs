using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Levels
{
	public class MonsterMainSound : MonsterSound
	{
		// Start is called before the first frame update
		[Header("Audio Configuration")]
		[Range(0.0f, 1f)]
		[SerializeField] private float initialVolume;
		[SerializeField] private float finalVolume = 1;
		[SerializeField] private float timeToIncreaseVolume;

		[Header("Scriptable Objects")]
		[SerializeField] private MonsterUI monsterSoundUi;

		private MonsterIntroSoundTrigger _monsterIntroSoundTrigger;

		private AudioSource _monsterMainAudioSource;
		private bool _volumeWasIncreased;
		private bool _audioStarted;

		void Start()
		{
			if (TryGetComponent(out _monsterIntroSoundTrigger))
			{
				_monsterIntroSoundTrigger.monsterIntroAudioFinished.AddListener(PlayMonsterAudio);
			}
			else if (TryGetComponent(out _monsterTrigger))
			{
				_monsterTrigger.monsterTrigger.AddListener(PlayMonsterAudio);
			}

			_volumeWasIncreased = false;
			_audioStarted = false;
		}

		void Update()
		{
			IncreaseAudioVolume();
		}

		void IncreaseAudioVolume()
		{
			if (_audioStarted)
			{
				if (_monsterMainAudioSource.time >= timeToIncreaseVolume && !_volumeWasIncreased)
				{
					_monsterMainAudioSource.volume = finalVolume;
					_volumeWasIncreased = true;
					monsterSoundUi.monsterAttack.Invoke();
				}
			}
		}
		void PlayMonsterAudio()
		{
			_monsterMainAudioSource = Instantiate(_monsterAudio.monsterSound, transform);
			_monsterMainAudioSource.volume = initialVolume;
			_monsterMainAudioSource.Play();
			_audioStarted = true;

			monsterSoundUi.scareEventStarted.Invoke(_monsterMainAudioSource.clip.length);

			StartCoroutine(MonsterMainSoundEndCoroutine(_monsterMainAudioSource.clip.length));
		}

		private IEnumerator MonsterMainSoundEndCoroutine(float clipLength)
		{
			yield return new WaitForSeconds(clipLength);

			_audioStarted = false;
			_volumeWasIncreased = false;
			Destroy(_monsterMainAudioSource.gameObject);

			monsterSoundUi.scareEventEnded.Invoke();
		}
	}
}


