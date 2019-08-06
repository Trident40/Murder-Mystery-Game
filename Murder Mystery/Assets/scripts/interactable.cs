using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class interactable : MonoBehaviour
{
    public Texture2D objectPNG;
    public const float instantiateOffset = 10f; 
    public static inventoryScript inventory;
    public static Transform plane;
    protected Vector3 originalposition;

    void Start() {
        originalposition = transform.position;
        plane = GameObject.FindGameObjectWithTag("plane").transform;
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<inventoryScript>();
    }
    void Update() {
        if (transform.position.y < plane.position.y) {
            transform.position = originalposition;
        }
    }
    private void pickUp() {
        inventory.Add(gameObject.GetComponent<interactable>());
    }
    void OnMouseDown() {
        pickUp();
    }
}
