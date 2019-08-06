using System.Collections.Generic;
using UnityEngine;

public class InteractableWithID : interactable
{
    public GameObject linkedObj;
    void Update() {
        if (transform.position.y < plane.position.y) {
            transform.position = originalposition;
        }
    }
    private void pickUp() {
        inventory.SimpleAdd(this);
        linkedObj.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Dropped() {
        transform.position = linkedObj.transform.position;
        transform.parent = null;
        linkedObj.SetActive(false);
        gameObject.SetActive(true);
    }
    void OnMouseDown() {
        pickUp();
    }
}
