using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    private static MenuManager instance;
    GameManager instanceGM;

    GameObject credits;
    GameObject mainMenu;
    GameObject controls;
    GameObject win;
    GameObject lose;

    void Awake()
    {
        Debug.Log("Yolo");
        instanceGM = GameManager.GetInstance();

        mainMenu = GameObject.Find("MainMenu");
        controls = GameObject.Find("ControlsMenu");
        win = GameObject.Find("WinPanel");
        lose = GameObject.Find("LosePanel");
        credits = GameObject.Find("Credits");
        Debug.Log(mainMenu);
        Debug.Log(controls);
        Debug.Log(win);
        Debug.Log(lose);
        Debug.Log(credits);
        hideAll();
        mainMenu.SetActive(true);
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
