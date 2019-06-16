using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class suspectScript : MonoBehaviour
{
    public Text nameLabel;
    private Text label;
    public string suspectName;
    void Start() {
        nameLabel.gameObject.SetActive(false);
        label = Instantiate(nameLabel);
        label.gameObject.SetActive(true);
        label.text = (suspectName != null) ? suspectName: "suspect";
        label.gameObject.transform.SetParent(nameLabel.transform);
    }
    void Update () { 
        Vector3 namePose = Camera.main.WorldToScreenPoint(transform.position); 
        label.transform.position = namePose;
    }
}
