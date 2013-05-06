/// <summary>
/// Game light script
/// </summary>
using UnityEngine;
using System.Collections;

public class GameLight : MonoBehaviour {
	
	Light lightObject;
	
	void Awake()
	{
		DontDestroyOnLoad(this);
	}
	
	void Start()
	{
		lightObject = this.light;
		lightObject.color = Color.white;
	}
	
//	void OnEnable()
//	{
//		TimeManagment.OnWorldReset += OnWorldReset;
//	}
//	
//	void OnDisable()
//	{
//		TimeManagment.OnWorldReset -= OnWorldReset;
//	}
//	
//	void OnWorldReset()
//	{
//		Debug.Log("Resetting Light");
//		lightObject.color = Color.blue;
//	}
}
