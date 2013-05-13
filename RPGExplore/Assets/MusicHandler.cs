/// <summary>
/// Manages the music files
/// </summary>
using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {
	
	//The main music that will play throughout the game
	public AudioSource mainTheme;
	
	void Awake()
	{
		DontDestroyOnLoad(this);
	}
	
	IEnumerator Start()
	{
		yield return new WaitForSeconds(2.0f);
		mainTheme.Play();
		FadeIn(mainTheme, 2.0f);
	}
	
	/// <summary>
	/// Fades in audio file.
	/// </summary>
	void FadeIn(AudioSource music, float duration)
	{
		music.FadeIn(music.clip, duration, () => {Debug.Log("Done Fading In");});
	}
}
