using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class padlockScript : lockScript
{
    public interactable key;
    private inventoryScript inventory;
    void Start() {
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<inventoryScript>();
    }
    void OnMouseDown() {
        if (inventoryScript.currentObject != null && inventoryScript.currentObject.Equals(key))
            unlocked = true;
    }
}
