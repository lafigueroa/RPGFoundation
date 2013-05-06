/// <summary>
/// Manages the game camera
/// </summary>
using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	
	//The player
	CrazyBastard player;
	
	//Enables/disables the camera from following the player
	public bool follow;
	
	#region Getters/Setters
	
	public bool Follow
	{
		get{ return follow; }
		set{ follow = value; }
	}
	
	#endregion
	
	// Use this for initialization
	IEnumerator Start () 
	{
		
		if(follow)
		{
//			follow = false;
//			yield return new WaitForSeconds(6.0f);	
			yield return new WaitForSeconds(0.5f);
			FindPlayer();
			follow = true;
		}
		else
		{
			yield return new WaitForSeconds(2.5f);		
			FindPlayer();
		}
	}
	
	/// <summary>
	/// Finds the player if player is null
	/// </summary>
	void FindPlayer()
	{
		if(!player)
		{
			try
			{
				player = GameObject.FindGameObjectWithTag("Player").GetComponent<CrazyBastard>();
			}
			catch(System.Exception)
			{
				Debug.LogWarning("Player not found");
			}
		}
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		FollowPlayer();
	}
	
	/// <summary>
	/// Follows the player if followPlayer is enabled
	/// </summary>
	void FollowPlayer()
	{
		if(follow)
		{
			if(!player) {
				FindPlayer();
			}
			camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
		}
	}
}
