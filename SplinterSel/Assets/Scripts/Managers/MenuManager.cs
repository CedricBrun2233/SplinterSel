using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    private static MenuManager instance;
    GameManager instanceGM;

    public GameObject credits;
    public GameObject mainMenu;
    public GameObject inGame;
    public GameObject controls;
    public GameObject win;
    public GameObject lose;

    void Awake()
    {
        DontDestroyOnLoad(this);
        instanceGM = GameManager.GetInstance();
    }

    public void hideAll()
    {
        credits.SetActive(false);
        mainMenu.SetActive(false);
        inGame.SetActive(false);
        controls.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
    }

    public static MenuManager GetInstance()
    {
        if(instance == null)
        {
            instance = new MenuManager();
        }
        return instance;
    }

    public void onClickBackToMenu()
    {
        hideAll();
        mainMenu.SetActive(true);
    }

    public void onClickPlay()
    {
        instanceGM.startGame();
    }

    public void onClickControl()
    {
        hideAll();
        controls.SetActive(true);
    }

    public void onClickExit()
    {
        Application.Quit();
    }

    public void victory()
    {
        hideAll();
        win.SetActive(true);
    }

    public void defeat()
    {
        hideAll();
        lose.SetActive(true);
    }
}
