using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dumbwaiterScript : MonoBehaviour
{
    public GameObject dumbwaiter;
    public GameObject pillar;
    public float speed;
    private bool goingUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnMouseDown() {
        goingUp = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (goingUp && dumbwaiter.transform.position.y <= pillar.transform.position.y-dumbwaiter.transform.localScale.y/2)
            dumbwaiter.transform.Translate(Vector3.up * speed);
    }
}
