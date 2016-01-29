using UnityEngine;
using System.Collections.Generic;

public class GuardManager : MonoBehaviour
{
    public static GuardManager instance;
    GameManager GM;
    GameObject[] mGuards;
    List<Noise> noiseInGame;
    GameObject player;
    public int noiseReach;

    void Awake ()
    {
        DontDestroyOnLoad(this);

        GM = GameManager.GetInstance();
        mGuards = new GameObject[0];
    }

    public void initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mGuards = GameObject.FindGameObjectsWithTag("Guard");
    }
	
	void Update ()
    {
        if(Application.loadedLevel == 2)
        {
            initialize();
        }
        noiseInGame = new List<Noise>();
        Guard guard;

        for (int i = 0; i < mGuards.Length; i++)
        {
            if (Application.loadedLevel != 2) return;
            guard = mGuards[i].GetComponent<Guard>();
            
            if ((guard.transform.position - player.transform.position).magnitude < 1.1)
            {
                GM.lose();
            }

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
