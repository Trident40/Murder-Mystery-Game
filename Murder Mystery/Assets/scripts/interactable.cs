using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class interactable : MonoBehaviour
{
    public string [] choices;
    public cameraScript camerascript;
    public Button choiceButton;
    public Texture2D objectPNG;

    public const float instantiateOffset = 10f; 
    public static inventoryScript inventory;
    public static Transform plane;

    private Vector3 originalposition;
    private List<Button> buttons = new List<Button>();

    void Start() {
        originalposition = transform.position;
        plane = GameObject.FindGameObjectWithTag("plane").transform;
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<inventoryScript>();
        choiceButton.gameObject.SetActive(false);
    }
    void Update() {
        if (transform.position.y < plane.position.y) {
            transform.position = originalposition;
        }
    }
    private void makeChoice() {
        choiceButton.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        foreach(Button button in buttons) {
            button.gameObject.SetActive(false);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = true;
        camerascript.enabled = true;
    }
    private void pickUp() {
        inventory.Add(gameObject.GetComponent<interactable>());
        makeChoice();
    }
    void OnMouseDown() {
        if (choices.Length == 0)
            pickUp();
        else {
            camerascript.enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            if (buttons.Count < 1) {
                int index = 1;
                int factor = 1;
                float height = choiceButton.gameObject.GetComponent<RectTransform>().rect.height;
                choiceButton.gameObject.SetActive(true);
                choiceButton.onClick.AddListener(makeChoice);
                choiceButton.GetComponentInChildren<Text>().text = choices[0];
                buttons.Add(choiceButton);
                for (int i = 1; i < choices.Length; i++) {
                    Button newButton = Instantiate(choiceButton);
                    newButton.gameObject.transform.SetParent(choiceButton.transform.parent);
                    newButton.gameObject.GetComponent<RectTransform>().position = new Vector3(choiceButton.gameObject.transform.position.x, choiceButton.gameObject.transform.position.y + (height * index * factor), choiceButton.gameObject.transform.position.z);
                    if (factor < 0)
                        index++;
                    factor *= -1;
                    newButton.GetComponentInChildren<Text>().text = choices[i];
                    if (choices[i] == "pick up")
                        newButton.onClick.AddListener(pickUp);
                    else
                        newButton.onClick.AddListener(makeChoice);
                    buttons.Add(newButton);
                }
            }
            else {
                foreach (Button button in buttons) {
                    button.gameObject.SetActive(true);
                }
            }
        }
    }
}
