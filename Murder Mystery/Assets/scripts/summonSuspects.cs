using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class summonSuspects : MonoBehaviour
{
    public talkToPlayer[] suspects;
    private int ind;
    // Start is called before the first frame update
    void Start()
    {
        ind = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log(ind);
            if (ind < suspects.Length) {
                if (ind == 0 || !suspects[ind-1].gameObject.activeSelf)
                    suspects[ind++].Question();
            }
        }
        if (!suspects[suspects.Length-1].gameObject.activeSelf) {
            SceneManager.LoadScene(1);
        }
    }
}
