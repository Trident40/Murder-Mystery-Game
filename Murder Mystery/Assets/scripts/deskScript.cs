using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deskScript : MonoBehaviour
{
    private bool open;
    private bool close;
    [HideInInspector] public bool locked;
    public float openDistance;
    public float smooth;
    private float x;
    private float y;
    private Quaternion original;
    // Start is called before the first frame update
    void Start()
    {
        original = transform.rotation;
        open = false;
        close = false;
        x = transform.rotation.x;
        y = transform.rotation.y;
        Debug.Log("x " + x + " y " + y);
    }

    // Update is called once per frame
    void Update()
    {
        if (open) {
            Quaternion rotateTo = Quaternion.Euler(-90, 0, openDistance);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotateTo, Time.deltaTime * smooth);
        }
        if (close) {
            Quaternion rotateTo = original;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotateTo, Time.deltaTime * smooth);
        }
    }
    void OnMouseDown() {
        //Debug.Log(locked);
        if (!locked) {
            //Debug.Log("OPENING");
            if (open)
                closeDesk();
            else
                openDesk();
        }
    }
    /*
    public void maneuverDesk() {
        if (!locked) {
            if (open)
                closeDesk();
            else
                openDesk();
        }
    } */
    private void openDesk() {
        open = true;
        close = false;
        //transform.Rotate(0,0,180); //= new Quaternion(transform.rotation.x, transform.rotation.y, inverted ? -openDistance : openDistance, transform.rotation.w);
    }
    private void closeDesk() {
        close = true;
        open = false;
    }
}
