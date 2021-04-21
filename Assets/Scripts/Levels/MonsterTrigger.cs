using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Levels
{
	public class MonsterTrigger : MonoBehaviour
	{
		// Start is called before the first frame update
		public UnityEvent monsterTrigger;

		private void OnTriggerEnter2D(Collider2D other)
		{
			monsterTrigger.Invoke();
		}
	}
}

