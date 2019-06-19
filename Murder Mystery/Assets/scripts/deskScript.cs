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
    private Quaternion original;
    private Quaternion rotated;
    // Start is called before the first frame update
    void Start()
    {
        original = transform.rotation;
        transform.Rotate(0, 0, openDistance);
        rotated = transform.rotation;
        transform.Rotate(0, 0, -openDistance);
        open = false;
        close = false;
    }

    void Update()
    {
        if (open)
            transform.rotation = Quaternion.Lerp(transform.rotation, rotated, Time.deltaTime * smooth);
        if (close)
            transform.rotation = Quaternion.Lerp(transform.rotation, original, Time.deltaTime * smooth);
    }
    void OnMouseDown() {
        if (!locked) {
            if (open)
                closeDesk();
            else
                openDesk();
        }
    }
    private void openDesk() {
        open = true;
        close = false;
    }
    private void closeDesk() {
        close = true;
        open = false;
    }
}
