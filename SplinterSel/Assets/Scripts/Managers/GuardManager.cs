using UnityEngine;
using System.Collections.Generic;

public class GuardManager : MonoBehaviour
{
    public static GuardManager instance;
    Guard[] mGuards;
    List<Noise> noiseInGame;
    GameObject player;
    public int noiseReach;

    void Awake ()
    {
        DontDestroyOnLoad(this);

        player = GameObject.FindGameObjectWithTag("Player");
        mGuards = GameObject.FindObjectsOfType<Guard>();
        noiseInGame = new List<Noise>();
    }
	
	void Update ()
    {
	    foreach (Guard guard in mGuards)
        {
            Debug.Log(guard.mState);
            if (guard.mState == State.Patrol)
            {
                guard.detection(player);
                return;
            }
            if (guard.mState == State.ReturnPatrol)
            {
                guard.returnPatrol(player);
                return;
            }
            if (guard.mState == State.SeePlayer)
            {
                guard.seePlayer(player);
                return;
            }
            foreach (Noise noise in noiseInGame)
            {
                if (guard.mState == State.NoiseHeard)
                {
                    guard.hearNoise(noise);
                    return;
                }
            }
            if (guard.mState == State.Alerted)
            {
                //guard.alert();
                return;
            }
        }
	}

    public static GuardManager GetInstance()
    {
        if(instance == null)
        {
            instance = new GuardManager();
        }
        return instance;
    }

    public void addNoise(Noise noise)
    {
        noiseInGame.Add(noise);
    }
}
