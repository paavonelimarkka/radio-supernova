using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Methane : MonoBehaviour
{
    public float depletionSpeed = 0f;
    public GameObject playerContainer;
    public GameObject abductionRay;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (depletionSpeed > 0f && GetComponent<Transform>().transform.localScale.y >= 0.1f)
        {
            //abductionRay.SetActive(true)
            playerContainer.GetComponent<MiddleNode>().gravitation = 10f;
            GetComponent<Transform>().transform.localScale -= new Vector3(0,0.3f,0) * Time.deltaTime * depletionSpeed;
        }
        depletionSpeed = 0f;
        if (GetComponent<Transform>().transform.localScale.y < 0.1f)
        {
            //abductionRay.SetActive(false);
            playerContainer.GetComponent<MiddleNode>().gravitation = 40f;
        }
    }
}
