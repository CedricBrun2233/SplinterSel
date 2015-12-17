using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuardManager : MonoBehaviour
{
    public static GuardManager instance;
    List<Guard> mGuards;
    State mState;

enum State
{
    Patrol,
    Alerted,
    ReturnPatrol,
    SeePlayer,
};


	void Awake ()
    {
        DontDestroyOnLoad(this);
        mGuards = new List<Guard>();
        mState = State.Patrol;

        if (instance == null)
        {
            instance = new GuardManager();
        }
    }
	
	void Update ()
    {
	
	}
}
