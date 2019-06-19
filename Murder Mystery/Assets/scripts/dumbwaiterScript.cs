using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dumbwaiterScript : MonoBehaviour
{
    public GameObject dumbwaiter;
    public GameObject pillar;
    public float speed;
    private bool goingUp;
    private bool goingDown;
    private Transform plane;
    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.FindGameObjectWithTag("plane").transform;
    }
    void OnMouseDown() {
        if (goingUp) {
            goingUp = false;
            goingDown = true;
        }
        else {
            goingUp = true;
            goingDown = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (goingUp && dumbwaiter.transform.position.y <= pillar.transform.position.y-dumbwaiter.transform.localScale.y/2)
            dumbwaiter.transform.Translate(Vector3.up * speed);
        else if (goingDown && dumbwaiter.transform.position.y >= plane.position.y + dumbwaiter.transform.localScale.y / 2)
            dumbwaiter.transform.Translate(Vector3.down * speed);
    }
}
