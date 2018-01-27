using UnityEngine;
using System.Collections;

public class RattiScript : MonoBehaviour
{
    private bool dragging;
    public float wheelPosition;

    // Use this for initialization
    void Start()
    {
        dragging = false;
        wheelPosition = 0;
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

            float x = -Input.GetAxis("Mouse X");
            float y = -Input.GetAxis("Mouse Y");
            float speed = 3f;
            transform.localRotation *= Quaternion.AngleAxis(x * 10, Vector3.down);
            transform.localRotation *= Quaternion.AngleAxis(y * 10, Vector3.down);
            wheelPosition -= x * speed * Time.deltaTime;
        }
        wheelPosition = Mathf.Lerp(wheelPosition, 0, Time.deltaTime); 
    }

}
