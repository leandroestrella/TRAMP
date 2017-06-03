using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioClip : MonoBehaviour {

	public AudioClip[] AudioClipArray;

	private AudioSource _audioSource;

	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}

	void Update () {
		if (!_audioSource.isPlaying) {
			_audioSource.clip = AudioClipArray[Random.Range(0, AudioClipArray.Length)];
			_audioSource.Play();
		}
	}
}