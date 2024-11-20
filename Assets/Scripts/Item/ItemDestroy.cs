using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("5");
        if(collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }   
    }
}
