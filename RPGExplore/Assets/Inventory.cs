/// <summary>
/// The script which manages the inventory
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	
	//List of slots 
	public List<Slot> SlotList = new List<Slot>();
	//The next available empty slot
	public int nextEmptySlot;
	
	//The Player object
	CrazyBastard player;
	
	//List of actual items in inventory
	List<Item> ItemList = new List<Item>();
	
	//List of items that can be combined
	List <Item> CombinationList = new List<Item>();
	
	
	//Current position of the interface
	bool showInterface;
	public bool ShowInterface
	{
		get{return showInterface; }
		set{showInterface = value; }
	}
	
	//this game object
	GameObject thisObject;

	
	void Awake()
	{
		DontDestroyOnLoad(this);
	}
	
	void Start()
	{
		thisObject = this.gameObject;
		thisObject.transform.position = new Vector3(thisObject.transform.position.x, -2.5f, thisObject.transform.position.z);
		nextEmptySlot = 0;
		CheckSlotList();
	}
	
	void OnEnable()
	{
		//Debug.Log("Adding again?");
		TimeManagment.OnWorldReset += this.OnWorldReset();
	}
	
	TimeManagment.WorldResetDelegate OnWorldReset()
	{
		for (int i = 0; i < SlotList.Count; ++i)
		{
			if (SlotList[i].item != null)
			{
				if(!SlotList[i].item.isPersistant)
				{
					SlotList[i].EmptySlot();
					Debug.Log("Empty: " + SlotList[i].name);
				}
			}
		}
		
		return null;
	}
	
	
	#region Slot Checks
	/// <summary>
	/// Checks the slot list for empty items
	/// </summary>
	public void CheckSlotList()
	{
		nextEmptySlot = 0;
		for(int i = 0; i < SlotList.Count; i++)
		{
			if(SlotList[i].IsEmpty())
			{
				break;
			}
			else
			{
				nextEmptySlot++;
			}
		}
	}
	
	/// <summary>
	/// Adds the item to list.
	/// </summary>
	public void FillNextEmptySlot(Item t)
	{
		if(nextEmptySlot <= SlotList.Count)
		{
			SlotList[nextEmptySlot].FillSlot(t);
			ItemList.Add(t);
		}
		CheckSlotList();
	}
	
	#endregion
	
	#region Adding/Removing
	
	public void AddItemToList(Item t)
	{
		ItemList.Add(t);
	}
	
	/// <summary>
	/// Removes the item from list.
	/// </summary>
	public void RemoveItemFromList(Item t)
	{
		ItemList.Remove(t);
		Debug.Log("Removing " + t.gameObject.name + " from item list");
	}
	
	#endregion
	
	#region Combinations
	
	/// <summary>
	/// Adds to combine list.
	/// </summary>
	public void AddToCombineList(Item t)
	{
		CombinationList.Add(t);
	}
	
	/// <summary>
	/// Removes from combine list.
	/// </summary>
	public void RemoveFromCombineList(Item t)
	{
		CombinationList.Remove(t);
	}
	#endregion
	
	#region Other
	
	/// <summary>
	/// Toggle the interface.
	/// </summary>
	public void ToggleInterface()
	{
		if(!showInterface)
		{
			showInterface = true;
			thisObject.animation["ToggleInterface"].speed = 1.0f;
			thisObject.animation.Play("ToggleInterface");
		}
		else
		{
			showInterface = false;
			thisObject.animation["ToggleInterface"].speed = -1.0f;
			thisObject.animation["ToggleInterface"].time = thisObject.animation["ToggleInterface"].length;
			thisObject.animation.Play("ToggleInterface");
		}
	}
	
	#endregion
}
