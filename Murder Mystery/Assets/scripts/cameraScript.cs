using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public float sensitivity;
    public CursorLockMode cursorLock;
    private float xRot = 0.0f;
    private float yRot = 0.0f;
    [HideInInspector] public float currentX;
    [HideInInspector] public float currentY;
    [HideInInspector] public float velocityX;
    [HideInInspector] public float velocityY;
    public float shiftOffset;
    private Vector3 shiftPose;
    private Vector3 originalPose;
    void Start()
    {
        originalPose = transform.position;
        shiftPose = new Vector3(transform.position.x, transform.position.y - shiftOffset, transform.position.z);
        Cursor.lockState = cursorLock;
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.LeftShift))
            transform.position = shiftPose;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            transform.position = originalPose; */
        xRot -= sensitivity * Input.GetAxis("Mouse Y");
        yRot += sensitivity * Input.GetAxis("Mouse X");
        xRot = Mathf.Clamp(xRot, -90, 90);
        currentX = Mathf.SmoothDamp(currentX, xRot, ref velocityX, 0.1f);
        currentY = Mathf.SmoothDamp(currentY, yRot, ref velocityY, 0.1f);
        transform.rotation = Quaternion.Euler(currentX, currentY, 0.0f);

    }
}
