using UnityEngine;
using System;
using System.Collections;

public class TimeManagment : MonoBehaviour
{
	private const float CONST_LevelResetTime = 	200.0f;
	private const float CONST_HoursTilCrazy = 12;
	public float currentTimeLeft;
	private float timeLeftAsHours;
	
	private DateTime time;
	private static int daysPassed = 1;
	
	public static bool isTimePaused;
	
	private float elapsedTime;
	
	public delegate void WorldResetDelegate();
	public static event WorldResetDelegate OnWorldReset;
	
	Light gameLight;
	
	public static float ResetTime
	{
		get{return CONST_LevelResetTime;}
	}
	
	void Awake()
	{
		DontDestroyOnLoad(this);
	}
	
	// todo: add pause / resume functionality
	// todo: look at changing lighting during
	
	// Use this for initialization
	IEnumerator Start ()
	{
		//isTimePaused = true;
		
		this.elapsedTime = 0.0f;
		
		this.currentTimeLeft = CONST_LevelResetTime;
		
		time = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
		
		time = time.AddHours(9);
		time = time.AddDays(daysPassed);
		
		StartCoroutine(FindGameLight());
		
		yield return new WaitForSeconds(1.0f);
//		
//		isTimePaused = false;
		StartCoroutine(gameLight.FadeToMadness(CONST_LevelResetTime, null));
		
		
	}
	
	/// <summary>
	/// This will countdown the time form the levelresettime value
	/// in seconds, and will proportionalize the time until the
	/// player goes crazy.
	/// </summary>
	void Update ()
	{
		if (!isTimePaused)
		{
			this.elapsedTime += Time.deltaTime;
			
			if (true)//(this.elapsedTime >= 1.0f)
			{
				this.elapsedTime  = 0.0f;
				
				float secThing = (CONST_HoursTilCrazy * 60 * 60) / (CONST_LevelResetTime);
			
				time = time.AddSeconds(secThing * Time.deltaTime);
			}
			
			this.currentTimeLeft -= Time.deltaTime * 1.0f;
		}
		
		// The day has passed, reset Anna to her
		// room and reset the environment properly
		if (this.currentTimeLeft <= 0.0f)
		{
			// todo: make this a level that stops everything
			// dims the scene and resets everything.
			
//			if (OnWorldReset != null)
//			{
//				OnWorldReset();
//				Debug.Log("Trying to reset world.");
//			}
			
			StartCoroutine(Reset());
			
//			++daysPassed;
//			
//			Application.LoadLevel("AnnasRoom");
		}
	}
	
	void OnLevelWasLoaded(int x)
	{
//		if(x <= 7)
//		{
//			isTimePaused = true;
//			yield return new WaitForSeconds(6.0f);
//			isTimePaused = false;
//		}
	}
	
	/// <summary>
	/// Finds the game light.
	/// </summary>
	IEnumerator	FindGameLight()
	{
		yield return new WaitForSeconds(1.0f);
		if(!gameLight)
		{
			//Debug.Log("Finding Light");
			gameLight = GameObject.FindGameObjectWithTag("GameLight").GetComponent<Light>();
		}
	}
	
	public IEnumerator Reset()
	{
		if (OnWorldReset != null)
		{
			OnWorldReset();
			Debug.Log("Trying to reset world.");
		}
		
		++daysPassed;
			
		Application.LoadLevel("AnnasRoom");
		
		
		this.elapsedTime = 0.0f;
		this.currentTimeLeft = CONST_LevelResetTime;
		time = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
		
		time = time.AddHours(9);
		time = time.AddDays(daysPassed);
		
		yield return new WaitForSeconds(2.0f);
		
		gameLight.color = Color.white;
		StartCoroutine(gameLight.FadeToMadness(CONST_LevelResetTime, null));
	}
	
	/// <summary>
	/// Raises the GU event.
	/// Displays the time left in hours to the screen with the tenths position shown
	/// </summary>
	void OnGUI()
	{
		//GUI.Box(new Rect(10, 10, 60, 20), string.Format("{0} hrs", this.timeLeftAsHours.ToString("00.0")));
		GUI.Box(new Rect(10, 10, 200, 25), string.Format("Day {0}, {1}", daysPassed, this.time.ToString("dddd hh:mm tt")));
	}
}
