using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CowMooer : MonoBehaviour {

	AudioSource audio;
	public AudioClip moo;
	public AudioClip[] moos;
	public float timer;
	public float interval = 5f;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		audio.Play();
		interval = Random.Range(2.5f,8f);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime * 1f;
		if (timer >= interval) {
			int index = Random.Range(0, moos.Length);
			moo = moos[index];
			audio.clip = moo;
			audio.Play();

			timer = 0;
            interval = Random.Range(2.5f, 8f);
        }
	}
}
