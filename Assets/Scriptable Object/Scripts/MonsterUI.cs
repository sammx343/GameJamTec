using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MonsterUI", order = 1)]
public class MonsterUI : ScareAction
{
	public UnityEvent monsterAttack;
}
