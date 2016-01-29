using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    GuardManager instanceGuardsM;
    MenuManager instanceMM;

    void Awake ()
    {
        DontDestroyOnLoad(this);
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
        instanceGuardsM.initialize();
    }

    public void win()
    {
        Application.LoadLevel(1);
        instanceMM = MenuManager.GetInstance();
        instanceMM.victory();
    }

    public void lose()
    {
        Application.LoadLevel(1);
        instanceMM = MenuManager.GetInstance();
        instanceMM.defeat();
    }
}
