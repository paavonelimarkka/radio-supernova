using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cockpit : MonoBehaviour {

    public GameObject playerContainer;
    public GameObject cracks;
    public GameObject againButton;

	// Use this for initialization
	void Start () {
		
	} 
	
	// Update is called once per frame
	void Update () {
		 
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.tag == "planet" || collision.gameObject.layer == 10)
        {
            playerContainer.gameObject.GetComponent<MiddleNode>().dead = true;
            cracks.gameObject.SetActive(true);
            againButton.SetActive(true);
        }
    }
}
