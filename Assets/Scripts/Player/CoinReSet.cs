using UnityEngine;

public class CoinReSet : MonoBehaviour
{
    bool SpawnOn;
    private Vector3 Pos;

    public Flag Flag;

    private void Start()
    {
        SpawnOn = false;
        Pos = transform.position;
    }
    private void Update()
    {
        Flag.ReSet = SpawnOn;
        if (SpawnOn)
        {
            spawn();
        }
    }

    private void spawn()
    {
        transform.position = Pos;
        SpawnOn = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Spawn"))
        {
            SpawnOn = true;
            Flag.ReSet = SpawnOn;
        }
    }
}
