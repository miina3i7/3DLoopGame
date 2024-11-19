using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item")]
public class Item:ScriptableObject
{
    public List<GameObject> Coin;
    public GameObject[] Coins;
    public GameObject ACoin;
    public Vector3 Pos;
}
