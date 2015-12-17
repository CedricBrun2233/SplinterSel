using UnityEngine;
using System.Collections;

public class Can : Item
{
    public GameObject prefab;

    public float noisePower; //rayon de la sphere de son
    float reach;               //distance max de lancé

    void Start()
    {
        noisePower = mNoisePower;
        reach = mReach;
        mID = "Can";
    }

    void Update()
    {

    }

    public override void makeNoise(Vector3 position)
    {
        GameObject zoneNoise = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
    }
}
