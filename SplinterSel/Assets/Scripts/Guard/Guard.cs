using UnityEngine;
using System.Collections;
using System;

public class Guard : MonoBehaviour
{
    public int reachView;
    public State mState;
    public float patrolDuration = 8f;

    public GameObject patrolPoint1;
    public GameObject patrolPoint2;
    GameObject destIfDetection;
    bool currentDest1;

    NavMeshAgent agent;
    

	void Start ()
    {
        mState = State.Patrol;
        currentDest1 = true;
        destIfDetection = Resources.Load("Prefabs/destIfDetection") as GameObject;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(patrolPoint1.transform.position);

        InvokeRepeating("Patrol", 0f, patrolDuration);
    }

    public bool objIsInViewReach(GameObject obj)
    {
        Vector3 distance = obj.transform.position - transform.position;
        if (distance.magnitude < reachView)
        {
            float angle = Mathf.Atan2(obj.transform.position.z, obj.transform.position.x);
            if (angle < Mathf.PI/12 && angle > -Mathf.PI / 12)
            {
                return true;
            }
        }
        return false;
    }

    public void hearNoise(Noise noise)
    {

    }

    public void returnPatrol(GameObject player)
    {
        if (objIsInViewReach(player))
        {
            if (objIsVisible(player))
            {
                destIfDetection.transform.position = player.transform.position;
                agent.SetDestination(destIfDetection.transform.position);
                mState = State.SeePlayer;
            }
        }
        if (agent.velocity.magnitude < 0.1f)
        {
            currentDest1 = true;
            InvokeRepeating("Patrol", 0f, patrolDuration);
        }
    }

    public void seePlayer(GameObject player)
    {
        if (objIsInViewReach(player))
        {
            if (objIsVisible(player))
            {
                destIfDetection.transform.position = player.transform.position;
                agent.SetDestination(destIfDetection.transform.position);
            }
        }
        if (agent.velocity.magnitude < 0.1f)
        {
            agent.SetDestination(patrolPoint1.transform.position);
            mState = State.ReturnPatrol;
        }
    }

    public void detection(GameObject player)
    {
        if(objIsInViewReach(player))
        {
            if (objIsVisible(player))
            {
                CancelInvoke("Patrol");
                destIfDetection.transform.position = player.transform.position;

                agent.SetDestination(destIfDetection.transform.position);
                mState = State.SeePlayer;
            }
        }
    }

    public bool objIsVisible(GameObject obj)
    {
        Vector3 direction = obj.transform.position - transform.position;
        RaycastHit hit;

        Physics.Raycast(transform.position, direction, out hit, reachView);

        if (hit.collider.gameObject.tag != obj.tag)
            return false;
        return true;
    }

    void Patrol()
    {
        if (currentDest1)
        {
            agent.SetDestination(patrolPoint2.transform.position);
        }
        else
        {
            agent.SetDestination(patrolPoint1.transform.position);
        }
        currentDest1 = !currentDest1;
    }

    void alert()
    {

    }
}