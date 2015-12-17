using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour
{
    public string mID;

    public float mNoisePower; //rayon de la sphere de son
    public float mReach;      //distance max de lancé

    public abstract void makeNoise(Vector3 position);
}
