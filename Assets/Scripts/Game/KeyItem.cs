using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyItem : MonoBehaviour
{
    public Image keyHUD;
    public AudioSource keySound;

    public static int keyCount;

    public void Start()
    {
        keyCount = 0;
        if (keyCount == 0)
        {
            keyHUD.gameObject.SetActive(false);
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            keyCount += 1;
            Destroy(gameObject);
            keyHUD.gameObject.SetActive(true);
            keySound.Play();
            Debug.Log("Key Taken");
            Debug.Log("Key: " + keyCount);
        }
    }
}
