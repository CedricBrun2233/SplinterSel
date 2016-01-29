using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public AudioSource musicSource;

    private static MusicManager instance;
    private bool hOI = false;
    private bool l = false;
    private bool o = false;
    private bool v = false;

    //Music normal
    public AudioClip GameState;
    public AudioClip AlertState;
    public AudioClip ResearchState;
    public AudioClip DeathState;
    public AudioClip WinState;
    public AudioClip MenuState;

    //Music 8-bit
    public AudioClip EytBitAlert;
    public AudioClip EytBitResearch;
    public AudioClip EytBitMenu;
    public AudioClip EytBitGameLoop;
    public AudioClip EytBitDeath;
    public AudioClip EytBitWin;
    public AudioClip EytBitDumb;
    public AudioClip EytBitEpic;
    public AudioClip EytBitSpooky;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () {
	}

    public static MusicManager GetInstance()
    {
        if (instance == null)
        {
            instance = new MusicManager();
        }
        return instance;
    }

    public void launchMenuMusic()
    {
        if (hOI)
        {
            if(musicSource.clip != EytBitMenu)
            {
                musicSource.clip = EytBitMenu;
                musicSource.Play();
            }
        }
        else
        {
            if(musicSource.clip != MenuState)
            {
                musicSource.clip = MenuState;
                musicSource.Play();
            }
        }
            
        musicSource.loop = true;
    }

    public void launchGameLoopMusic()
    {
        if (hOI)
            musicSource.clip = EytBitGameLoop;
        else
            musicSource.clip = GameState;

        musicSource.Play();
        musicSource.loop = true;
    }

    public void launchResearchMusic()
    {
        if (hOI)
            musicSource.clip = EytBitResearch;
        else
            musicSource.clip = ResearchState;

        musicSource.Play();
        musicSource.loop = true;
    }

    public void launchAlertMusic()
    {
        if (hOI)
        {
            if (musicSource.clip != EytBitAlert)
            {
                musicSource.clip = EytBitAlert;
                musicSource.Play();
            }
        }
        else
        {
            if (musicSource.clip != AlertState)
            {
                musicSource.clip = AlertState;
                musicSource.Play();
            }
        }

        musicSource.loop = true;
    }

    public void launchDeathMusic()
    {
        if (hOI)
            musicSource.clip = EytBitDeath;
        else
            musicSource.clip = DeathState;

        musicSource.Play();
        musicSource.loop = false;
    }

    public void launchWinMusic()
    {
        if (hOI)
            musicSource.clip = EytBitWin;
        else
            musicSource.clip = WinState;

        musicSource.Play();
        musicSource.loop = false;
    }

    public void launchEpicMusic()
    {
        musicSource.clip = EytBitEpic;
        musicSource.Play();
        musicSource.loop = true;
    }

    public void launchSpookyMusic()
    {
        musicSource.clip = EytBitSpooky;
        musicSource.Play();
        musicSource.loop = true;
    }

    public void launchDumbMusic()
    {
        musicSource.clip = EytBitSpooky;
        musicSource.Play();
        musicSource.loop = true;
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.L))
        {
            l = !l;
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            o = !o;
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            v = !v;
        }

        if(l && o && v && !hOI)
        {
            hOI = true;

            if (musicSource.clip == MenuState)
                launchMenuMusic();

            if (musicSource.clip == GameState)
                launchGameLoopMusic();

            if (musicSource.clip == AlertState)
                launchAlertMusic();

            if (musicSource.clip == ResearchState)
                launchResearchMusic();

            if (musicSource.clip == DeathState && musicSource.isPlaying)
                launchDeathMusic();

            if (musicSource.clip == WinState && musicSource.isPlaying)
                launchWinMusic();
        }

        if(!l && !o && !v && hOI)
        {
            hOI = false;

            if (musicSource.clip == EytBitMenu || musicSource.clip == EytBitSpooky || musicSource.clip == EytBitEpic || musicSource.clip == EytBitDumb)
                launchMenuMusic();

            if (musicSource.clip == EytBitGameLoop)
                launchGameLoopMusic();

            if (musicSource.clip == EytBitAlert)
                launchAlertMusic();

            if (musicSource.clip == EytBitResearch)
                launchResearchMusic();

            if (musicSource.clip == EytBitDeath && musicSource.isPlaying)
                launchDeathMusic();

            if (musicSource.clip == EytBitWin && musicSource.isPlaying)
                launchWinMusic();
        }
        
        if(hOI)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                launchDumbMusic();
            }

            if (Input.GetKeyDown(KeyCode.Delete))
            {
                launchEpicMusic();
            }

            if (Input.GetKeyDown(KeyCode.CapsLock))
            {
                launchSpookyMusic();
            }
        }
	}
}
