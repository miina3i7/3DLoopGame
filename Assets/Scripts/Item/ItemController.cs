using UnityEngine;

public class ItemController : MonoBehaviour
{
    void Update()
    {
        // 必要な処理があればここに記述
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("5");
            gameObject.SetActive(false);
        }   
    }
}

