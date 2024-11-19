using UnityEngine;

public class ItemContro : MonoBehaviour
{

    private  bool Reset;

    public Flag Flag;

    public GameObject[] coin;

    private void Update()
    {
        Reset = Flag.ReSet;

        if (Reset)
        {
            for (int i = 0; i < coin.Length; i++)
            {
                coin[i].SetActive(true);
            }
        }
    }
}
