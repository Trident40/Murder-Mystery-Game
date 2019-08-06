using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phoneScript : MonoBehaviour
{
    [Header("Phone Parts")]
    public GameObject displayMsg;
    public GameObject displayOff;
    public RawImage messageTemplate;
    public RawImage homeScreen;
    public RawImage cameraScreen;
    public RawImage spotifyScreen;
    public RawImage screen;
    public Text nameField;
    public Button button;
    public Text time;
    public Text Battery;
    [Header("Things to Disable")]
    public Image cross;
    public cameraScript camera;

    //18.77 23
    void Update() {
        time.text = System.DateTime.Now.ToShortTimeString();
        Battery.text = ((int) ( SystemInfo.batteryLevel * 100)).ToString() + "%";
    }
    public class Sender {
        public string name;
        public List<RawImage> messageTemps;
        public List<string> messages;
        private RawImage msgTemp;

        public Sender(string name) {
            msgTemp = GameObject.FindGameObjectWithTag("message").GetComponent<RawImage>();
            this.name = name;
            messageTemps = new List<RawImage>();
            messages = new List<string>();
        }

        public void AddMessage(string msg) {
            messages.Add(msg);
            RawImage newMsg = Instantiate(msgTemp);
            if (messageTemps.Count > 0) {
                newMsg.transform.position = messageTemps[messageTemps.Count - 1].transform.position;
                newMsg.transform.parent = messageTemps[messageTemps.Count - 1].transform.parent;
                Vector3 msgTempPos = messageTemps[messageTemps.Count - 1].GetComponent<RectTransform>().position;
                float msgTempHeight = messageTemps[messageTemps.Count - 1].GetComponent<RectTransform>().rect.height;
                newMsg.GetComponent<RectTransform>().position =  new Vector3(msgTempPos.x, msgTempPos.y - msgTempHeight - 10, msgTempPos.z);
            }
            else {
                newMsg.transform.parent = msgTemp.transform.parent;
                newMsg.transform.position = msgTemp.transform.position;
                msgTemp.gameObject.SetActive(false);
            }
            Debug.Log(msg.Length);
            newMsg.GetComponent<RectTransform>().sizeDelta = new Vector2(msgTemp.GetComponent<RectTransform>().rect.width, 20 * (msg.Length / 23 + 1));
            newMsg.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = newMsg.GetComponent<RectTransform>().sizeDelta;
            newMsg.transform.GetChild(0).GetComponent<Text>().text = msg;
            newMsg.gameObject.SetActive(true);
            messageTemps.Add(newMsg);
        }
    }

    private List<Sender> senders;
    void Start() {
        senders = new List<Sender>();
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void SendMessage(string senderName, string msg) {
        screen.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        cross.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        displayMsg.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = false;
        camera.enabled = false;
        bool foundName = false;
        for (int i = 0; i < senders.Count; i++) {
            if (senderName == senders[i].name) {
                senders[i].AddMessage(msg);
                foundName = true;
                break;
            }
        }
        if (!foundName) {
            Sender newSender = new Sender(senderName);
            newSender.AddMessage(msg);
            senders.Add(newSender);
        }
        nameField.text = senderName;
    }
    public void TurnOffPhone() {
        Debug.Log("OFF");
        cross.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = true;
        camera.enabled = true;
    }
    public void GoToHomeScreen() {
        displayMsg.SetActive(false);
        cameraScreen.gameObject.SetActive(false);
        homeScreen.gameObject.SetActive(true);
        cross.gameObject.SetActive(false);
        spotifyScreen.gameObject.SetActive(false);
    }
    public void GoToMessages() {
        displayMsg.SetActive(true);
        homeScreen.gameObject.SetActive(false);
        cameraScreen.gameObject.SetActive(false);
        spotifyScreen.gameObject.SetActive(false);
    }
    public void GoToCamera() {
        cameraScreen.gameObject.SetActive(true);
    }
    public void GoToSpotify() {
        spotifyScreen.gameObject.SetActive(true);
    }
    public void SwitchSender(string name) {
        for (int i = 0; i < senders.Count; i++) {
            if (senders[i].name == name) {
                nameField.text = senders[i].name;
                for (int j = 0; j < transform.childCount; j++) {
                    transform.GetChild(j).gameObject.SetActive(false);
                }
                displayMsg.SetActive(true);
                messageTemplate.gameObject.SetActive(false);
                foreach (RawImage ri in senders[i].messageTemps) {
                    ri.gameObject.SetActive(true);
                }
            }
        }
    }
}
