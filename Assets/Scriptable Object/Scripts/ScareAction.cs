using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScareEventStart : UnityEvent<float>
{ }

public class ScareAction : ScriptableObject
{
	public ScareEventStart scareEventStarted;
	public UnityEvent scareEventEnded;
}
