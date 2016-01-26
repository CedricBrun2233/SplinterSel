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
        mGuards = GameObject.FindObjectsOfType<Guard>() as Guard[];
        noiseInGame = new List<Noise>();
    }
	
	void Update ()
    {
        Guard guard;
        for(int i = 0; i < mGuards.Length; i++)
        {
            guard = mGuards[i];
            if (guard.mState == State.Patrol)
            {
                guard.detection(player);
                continue;
            }
            if (guard.mState == State.ReturnPatrol)
            {
                guard.returnPatrol(player);
                continue;
            }
            if (guard.mState == State.SeePlayer)
            {
                guard.seePlayer(player);
                continue;
            }
            foreach (Noise noise in noiseInGame)
            {
                if (guard.mState == State.NoiseHeard)
                {
                    guard.hearNoise(noise);
                    continue;
                }
            }
            if (guard.mState == State.Alerted)
            {
                //guard.alert();
                continue;
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
