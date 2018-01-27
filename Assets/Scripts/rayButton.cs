using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayButton : MonoBehaviour {

    private AudioSource audio;
    public GameObject abductionRay;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnMouseDown()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            Debug.Log(hit.transform.gameObject.tag);
            if (hit.transform.gameObject.tag == "button")
            {
                Debug.Log("Nappia painettu");
                hit.transform.GetComponent<Animator>().SetTrigger("press");
                if (!abductionRay.activeSelf)
                {
                    abductionRay.SetActive(true);
                    audio.Play();
                }
                else if (abductionRay.activeSelf)
                {
                    abductionRay.SetActive(false);
                    audio.Stop();
                }
            }

        }
    }
}
