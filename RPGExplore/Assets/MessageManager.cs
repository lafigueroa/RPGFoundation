using UnityEngine;
using System.Collections.Generic;

public class MessageManager : MonoBehaviour
{
	public Queue<string> messageQueue;
	
	public string currentMessage;
	
	public bool hasMessagesToDisplay;
	
	public float timeLeftForGUI;
	
	void Awake()
	{
		this.messageQueue = new Queue<string>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.messageQueue.Count > 0 && !hasMessagesToDisplay)
		{
			this.hasMessagesToDisplay = true;
			this.timeLeftForGUI = 5.0f;
			this.currentMessage = this.messageQueue.Dequeue();
		}
	}
	
	public static void AddMessage(string message)
	{
		if (!string.IsNullOrEmpty(message))
		{
			if (GameObject.FindGameObjectWithTag("MessageManager") == null)
			{
				Debug.LogWarning("Failed to find it");
			}
			else
			{
				MessageManager messageManager = GameObject.FindGameObjectWithTag("MessageManager").GetComponent<MessageManager>();
				
				messageManager.EnqueueMessage(message);
			}
		}
	}
	
	public void EnqueueMessage(string message)
	{
		this.messageQueue.Enqueue(message);
		Debug.Log(message);
	}
	
	void OnGUI()
	{
		if(this.hasMessagesToDisplay)
		{
			timeLeftForGUI -= Time.deltaTime;
			Rect guiRect = new Rect((Screen.width * .5f) - 200.0f, (Screen.height * .8f) - 20.0f, 400, 40);
			
			GUI.Box(guiRect, this.currentMessage);
		}
		
		if(timeLeftForGUI <= 0)
		{
			this.hasMessagesToDisplay = false;
		}
	}
}
