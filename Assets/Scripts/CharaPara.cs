using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CharaPara")]
public class CharaPara : ScriptableObject
{
    [SerializeField]public int Hp;
    [SerializeField]public int Ap;
}
