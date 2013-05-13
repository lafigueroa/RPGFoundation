/// <summary>
/// Audio extension methods.
/// </summary>
using UnityEngine;
using System;
using System.Collections;

public static class AudioSourceExtension
{
	
	public static IEnumerator FadeIn(this AudioSource audioSource, AudioClip audioClip, float duration, Action OnComplete)
	{
		float startingVolume = audioSource.volume;
		
		while(audioSource.volume < 1.0f)
		{
			audioSource.volume += Time.deltaTime * startingVolume/duration;
			yield return null;
		}
		
		if(OnComplete != null)
		OnComplete();
	}
	
	/// <summary>
	/// Fades the audio out
	/// </summary>
	public static IEnumerator FadeOut(this AudioSource audioSource, AudioClip audioClip, float duration, Action OnComplete)
	{
		float startingVolume = audioSource.volume;
		
		while(audioSource.volume > 0.0f)
		{
			audioSource.volume -= Time.deltaTime * startingVolume/duration;
			yield return null;
		}
		
		if(OnComplete != null)
		OnComplete();
		
	}
	
}
