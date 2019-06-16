using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inventoryScript : MonoBehaviour
{
    public GameObject handPosition;
    public List<interactable> objects;
    public List<RawImage> images;
    [HideInInspector] public static interactable currentObject;
    private int selected;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(images.Count);
        for (int i = 0; i < objects.Count; i++) {
            objects[i].gameObject.transform.SetParent(handPosition.transform);
            objects[i].gameObject.transform.position = handPosition.transform.position;
            //objects[i].gameObject.GetComponent<Rigidbody>().isKinematic = true;
            objects[i].GetComponent<Rigidbody>().useGravity = false;
            objects[i].GetComponent<Collider>().enabled = false;
            objects[i].gameObject.SetActive(false);
            images[i].enabled = true;
            images[i].texture = objects[i].objectPNG;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i <= objects.Count; i++) {
            if (Input.GetKeyDown(i.ToString())) {
                SetSelected(i);
            }
        }
        if (Input.GetKeyDown("q")) {
            objects[selected].transform.parent = null;
            //objects[selected].GetComponent<Rigidbody>().isKinematic = false;
            objects[selected].GetComponent<Collider>().enabled = true;
            objects[selected].GetComponent<Rigidbody>().useGravity = true;
            Remove(selected);
            ResetImages();
            SetSelected(1);
        }
    }
    public void Add(interactable obj) {
        objects.Add(obj);
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(handPosition.transform);
        obj.transform.position = handPosition.transform.position;
        //obj.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Collider>().enabled = false;
        ResetImages();
    }
    private void ResetImages() {
        foreach (RawImage im in images) {
            im.gameObject.SetActive(false);
            im.texture = null;   
        }
        //Debug.Log("Count " + objects.Count);
        for (int i = 0; i < objects.Count; i++) {
            images[i].texture = objects[i].objectPNG;
            images[i].enabled = true;
            images[i].gameObject.SetActive(true);
        }
        if (objects.Count > 0)
            SetSelected(1);
    }
    public void Remove(int ind) {
        objects.Remove(objects[selected]);
    }
    public void SetSelected(int i) {
        selected = i - 1;
        foreach (interactable obj in objects) {
            obj.gameObject.SetActive(false);
        }
        foreach (RawImage image in images)
            image.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        objects[i - 1].gameObject.SetActive(true);
        images[i - 1].gameObject.transform.GetChild(0).gameObject.SetActive(true);
        currentObject = objects[i - 1];
    }
}
