using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {
	
	//The item's name
	public string objectName;
	
	/// <summary>
	/// Object property.
	/// </summary>
	public enum ObjectProperty{None, Door}
	public ObjectProperty objectProperty;
	
	public bool hasItem;
	
	public Item item;
	
	public string description;
	
	protected float timeLeftForGUI = 0.0f;
	
	protected bool GUIShowing = false;
	
	// Use this for initialization
	void Start () {
		this.hasItem = false;
	}
	
	public virtual Item DoAction()
	{
	 	MessageManager.AddMessage(this.description);
		
		Item itemToGive = this.item;
		this.item = null;
		
		return itemToGive;
	}
	
	protected virtual void OnTriggerEnter(Collider other) {
		//Debug.Log("collision");
		CrazyBastard crazyBastard = getPlayer();
		crazyBastard.currentlyCollidedWorldObject = this;
    }
	
	protected virtual void OnTriggerExit(Collider other) {
		CrazyBastard crazyBastard = getPlayer();
		crazyBastard.currentlyCollidedWorldObject = null;
    }
	
	protected virtual CrazyBastard getPlayer() {
		CrazyBastard crazyBastard;
		crazyBastard = GameObject.FindGameObjectWithTag("Player").GetComponent<CrazyBastard>();
		return crazyBastard;
	}
}
