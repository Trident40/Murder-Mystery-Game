using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AI_Walking : MonoBehaviour {
    private NavMeshAgent agent;
    private Transform destination;
    public Transform[] locations;
    public float speed;
    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update() {
        if (destination == null || Vector3.Distance(transform.position, destination.position) < 0.5) {
            System.Random random = new System.Random();
            destination = locations[random.Next(locations.Length)];
            agent.SetDestination(destination.position);
        }
    }
}
