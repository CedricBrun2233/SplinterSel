using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    private static MenuManager instance;
    GameManager instanceGM;

    public static GameObject mainMenu;
    public static GameObject credits;
    public static GameObject controls;
    public static GameObject win;
    public static GameObject lose;

    void Awake()
    {
        instanceGM = GameManager.GetInstance();

        mainMenu = GameObject.Find("MainMenu");
        controls = GameObject.Find("ControlsMenu");
        win = GameObject.Find("WinPanel");
        lose = GameObject.Find("LosePanel");
        credits = GameObject.Find("Credits");
        hideAll();
        mainMenu.SetActive(true);
    }

    void OnLevelWasLoaded(int lv)
    {
        
    }

    public void hideAll()
    {
        credits.SetActive(false);
        mainMenu.SetActive(false);
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

    public void onClickCredits()
    {
        hideAll();
        credits.SetActive(true);
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
