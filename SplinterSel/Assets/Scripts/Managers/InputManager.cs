using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    void Awake ()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = new InputManager();
        }
    }
	
	void Update ()
    {
	    if(Input.GetKey(KeyCode.Joystick1Button0)) // Button A
        {
            //Interaction avec mur
        }
        if (Input.GetKey(KeyCode.Joystick1Button1)) // Button B
        {
            //Camouflage
        }
        if (Input.GetKey(KeyCode.Joystick1Button2)) // Button X
        {
            //Interaction avec objets
        }
        if (Input.GetKey(KeyCode.Joystick1Button3)) // Button Y
        {
            //Lancer objet
        }
        if (Input.GetKey(KeyCode.Joystick1Button4)) // Button LeftBumper
        {
            //Nothing
        }
        if (Input.GetKey(KeyCode.Joystick1Button5)) // Button RightBumper
        {
            //Nothing
        }
        if (Input.GetKey(KeyCode.Joystick1Button6)) // Button Back
        {
            //Nothing
        }
        if (Input.GetKey(KeyCode.Joystick1Button7)) // Button Start
        {
            //Go to Pause
        }
    }
}
