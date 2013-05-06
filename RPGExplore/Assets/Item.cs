/// <summary>
/// Base class for items
/// </summary>
using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	
	//The name of the item
	public string itemName;
	
	/// <summary>
	/// Special Property of the item
	/// </summary>
	public enum ItemProperty{None, Key, Weapon, AnnasDoorKey, chain, hallway2key, pillow, somethingElse, pornoMag, fork, uniform}
	public ItemProperty itemProperty;
	
	//The inventory 
	Inventory inventory;
	
	//The current slot the item is in 
	Slot slot;
	
	//The Item gameObject
	GameObject itemObject;
	
	//The Object's Art
	public Texture objectArt;
	
	//is the item persistant
	public bool isPersistant;
	
	//was the item collected
	bool isCollected;
	
	public Slot CurrentSlot
	{
		get{ return slot;}
		set{ slot = value;}
	}
	
	IEnumerator Start()
	{
		yield return new WaitForSeconds(1.0f);
		SetUpItem();
	}
	
	/// <summary>
	/// Basic set up that all items will have
	/// </summary>
	protected void SetUpItem()
	{
		itemObject = this.gameObject;
		itemObject.collider.isTrigger = true;
		if(isPersistant)
		{
			DontDestroyOnLoad(this);
		}
		FindInventory();
	}
	
	/// <summary>
	/// Finds the inventory object
	/// </summary>
	void FindInventory()
	{
		if(!inventory)
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
	}
	
	public void Use() 
	{
		AddToInventory();
		Disable();
	}
	
	/// <summary>
	/// Adds the item to the inventory
	/// </summary>
	public virtual void AddToInventory()
	{
		inventory.FillNextEmptySlot(this);
	}
	
	/// <summary>
	/// Disable this instance.
	/// </summary>
	public void Disable() 
	{
		renderer.enabled = false;
		collider.enabled = false;
	}
	
	/// <summary>
	/// Performs the specifc items action if necessary
	/// </summary>
	protected virtual void PerformAction()
	{
		
	}
	
	void OnTriggerEnter(Collider other) {
		CrazyBastard crazyBastard = getPlayer();
		crazyBastard.currentlyCollidedItem = this;
    }
	
	void OnTriggerExit(Collider other) {		
		CrazyBastard crazyBastard = getPlayer();
		crazyBastard.currentlyCollidedItem = null;
    }
	
	CrazyBastard getPlayer() {
		CrazyBastard crazyBastard;
		crazyBastard = GameObject.FindGameObjectWithTag("Player").GetComponent<CrazyBastard>();
		return crazyBastard;
	}
}
