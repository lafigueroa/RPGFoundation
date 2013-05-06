using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
    double xspeed;
    double yspeed;
    double hPrev;
    double vPrev;
    const double SPEED = 0.1;

    public GameObject leCamera;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<CharacterController>().enabled = true;
        xspeed = 0;
        yspeed = 0;
        hPrev = 0;
        vPrev = 0;

        leCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {

        var h = Input.GetAxis("Horizontal");

        if (( h < 0 && h <= hPrev) || h == -1.0)
        {
            xspeed = -1.0  * SPEED;
        }
        else if (( h > 0 && h >= hPrev) || h == 1.0)
        {
            xspeed = SPEED;
        }
        else
        {
            xspeed = 0;
        }
        hPrev = h;

        var v = Input.GetAxis("Vertical");
        if ((v < 0 && v <= vPrev) || v == -1.0)
        {
            yspeed = -1.0 * SPEED;
        }
        else if ((v > 0 && v >= vPrev) || v == 1.0)
        {
            yspeed = SPEED;
        }
        else
        {
            yspeed = 0;
        }

        vPrev = v;
        Vector3 finalSpeed = new Vector3((float)xspeed, (float)yspeed);
        transform.Translate(finalSpeed);

        leCamera.transform.Translate( new Vector3 ((float)xspeed,(float) yspeed));

        }
    /*
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Touching");
        if (collision.transform.position.x > transform.position.x)
            xspeed = Mathf.Max((float)xspeed, 0f);
        if (collision.transform.position.y > transform.position.y)
            yspeed = Mathf.Max((float)yspeed, 0f);
        if (collision.transform.position.x < transform.position.x)
            xspeed = Mathf.Min((float)xspeed, 0f);
        if (collision.transform.position.y < transform.position.y)
            yspeed = Mathf.Min((float)yspeed, 0f);
        
    }
     * */
	}
