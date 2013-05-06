using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {
	
	protected const string FORMAT_FailLoading = "Failed loading the {0}";
	
	protected GameObject inventory;
	protected GameObject player;
	protected GameObject timeLeft;
	protected GameObject messageManager;
	protected GameObject audioManager;
	protected GameObject gameLight;
	
	/// <summary>
	/// Awake this instance.
	/// </summary>
	protected virtual void Awake()
	{
		FindInventory();
		LoadAnna();
		LoadTimeLeft();
		LoadMessaging();
		LoadMainLight();
		LoadAudio();
	}
	
	/// <summary>
	/// Finds the inventory.
	/// </summary>
	protected virtual void FindInventory()
	{
		if(GameObject.FindGameObjectWithTag("Inventory") == null)
		{
			//Debug.LogWarning("Loading Inventory");
			inventory = Instantiate(Resources.Load("Inventory")) as GameObject;
			
			if (inventory != null)
			{
				inventory.name = "Inventory";
				inventory.tag = "Inventory";
			}
		}
		else
		{
			//Debug.LogWarning("Inventory Already Exist");
		}
	}
	
	/// <summary>
	/// Finds the player.
	/// </summary>
	protected virtual void LoadAnna()
	{
		if(GameObject.FindGameObjectWithTag("Player") == null)
		{
			//Debug.LogWarning("Loading Anna");
			player = Instantiate(Resources.Load("Player")) as GameObject;
			
			if (player != null)
			{
				player.name = "Player";
				player.tag = "Player";
			}
			else
			{
				Debug.LogError(string.Format(FORMAT_FailLoading, "Player"));
			}
		}
		else
		{
			//Debug.LogWarning("Anna Already Exist");
		}
	}
	
	/// <summary>
	/// Loads the time left.
	/// </summary>
	protected virtual void LoadTimeLeft()
	{
		if (GameObject.FindGameObjectWithTag("TimeLeftObject") == null)
		{
			//Debug.LogWarning("Loading TimeLeft");
			
			timeLeft = Instantiate(Resources.Load("TimeLeftObject")) as GameObject;
			
			if (timeLeft != null)
			{
				timeLeft.name = "timeLeft";
				timeLeft.tag = "TimeLeftObject";
			}
			else
			{
				Debug.LogError(string.Format(FORMAT_FailLoading, "TimeLeftObject"));
			}
		}
		else
		{
			//Debug.LogWarning("TimeLeft Already exists");
		}
	}
	
	protected virtual void LoadMessaging()
	{
		if (GameObject.FindGameObjectWithTag("MessageManager") == null)
		{
			//Debug.LogWarning("Loading MessageManager");
			
			messageManager = Instantiate(Resources.Load("MessageManager")) as GameObject;
			
			if (messageManager != null)
			{
				messageManager.name = "messageManager";
				messageManager.tag = "MessageManager";
			}
			else
			{
				Debug.LogError(string.Format(FORMAT_FailLoading, "MessageManager"));
			}
		}
		else
		{
			//Debug.LogWarning("MessageManager already exists");
		}
	}
	
	protected virtual void LoadAudio()
	{
		if(GameObject.FindGameObjectWithTag("AudioManager") == null)
		{
			//Debug.LogWarning("Loading AudioManager");
			audioManager = Instantiate(Resources.Load("AudioManager")) as GameObject;
			
			if(audioManager.name != null)
			{
				audioManager.name = "audioManager";
				audioManager.tag = "AudioManager";
			}
			else
			{
				Debug.LogError(string.Format(FORMAT_FailLoading, "AudioManager"));
			}		
		}
		else
		{
			//Debug.LogWarning("AudioManager already exists");
		}
	}
	
	protected virtual void LoadMainLight()
	{
		if(GameObject.FindGameObjectWithTag("GameLight") == null)
		{
			//Debug.LogWarning("Loading GameLight");
			gameLight = Instantiate(Resources.Load("GameLight")) as GameObject;
			
			if(gameLight.name != null)
			{
				gameLight.name = "GameLight";
				gameLight.tag = "GameLight";
			}
			else
			{
				Debug.LogError(string.Format(FORMAT_FailLoading, "GameLight"));
			}
		}
	}
}
