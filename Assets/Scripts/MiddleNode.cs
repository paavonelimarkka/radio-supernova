using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleNode : MonoBehaviour
{
    public GameObject player;
    public float gravitation;

    public GameObject verticalPump;
    public float verticalPumpPower;
    private Vector3 lastPumpPosition;

    public GameObject steeringWheel;

    public GameObject handThrottle;
    public float throttleMultiplier;

    public GameObject alert;
    public GameObject alertLight;
    private Animator pulse;

    private Vector3 screenPoint;
    private Vector3 offset;

    public bool dead;

    void Start()
    {
        lastPumpPosition = verticalPump.gameObject.transform.localPosition;
        dead = false;
        pulse = alertLight.GetComponent<Animator>();
    }

    void Update()
    {

        // Movement
        if (dead)
        {
            transform.Rotate(0, 0, 0);
        }
        else
        {
            //if (Input.GetKey(KeyCode.W))
            //    transform.Rotate(1, 0, 0);
            //if (Input.GetKey(KeyCode.S))
            //    transform.Rotate(-1, 0, 0);
            //if (Input.GetKey(KeyCode.A))
            //    transform.Rotate(0, -1, 0);
            //if (Input.GetKey(KeyCode.D))
            //    transform.Rotate(0, 1, 0);

            transform.Rotate(0, steeringWheel.gameObject.GetComponent<RattiScript>().wheelPosition, 0);

            transform.Rotate(handThrottle.gameObject.GetComponent<handThrottle>().throttlePosition * throttleMultiplier, 0, 0);
        }

        // Verticalpump
        if (!dead)
        player.GetComponent<Transform>().transform.localPosition -= new Vector3(0, (Time.deltaTime * gravitation), 0);
        if (lastPumpPosition != verticalPump.gameObject.transform.localPosition)
        {
            if (lastPumpPosition.y > verticalPump.gameObject.transform.localPosition.y)
            {
                player.GetComponent<Transform>().transform.localPosition += new Vector3(0, (lastPumpPosition.y - verticalPump.gameObject.transform.localPosition.y) *(verticalPumpPower), 0);
            }
            lastPumpPosition = verticalPump.gameObject.transform.localPosition;
        }

        // Alert light
        if (player.GetComponent<Transform>().transform.localPosition.y - 1200 < 70 && !dead)
        {
            alert.gameObject.SetActive(true);
            pulse.speed = Mathf.Clamp(30 / (player.GetComponent<Transform>().transform.localPosition.y - 1200), 0.5f, 4);
        } else if (!dead)
        {
            alert.gameObject.SetActive(false);
        }
        if (dead) 
        {
            pulse.speed = 0;
            alertLight.gameObject.GetComponent<Light>().enabled = true;
        }
        
    }
}