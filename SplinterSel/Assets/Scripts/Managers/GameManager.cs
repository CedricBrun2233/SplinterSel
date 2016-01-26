using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    MenuManager instanceMM;

    void Awake ()
    {
        DontDestroyOnLoad(this);
        instanceMM = MenuManager.GetInstance();
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
        Application.LoadLevel(1);
        instanceMM.victory();
    }

    public void lose()
    {
        Application.LoadLevel(1);
        instanceMM.defeat();
    }
}
