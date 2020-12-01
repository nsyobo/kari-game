using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraRotate : MonoBehaviour
{ 
    Vector3 targetPos;
    [SerializeField]
    private float X = 200.0f;
    [SerializeField]
    private float Y = 200.0f;
    [SerializeField]
    private GameObject targetObj;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = targetObj.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");
        transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * X);
        if (transform.forward.y > 0.9f && mouseInputY < 0)
        {
            mouseInputY = 0;
        }
        if (transform.forward.y < -0.9f && mouseInputY > 0)
        {
            mouseInputY = 0;
        }
        transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * Y);
        targetPos = new Vector3(targetPos.x, targetPos.y, targetPos.z);
    }
}
