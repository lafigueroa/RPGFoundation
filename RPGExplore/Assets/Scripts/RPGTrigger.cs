using UnityEngine;
using System.Collections;

public class RPGTrigger : MonoBehaviour {

    public string ObjectName;
    protected GameObject newButton;
    public Material newButtonMaterial;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        Debug.Log("What go on?");
        if (ObjectName == "Hello")
        {
            if(!newButton)
            {
                if (!Resources.Load("Scripts/Button"))
                    Debug.Log("Oops");
                newButton = Instantiate(Resources.Load("Button")) as GameObject;
                newButton.name = "Help";
                Vector3 buttonPos = new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z);
                newButton.transform.position = buttonPos;
                newButton.renderer.material = newButtonMaterial;
            }
        }
        if (ObjectName == "Goodbye")
            Application.Quit();
    }
}
