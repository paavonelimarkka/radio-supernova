using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lehma : MonoBehaviour {

    public GameObject methaneMeter;
    public bool lehmaHit = false;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("LEHMÄ KERÄTTY!!");
            methaneMeter.transform.localScale += new Vector3(0, 20f, 0);
            Destroy(transform.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		if (lehmaHit)
        {
            transform.position += new Vector3(0, 1, 0);
        }
	}
}
