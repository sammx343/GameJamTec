using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildAudioController : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource childCrying;
    void Start()
    {
	    childCrying = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
