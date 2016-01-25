using UnityEngine;
using System.Collections;

public class TryNavMesh : MonoBehaviour
{
    public GameObject WayPoint1;

    public GameObject WayPoint2;

    NavMeshAgent agent;
    bool currentDest1 = true;

    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(WayPoint1.transform.position);

        InvokeRepeating("ChangePath", 0f, 3f);
    }

    // Update is called once per frame
    void ChangePath()
    {
        if (currentDest1)
        {
            agent.SetDestination(WayPoint2.transform.position);
        }
        else
        {
            agent.SetDestination(WayPoint1.transform.position);
        }
        currentDest1 = !currentDest1;
    }
}
