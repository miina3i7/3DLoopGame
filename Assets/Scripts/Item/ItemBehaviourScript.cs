using UnityEngine;

public class ItemBehaviourScript : MonoBehaviour
{
    public Item Item;
    bool Reset;
    GameObject Coin;
    private void Start()
    {
       if(Item != null)
        {
            foreach(GameObject obj in Item.Coin)
            {
                if(obj != null)
                {
                    Debug.Log("a");
                }
            }
        }
        else
        {
            Debug.Log("");
        }
        Coin = Item.ACoin;
    }

    private void Update()
    {
        if(Reset)
        {
            Coin.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Spawn"))
        {
            Reset = true;
        }
    }
}
