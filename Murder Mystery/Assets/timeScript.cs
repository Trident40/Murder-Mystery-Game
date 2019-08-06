using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timeScript : MonoBehaviour
{
    private Text timeText;
    void Start()
    {
        timeText = GetComponent<Text>();   
    }

    void Update()
    {
        timeText.text = "Time: " + (((int)Time.time) / 3600).ToString("D2") + ":" + ((int) Time.time % 3600 / 60).ToString("D2") + ":" + ((int) Time.time % 60).ToString("D2");
    }
}
