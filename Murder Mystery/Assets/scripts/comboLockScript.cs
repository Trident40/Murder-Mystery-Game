using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class comboLockScript : lockScript
{
    public cameraScript camerascript;
    private bool unlocking;
    public InputField input;
    public int instantiateOffset;
    public Button enter;
    public int[] combo;
    public RawImage bounds;
    private int size;
    private SortedList<int, InputField> fields = new SortedList<int, InputField>();
    // Update is called once per frame
    void Start() {
        size = combo.Length;
        bounds.enabled = false;
    }
    private void enterCombo() {
        unlocking = false;
        bool correct = true;
        foreach (InputField inp in fields.Values)
            inp.gameObject.SetActive(false);
        for (int i = 0; i < fields.Count; i++) {
            if (Int32.Parse(fields.Values[i].text) != combo[i])
                correct = false;
        }
        if (correct)
            unlocked = true;
        enter.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = true;
        bounds.enabled = false;
        camerascript.enabled = true;
    }
    public void unlock() {
        unlocking = true;
    }
    void OnMouseDown() {
        //Object.Destroy(gameObject);
        if (!unlocking) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = false;
            bounds.enabled = true;
            unlocking = true;
            Cursor.lockState = CursorLockMode.None;
            enter.onClick.AddListener(enterCombo);
            enter.gameObject.SetActive(true);
            input.gameObject.SetActive(true);
            if (fields.Count < 1) {
                fields.Add((int)input.gameObject.transform.position.x, input);
                int index = 1;
                int factor = 1;
                float width = input.gameObject.GetComponent<RectTransform>().rect.width;
                for (int i = 0; i < size - 1; i++) {
                    InputField newField = Instantiate(input);
                    newField.gameObject.transform.parent = input.transform.parent;
                    newField.gameObject.GetComponent<RectTransform>().position = new Vector3(input.gameObject.transform.position.x + (width * index * factor + instantiateOffset * factor), input.gameObject.transform.position.y, input.gameObject.transform.position.z);
                    if (factor < 0)
                        index++;
                    factor *= -1;
                    fields.Add((int)newField.gameObject.transform.position.x, newField);
                }
            }
            else {
                foreach (InputField field in fields.Values) {
                    field.gameObject.SetActive(true);
                }
            }
            camerascript.enabled = false;
        }
    }
}
