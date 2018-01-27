using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiomasto : MonoBehaviour {

    public float transmitPower = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transmitPower <= 0f)
        {
            Destroy(gameObject);
        }
	}
}
