using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalPumpControl : MonoBehaviour {

    private bool dragging;

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

    void Update()
    {

        if (dragging)
        {
            float y = Input.GetAxis("Mouse Y");
            transform.localPosition += new Vector3(0, y, 0);
            if (transform.localPosition.y >= 3)
                transform.localPosition = new Vector3(5, 3, 0);
            if (transform.localPosition.y <= -3)
                transform.localPosition = new Vector3(5, -3, 0);
        }
    }
}
