using UnityEngine;
using System.Collections;

public class Area : MonoBehaviour {

    public GameObject [] objects;
    public GameObject player;
    public Transform startposition;
	// Use this for initialization
	void Start () 
    {
	foreach (GameObject g in objects)
        {
            g.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LoadArea()
    {
        foreach (GameObject g in objects)
        {
            g.SetActive(true);
        }
    }
}
