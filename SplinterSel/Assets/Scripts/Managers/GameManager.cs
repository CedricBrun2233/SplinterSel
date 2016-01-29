using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    GuardManager instanceGuardsM;
    MenuManager instanceMM;
    private static bool lostState;
    private static bool winState;

    void Awake ()
    {
        DontDestroyOnLoad(this);
    }

    void OnLevelWasLoaded(int lv)
    {
        if(lv == 1)
        {

            Debug.Log("OnLevel...");
            Debug.Log("menu charge: "+lostState);

            instanceMM = MenuManager.GetInstance();

            if(lostState)
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
        Debug.Log("GM.lost");
        lostState = true;
        Debug.Log("lose : "+lostState);
        Application.LoadLevel(1);
    }
    void OnLevelLoad()
    {

    }
}
