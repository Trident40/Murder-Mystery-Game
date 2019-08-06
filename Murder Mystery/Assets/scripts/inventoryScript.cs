using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inventoryScript : MonoBehaviour
{
    public GameObject handPosition;
    public List<interactable> objects;
    public List<RawImage> images;
    public Camera currentCam;
    public ParticleSystem impact;
    [HideInInspector] public static interactable currentObject;
    private int selected;
    public cameraScript camerascript;
    public Button choiceButton;
    private List<Button> buttons = new List<Button>();

    void Start()
    {
        if (choiceButton != null)
            choiceButton.gameObject.SetActive(false);
        for (int i = 0; i < objects.Count; i++) {
            objects[i].gameObject.transform.SetParent(handPosition.transform);
            objects[i].gameObject.transform.position = handPosition.transform.position;
            objects[i].GetComponent<Rigidbody>().useGravity = false;
            objects[i].GetComponent<Collider>().enabled = false;
            objects[i].gameObject.SetActive(false);
            images[i].enabled = true;
            images[i].texture = objects[i].objectPNG;
        }
    }
    /*
    private void makeChoice(Button buttonVar) {
        Debug.Log(buttons.Count);
        Debug.Log(buttonVar.transform.GetComponentInChildren<Text>().text);
        choiceButton.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        foreach (Button button in buttons)
            button.gameObject.SetActive(false);
        for (int i = 1; i < buttons.Count; i++) {
            buttons.Remove(buttons[1]);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = true;
        camerascript.enabled = true;
    }
    private void chooseBtwFunction(string[] choices, bool pickUp) {
        camerascript.enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        int index = 1;
        int factor = 1;
        float height = choiceButton.gameObject.GetComponent<RectTransform>().rect.height;

        choiceButton.gameObject.SetActive(true);
        choiceButton.onClick.AddListener(() => { makeChoice(choiceButton); } );
        choiceButton.GetComponentInChildren<Text>().text = choices[0];
        buttons.Add(choiceButton);
        for (int i = 1; i < choices.Length; i++) {
            Button newButton = Instantiate(choiceButton);
            if (pickUp)
                newButton.onClick.AddListener(() => { makeChoice(newButton); });
            newButton.gameObject.transform.SetParent(choiceButton.transform.parent);
            newButton.gameObject.GetComponent<RectTransform>().position = new Vector3(choiceButton.gameObject.transform.position.x, choiceButton.gameObject.transform.position.y + (height * index * factor), choiceButton.gameObject.transform.position.z);
            if (factor < 0)
                index++;
            factor *= -1;
            newButton.GetComponentInChildren<Text>().text = choices[i];
            buttons.Add(newButton);
        }
    }
    private void chooseBtw(params string [] choices) {
        chooseBtwFunction(choices, true);
    }
    */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && camerascript.enabled && currentObject != null) {
            RaycastHit hit;
            if (Physics.Raycast(currentCam.gameObject.transform.position, currentCam.gameObject.transform.forward, out hit, 100)) {
                if (currentObject.GetComponent<Weapon>() != null) {
                    Weapon gun = currentObject.GetComponent<Weapon>();
                    if (gun.fire()) {
                        Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
                    }
                }
            }
        }
        for (int i = 1; i <= objects.Count; i++) {
            if (Input.GetKeyDown(i.ToString())) {
                SetSelected(i);
            }
        }
        if (Input.GetKeyDown("q")) {
            if (currentObject.GetComponent<InteractableWithID>() == null)
                Drop();
            else
                SimpleDrop(currentObject.GetComponent<InteractableWithID>());
        }
    }
    public interactable Drop() {
        objects[selected].transform.parent = null;
        //objects[selected].GetComponent<Rigidbody>().isKinematic = false;
        objects[selected].GetComponent<Collider>().enabled = true;
        objects[selected].GetComponent<Rigidbody>().useGravity = true;
        interactable g = objects[selected];
        Remove();
        ResetImages();
        SetSelected(1);
        return g;
    }
    public void SimpleDrop(InteractableWithID interactableObj) {
        interactableObj.Dropped();
        Remove();
        ResetImages();
        SetSelected(1);
    }
    public void Add(interactable obj) {
        //chooseBtw("Pick Up", "Cancel");
        objects.Add(obj);
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(handPosition.transform);
        obj.transform.position = handPosition.transform.position;
        //obj.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Collider>().enabled = false;
        ResetImages();
    }
    public void SimpleAdd(InteractableWithID obj) {
        objects.Add(obj);
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
    public void Remove() {
        objects.Remove(objects[selected]);
    }
    public void SetSelected(int i) {
        foreach (interactable obj in objects) {
            obj.gameObject.SetActive(false);
        }
        foreach (RawImage image in images)
            image.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        selected = i - 1;
        if (objects.Count > 0) {
            objects[i - 1].gameObject.SetActive(true);
            images[i - 1].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            currentObject = objects[i - 1];
        }
    }
}
