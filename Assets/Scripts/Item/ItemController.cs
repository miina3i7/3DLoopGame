using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class ItemController : MonoBehaviour
{


    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }   
        
    }
}
