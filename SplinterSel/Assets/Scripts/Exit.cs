using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour
{
    GameManager GM;

    void Start()
    {
        GM = GameManager.GetInstance();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            if ((col.gameObject.GetComponent<PlayerGrapProp>().hasWin()))
            {
                GM.win();
            }
        }
    }
}
