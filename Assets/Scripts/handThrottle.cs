using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handThrottle : MonoBehaviour {

    private bool dragging;
    public float throttlePosition;

    // Use this for initialization
    void Start()
    {
        dragging = false;
    }

    void OnMouseDown()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.transform.gameObject.tag == gameObject.tag)
            {
                dragging = true;
            }

        }
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    // Update is called once per frame
    void Update () {
        if (dragging)
        {
            //float x = -Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            float speed = 10;
            //transform.localRotation *= Quaternion.AngleAxis(x * speed, Vector3.down);
            transform.localRotation *= Quaternion.AngleAxis(y * speed, Vector3.back);
            throttlePosition -= y / 5;

            if (transform.localRotation.eulerAngles.z < 360 && transform.localRotation.eulerAngles.z > 120)
            {
                transform.localEulerAngles = new Vector3(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, 0);
                throttlePosition = 0;
            }
                

            if (transform.localRotation.eulerAngles.z < 120 && transform.localRotation.eulerAngles.z > 50)
            {
                transform.localEulerAngles = new Vector3(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, 50);
                throttlePosition = 1;
            }
        }
    }
}
