using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; 
    public Transform playerBody;
    float xRoration = 0f;

    public int zoom = 20;
    public int normal = 60;
    public float smooth = 5;

    private bool isZoomed = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = !isZoomed;
        }
        
        if (isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        }
        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; 
        xRoration -= mouseY; 
        xRoration = Mathf.Clamp(xRoration, -90f, 90f); 
        transform.localRotation = Quaternion.Euler(xRoration, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX); 
    }
}