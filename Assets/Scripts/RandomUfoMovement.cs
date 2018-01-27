using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUfoMovement : MonoBehaviour {

	private Transform ufoTF;
	public float ufoSpeed = 10;

	// Use this for initialization
	void Start () {
		ufoTF = GetComponent<Transform>();
		ufoTF.Rotate(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360));
	}
	
	// Update is called once per frame
	void Update () {
		ufoTF.Rotate(ufoSpeed * Time.deltaTime, 0, 0);
	}

}
