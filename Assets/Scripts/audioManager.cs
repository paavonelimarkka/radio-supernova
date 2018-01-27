using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
class audioManager : MonoBehaviour
{
    private static audioManager instance = null;
    public static audioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (audioManager)FindObjectOfType(typeof(audioManager));
            }
            return instance;
        }
    }

    void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
