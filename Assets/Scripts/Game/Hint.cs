using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    
    public Text interactText;
    public Image interactPopUp;
    public Image interactPopUpImage;

    private bool interactAllowed;

    // Start is called before the first frame update
    void Start()
    {
        interactText.gameObject.SetActive(false);
        interactPopUp.gameObject.SetActive(false);
        interactPopUpImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactText.gameObject.SetActive(true);
            interactPopUp.gameObject.SetActive(true);
            interactPopUpImage.gameObject.SetActive(true);
            interactAllowed = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactText.gameObject.SetActive(false);
            interactPopUp.gameObject.SetActive(false);
            interactPopUpImage.gameObject.SetActive(false);
            interactAllowed = false;
        }
    }
}
