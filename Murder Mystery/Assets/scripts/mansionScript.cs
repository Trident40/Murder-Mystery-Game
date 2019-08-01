using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mansionScript : MonoBehaviour
{
    public GameObject player;
    void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.Equals(player.gameObject)) {
            SceneController.goToNextScene();
            Debug.Log("yo");
        }
    }
}
