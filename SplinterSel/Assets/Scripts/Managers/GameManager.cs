using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    GuardManager instanceGuardsM;
    MenuManager instanceMM;
    MusicManager instanceMusic;
    private static bool lostState;
    private static bool winState;

    void Awake ()
    {
        DontDestroyOnLoad(this);
        instanceMusic = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>();
    }

    void OnLevelWasLoaded(int lv)
    {
        if(lv == 1)
        {
            instanceMM = MenuManager.GetInstance();

            if (lostState)
            {
                instanceMM.defeat();
                lostState = false;
            }

            if(winState)
            {
                instanceMM.victory();
                winState = false;
            }

            
        }

        if(lv == 2)
        {
            instanceGuardsM = GuardManager.GetInstance();
            instanceGuardsM.initialize();
            instanceMusic.launchGameLoopMusic();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            win();
        }
    }

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }
        return instance;
    }

    public void startGame()
    {
        Application.LoadLevel(2);
    }

    public void win()
    {
        winState = true;
        Application.LoadLevel(1);
    }

    public void lose()
    {
        lostState = true;
        Application.LoadLevel(1);
    }
}
