using UnityEngine;
using System.Collections;


public class CrazyBastard : MonoBehaviour {

	private bool Sane = false;
	private enum MovementDirection { Up, Down, Left, Right };
	private float movementNormalizer = 0.707f;
	private float movementSpeed = 2.25f;
	private float rotationSpeed = 0.3f;
	private float previousAngle = 0.0f;
	private Vector3 previousMovement;
	public Item currentlyCollidedItem;
	public WorldObject currentlyCollidedWorldObject;
	
	bool bMoving; //foltz
	//sprite anim vars (foltz)
	float frameS = 0.05f; //hardcoding frame to update every 50 Ms when moving (foltz)
	float accumFrameS = 0.0f;
	int frame = 0;
	public int numFrames = 12; //hardcoded to 12 frames
	//float offsetX = 0.25f;//0.083f; //0.1667f;
	//public int curFrame = 1;
	//end sprite anim vars
	
	//The game inventory
	Inventory inventory;
	
	//The currently selected Item
	Item selectedItem;
	
	//The Selected Item Icon
	public GameObject selectedIcon;
	
	public Item SelectedItem
	{
		get{ return selectedItem; }
		set{ selectedItem = value; }
	}
	
	private bool enableMove;
	public bool EnableMove
	{
		get{return enableMove;}
		set{enableMove = value;}
	}
	
	void OnEnable()
	{
		//TimeManagment.OnWorldReset += this.OnWorldReset();
	}
	
	void OnDisable()
	{
		//TimeManagment.OnWorldReset -= this.OnWorldReset();
	}
	
	TimeManagment.WorldResetDelegate OnWorldReset()
	{
		// todo: reset daily statuses
		selectedItem = null;
		gameObject.transform.position = Vector3.zero;
		return null;
	}
	
	// Use this for initialization
	IEnumerator Start()
	{
		enableMove = true;
		DontDestroyOnLoad(this);
		yield return new WaitForSeconds(1.0f);
		if(!inventory)
		{
			try
			{
				//inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
			}
			catch(System.Exception)
			{
				Debug.LogWarning("Inventory not found by player");
			}
		}
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(enableMove)
		Move();
		
		if(Input.GetButtonDown("Fire1") && !TimeManagment.isTimePaused) {
			Use();
		}
		
		if(Input.GetKeyDown(KeyCode.Space) && enableMove)
		{
			//inventory.ToggleInterface();
		}
		
		//UpdateSprite();
	}
	
	
	
	//float offSetX;
	
	private void Move() {
		CharacterController controller = GetComponent<CharacterController>();
		float horiz = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");
		
		if(horiz != 0 && vert != 0) 
		{
			horiz *= 0.707f;
			vert *= 0.707f;
		}
		
		if(Mathf.Abs(horiz) > 0.0f || Mathf.Abs(vert) > 0.0f) //if moving animate character, else draw static frame
		{
			/*offSetX += 0.1667f;
			renderer.material.mainTextureOffset = new Vector2(offSetX, 0.0f);
			curFrame += 1;
			if(curFrame > numFrames)
			{
				renderer.material.mainTextureOffset = new Vector2(0.0f, 0.0f);
				offSetX = 0.0f;
				curFrame = 1;
			}*/
			bMoving = true; //foltz
		}
		else
		{
			/*renderer.material.mainTextureOffset = new Vector2(0.0f, 0.0f);
			offSetX = 0.0f;
			curFrame = 1;*/
			bMoving = false;
		}
		
		Vector3 moveDirection = new Vector3(horiz, vert, 0);
		//Quaternion rotation = new Quaternion(0.0f, 0.0f, 1.0f, ChangeHeading(horiz, vert));
		
		//Reset and rerotate
		//controller.transform.rotation = Quaternion.identity;
		//controller.transform.RotateAround(controller.transform.position, new Vector3(0, 0, 1), ChangeHeading(horiz, vert));
		
		bool run = false;
		
		if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			run = true;
		}
		else
		{
			run = false;
		}
		
		movementSpeed = run ? 3.50f : 2.25f;
		
		//Move Character
		controller.Move(moveDirection * Time.deltaTime * movementSpeed);
	}
	
//	private void UpdateSprite()
//	{
//		/*if(bMoving)
//		{
//			accumFrameS += Time.deltaTime;
//			if (accumFrameS >= frameS)
//			{
//				accumFrameS = 0.0f;
//				frame += 1;
//				if (frame == numFrames)
//				{
//					frame = 0;
//				}
//			}
//		}
//		else if(bMoving == false)
//		{
//			frame = 0;
//		}
//		Debug.Log (frame);
//		//render code below here
//		float offsetX; 
//		offsetX = (float)(frame / numFrames);
//		//Debug.Log (offsetX);
//		renderer.material.mainTextureOffset = new Vector2((float)frame * offsetX, 0.0f);*/
//	}
	
	
	private float ChangeHeading(float horiz, float vert) {
		float desiredAngle = previousAngle;
		
		if(horiz > 0) {
			desiredAngle = 90.0f;
		}
		if(horiz < 0) {
			desiredAngle = 270.0f;
		}
		if(vert > 0) {
			desiredAngle = 180.0f;		
		}
		if(vert < 0) {
			desiredAngle = 0.0f;
		}
		previousAngle = desiredAngle;
		
		return desiredAngle;
		
	}
	
	private void Use() {
		if(currentlyCollidedItem != null)
		{
			currentlyCollidedItem.Use();
			currentlyCollidedItem = null;
		}
		else if(currentlyCollidedWorldObject != null)
		{
			Item item = currentlyCollidedWorldObject.DoAction();
			
			if (item != null)
			{
				inventory.FillNextEmptySlot(item);
			}
		}
		
	}
	
	private void Say (string quote) {
		
	}
	
}
