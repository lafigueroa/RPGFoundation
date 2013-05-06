/// <summary>
/// Light search.
/// </summary>
using UnityEngine;
using System.Collections;

public class LightSearch : MonoBehaviour {
	
	//The tower
	public SpotLight tower;
	
	//the alarm
	AudioSource alarm;
	
	TimeManagment timeManager;
	
	void Start()
	{
		alarm = GetComponent<AudioSource>(); 
		timeManager = GameObject.FindGameObjectWithTag("TimeLeftObject").GetComponent<TimeManagment>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			CrazyBastard player = other.GetComponent<CrazyBastard>();
			player.EnableMove = false;
			alarm.Play();
			tower.animation.Stop();
			StartCoroutine(ResetGame());
		}
	}
	
	IEnumerator ResetGame()
	{
		yield return new WaitForSeconds(3.0f);
		StartCoroutine(timeManager.Reset());
	}
}
