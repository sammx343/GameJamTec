using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MonsterAudio", order = 1)]
public class MonsterAudio : ScriptableObject
{
	public AudioSource monsterIntro;
	public AudioSource monsterSound;
	public AudioSource heartSound;
}
