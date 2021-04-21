using System;
using UnityEngine;
using UnityEngine.Events;

namespace Levels
{
	public class MonsterSound : MonoBehaviour
	{
		protected MonsterTrigger _monsterTrigger;
		public MonsterAudio _monsterAudio;

		public void Awake()
		{
			_monsterTrigger = GetComponent<MonsterTrigger>();
		}
	}
}
