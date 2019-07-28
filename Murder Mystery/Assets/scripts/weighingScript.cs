using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weighingScript : MonoBehaviour
{
    public Text weightValue;
    // Start is called before the first frame update
    /*
    void OnCollisionExit(Collision collision) {
        Debug.Log("Stopped colliding");
        GetComponent<MeshRenderer>().materials[0].color = original;
        weightValue.text = "0.00";
    } */
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnMouseDown() {
        if (inventoryScript.currentObject.GetComponent<Weighable>() != null) {
            weightValue.text = System.Math.Round(inventoryScript.currentObject.GetComponent<Weighable>().weight, 2).ToString();
        }
    }
}
