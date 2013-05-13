/// <summary>
/// Item slot for the inventory
/// </summary>
using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {
	
	enum ClickAction{Select, Combine}
	ClickAction clickAction = ClickAction.Select;
	
	
	/// <summary>
	/// The slot's current item
	/// </summary>
	public Item item;
	
	//The Player
	CrazyBastard player;
	
	/// <summary>
	/// The inventory.
	/// </summary>
	Inventory inventory;
	
	//The item object
	GameObject slotObject;
	
	//The selected object icon
	GameObject selectedIcon;
	
	//Is the object selected
	bool isSelected;
	public GameObject selectBG;
	
	/// <summary>
	/// Gets a value indicating whether this instance is selected.
	/// </summary>
	public bool IsSelected
	{
		get{return isSelected;}
	}
	
	private Slot()
	{
		
	}
	
	public static Slot Instance
	{
		get { return NestedSlot.instance; }
	}
	
	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable()
	{
		TimeManagment.OnWorldReset += OnWorldReset;
	}
	
	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable()
	{
		TimeManagment.OnWorldReset -= OnWorldReset;
	}
	
	/// <summary>
	/// Raises the world reset event.
	/// </summary>
	void OnWorldReset()
	{
		UnselectItem();
	}
	
	void Start()
	{
		slotObject = this.gameObject;
		selectBG.renderer.enabled = false;
		if(!inventory)
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
	}	
	
	/// <summary>
	/// Fills the slot with an item
	/// </summary>
	public void FillSlot(Item t)
	{
		if(!item)
		{
			item = t;
			slotObject.renderer.material.mainTexture = t.renderer.material.mainTexture;
			t.CurrentSlot = this;
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<CrazyBastard>();
			Debug.Log(slotObject.name + " now contains " + item.gameObject.name);
		}
	}
	
	/// <summary>
	/// Empties the slot.
	/// </summary>
	public void EmptySlot()
	{
		if(item)
		{
			inventory.RemoveItemFromList(item);
			item = null;
			slotObject.renderer.material.mainTexture = null;
			inventory.CheckSlotList();
			Debug.Log(slotObject.name + " is now empty");
		}
	}
	
	/// <summary>
	/// Checks the slot to see if it is empty
	/// </summary>
	public bool IsEmpty()
	{
		if(item == null)
			return true;
		else
			return false;
	}
	
	#region Selecting Objects
	
	void OnMouseDown()
	{
		ChooseClickAction();
	}
	
	/// <summary>
	/// Chooses the proper action for clicking.
	/// </summary>
	void ChooseClickAction()
	{
		switch(clickAction)
		{
		case ClickAction.Select:
			SelectItem();
			break;
			
		case ClickAction.Combine:
			break;
		}
	}
	
	/// <summary>
	/// Selects the item.
	/// </summary>
	public void SelectItem()
	{
		if(item && this != player.SelectedItem)
		{
			if(player.SelectedItem)
			{
				player.SelectedItem.CurrentSlot.UnselectItem();
			}
			if(!selectedIcon)
			{
				selectedIcon = GameObject.Find("SelectedIcon");
			}
			
			
			isSelected = true;
			selectBG.renderer.enabled = true;
			Debug.Log(item.gameObject.name + " has been selected");
			if(selectedIcon.renderer.enabled == false)
			{
				selectedIcon.renderer.enabled = true;
			}
			inventory.AddToCombineList(item);
			player.SelectedItem = item;
			selectedIcon.renderer.material.mainTexture = item.renderer.material.mainTexture;
		}
	}
	
	/// <summary>
	/// Deselects the item.
	/// </summary>
	public void UnselectItem()
	{
		if(item != null && player.SelectedItem == this.item)
		{
			isSelected = false;
			selectedIcon.renderer.material.mainTexture = null;
			selectBG.renderer.enabled = false;
			Debug.Log(item.gameObject.name + " has been unselected");
			inventory.RemoveFromCombineList(item);
			player.SelectedItem = null;
		}
	}
	
	void OnLevelWasLoaded(int x)
	{
		if(x < 8)
		{
			if(selectBG.renderer.enabled)
			{
				selectBG.renderer.enabled = false;
			}
		}
	}
	
	#endregion
	
	private class NestedSlot
	{
		static NestedSlot()
		{
		}
		
		internal static readonly Slot instance = new Slot();
	}
	
}
