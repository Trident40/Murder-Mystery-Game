using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockScript : MonoBehaviour
{
    public deskScript lockedObject;
    protected bool unlocked = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (unlocked) {
            lockedObject.locked = false;
            Object.Destroy(gameObject);
        }
        else
            lockedObject.locked = true;
    }

}
