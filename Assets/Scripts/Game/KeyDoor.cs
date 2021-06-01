using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public GameObject popUp1;
    public GameObject popUp2;

    private Animator animator;
    public AudioSource doorSound;

    void Start()
    {
        animator = GetComponentInParent<Animator>();

        popUp1.gameObject.SetActive(false);
        popUp2.gameObject.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (KeyItem.keyCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    animator.SetTrigger("isOpened");
                    doorSound.Play();
                    KeyItem.keyCount--;
                    Debug.Log("Door Opened");
                    Debug.Log("Key: " + KeyItem.keyCount);
                }
                else
                {
                    popUp1.gameObject.SetActive(true);
                    Debug.Log("Open the Door!");
                }
            }
            else
            {  
                if (animator.GetBool("isOpened") == false)
                {
                    popUp2.gameObject.SetActive(true);
                    Debug.Log("Need a Key!");
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            popUp1.gameObject.SetActive(false);
            popUp2.gameObject.SetActive(false);
        }
    }

    void PauseAnimationEvent()
    {
        animator.enabled = false;
    }
}
