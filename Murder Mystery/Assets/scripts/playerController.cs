using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public Camera[] cams;
    public float range;
    public KeyCode interact;
    public inventoryScript inventory;
    public Image cross;
    public Color interactColor;
    public phoneScript phone;

    private Color orig;
    private int curr;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        orig = cross.color;
        animator = GetComponent<Animator>();
        curr = 0;
        for (int i = 0; i < cams.Length; i++)
            cams[i].gameObject.SetActive(false);
        cams[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("t")) {
            System.Random random = new System.Random();
            phone.SendMessage("Surya", "hello " + random.Next(0, 5000) * random.Next(0, 5000) + "this is the End of the message...");
        }
        if (Input.GetKeyDown("c")) {
            cams[curr].gameObject.SetActive(false);
            if (++curr >= cams.Length)
                curr = 0;
            cams[curr].gameObject.SetActive(true);
        }
        float rawXForce = Input.GetAxis("Horizontal");
        float rawYForce = Input.GetAxis("Vertical");
        animator.SetFloat("speed", Mathf.Abs(rawYForce));
        if (inventoryScript.currentObject != null)
            animator.SetBool("hasGun", inventoryScript.currentObject.gameObject.GetComponent<InteractableWithID>() != null);
        float xForce = rawXForce * (!Input.GetKey("tab") ? speed : speed * 1.5f);
        float yForce = rawYForce * (!Input.GetKey("tab") ? speed : speed * 1.5f);
        transform.Translate(new Vector3(xForce, 0, yForce));
        transform.rotation = Quaternion.Euler(0, cams[curr].GetComponent<cameraScript>().currentY, 0);
        if (Input.GetKey(interact)) {
            cross.color = interactColor;
        }
        if (Input.GetKeyUp(interact)) {
            cross.color = orig;
        }
        if (Input.GetKeyDown(interact)) {
            RaycastHit hit;
            if (Physics.Raycast(cams[curr].transform.position, cams[curr].transform.forward, out hit, range)) {
                if (hit.transform.gameObject.CompareTag("suspect")) {
                    Animator suspanim = hit.transform.gameObject.GetComponent<Animator>();
                    suspanim.SetBool("isStanding", !suspanim.GetBool("isStanding"));
                }/*
                if (hit.transform.gameObject.GetComponent<interactable>() != null) {
                    inventory.Add(hit.transform.gameObject.GetComponent<interactable>());
                }
                if (hit.transform.gameObject.GetComponent<deskScript>() != null) {
                    hit.transform.gameObject.GetComponent<deskScript>().maneuverDesk();
                } */
            }
        }
    }
}
