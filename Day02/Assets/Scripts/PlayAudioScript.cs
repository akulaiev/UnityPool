
using UnityEngine;

public class PlayAudioScript : MonoBehaviour {

	public AudioSource	audioSource;
	public AudioClip[]	audioClipArray;
	
	public void playRandomSound()
	{
		audioSource.clip = audioClipArray[Random.Range(0, audioClipArray.Length - 1)];
		audioSource.PlayOneShot(audioSource.clip);
	}
}
