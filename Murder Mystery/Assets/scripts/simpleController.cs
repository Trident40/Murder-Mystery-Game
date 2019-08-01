using UnityEngine;
using UnityEngine.UI;

public class simpleController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public Camera[] cams;
    public float range;
    private int curr;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        curr = 0;
        for (int i = 0; i < cams.Length; i++)
            cams[i].gameObject.SetActive(false);
        cams[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("c")) {
            cams[curr].gameObject.SetActive(false);
            if (++curr >= cams.Length)
                curr = 0;
            cams[curr].gameObject.SetActive(true);
        }
        float rawXForce = Input.GetAxis("Horizontal");
        float rawYForce = Input.GetAxis("Vertical");
        animator.SetFloat("speed", Mathf.Abs(rawYForce));
        float xForce = rawXForce * (!Input.GetKey("tab") ? speed : speed * 1.5f);
        float yForce = rawYForce * (!Input.GetKey("tab") ? speed : speed * 1.5f);
        transform.Translate(new Vector3(xForce, 0, yForce));
        transform.rotation = Quaternion.Euler(0, cams[curr].GetComponent<cameraScript>().currentY, 0);
    }
}
