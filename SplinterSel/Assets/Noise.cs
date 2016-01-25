using UnityEngine;
using System.Collections;

public class Noise : MonoBehaviour
{
    GuardManager guardManager;

	void Start ()
    {
        guardManager = GuardManager.GetInstance();
        guardManager.addNoise(this);
	}
}
