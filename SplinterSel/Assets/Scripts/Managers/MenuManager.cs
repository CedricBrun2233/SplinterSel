using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    private static MenuManager instance;

    public GameObject credits;
    public GameObject mainMenu;
    public GameObject inGame;
    public GameObject controls;
    public GameObject win;
    public GameObject lose;

    void Awake()
    {
        DontDestroyOnLoad(this);
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

    public MenuManager GetInstance()
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
}
