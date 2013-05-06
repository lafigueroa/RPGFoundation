using UnityEngine;
using System.Collections;

public class SteadyScript : MonoBehaviour {
    Vector3 SteadyStatePos;
    Quaternion SteadyStateRot;
	// Use this for initialization
	void Start () {
        SteadyStatePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        SteadyStateRot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = SteadyStatePos;
        transform.rotation = SteadyStateRot;
	}
}
