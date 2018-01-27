using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abductionRay : MonoBehaviour {
    public float totalTransmit = 0f;
    public Text transmitText;
    public Text winText;
    public GameObject againButton;
    public GameObject lastLehma = null;
    public GameObject methaneMeter;
    public GameObject playerContainer;
    //other.GetComponent<Transform>().transform.position += new Vector3(0, 100, 0);
    // Use this for initialization
    void Awake () {
        winText.enabled = false;
        againButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        methaneMeter.GetComponent<Methane>().depletionSpeed = 3f;
        RaycastHit hit;
        if (Physics.SphereCast(transform.position,20f, -Vector3.up, out hit))
        {
            if (hit.transform.tag == "lehma")
            {
                lastLehma = hit.collider.gameObject;
                lastLehma.GetComponent<lehma>().lehmaHit = true;
            }
            else if (hit.transform.tag == "transmitter")
            {
                hit.collider.gameObject.GetComponent<radiomasto>().transmitPower -= 5f * Time.deltaTime;
                totalTransmit += 5f * Time.deltaTime;
                Mathf.Round(totalTransmit);
                transmitText.text = totalTransmit.ToString("0") + " %" ; 
            }
            else
            {
                lastLehma.GetComponent<lehma>().lehmaHit = false;
            }
        }
        if (totalTransmit >= 100f)
        {
            againButton.SetActive(true);
            winText.enabled = true;
            playerContainer.GetComponent<Animator>().SetTrigger("takeoff");
        }
        
	}
}
