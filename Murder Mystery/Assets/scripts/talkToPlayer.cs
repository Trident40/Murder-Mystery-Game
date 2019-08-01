using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class talkToPlayer : MonoBehaviour
{
    public Transform location;
    public string susName;
    public string[] lines;
    public Text textBox;
    public float speed;

    private bool moving;
    private Animator animator;
    private Quaternion rotation;
    private Transform origPosition;
    private bool answerQuestions;
    private int current;
    // Start is called before the first frame update
    void Start()
    {
        textBox.gameObject.SetActive(false);
        current = 0;
        rotation = transform.rotation;   
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = rotation;
        if (origPosition != null) {
            transform.position = origPosition.position;
        }
        if (answerQuestions) {
            if (Input.GetKeyDown("d")) {
                if (current < lines.Length) {
                      
                    textBox.gameObject.SetActive(true);
                    textBox.text = lines[current++];
                }
                else {
                    gameObject.SetActive(false);
                    textBox.gameObject.SetActive(false);
                }
            }
            if (Input.GetKeyDown("a")) {
                if (current != 0) {
                    textBox.text = lines[--current];
                }
            }
        }
        if (moving) {
            if (Vector3.Distance(transform.position, location.position) < 0.004) {
                answerQuestions = true;
                GameObject empty = new GameObject();
                origPosition = empty.transform;
                origPosition.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Debug.Log("moving");
                moving = false;
                animator.SetBool("walking", false);
                animator.SetBool("sitting", true);
            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, location.position, speed);
                animator.SetBool("walking", true);
            }
        }
           
    }
    public void Question() {
        moving = true;
    }
}
