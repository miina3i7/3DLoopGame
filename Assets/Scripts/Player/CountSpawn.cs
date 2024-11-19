using UnityEngine;
public class CountSpawn : MonoBehaviour
{
    Vector3 StartPos;

    float SpawnTime;
    public float MaxSpawnTime;
    int count = 1;

    private void Start()
    {
        StartPos = transform.position;
    }

    private void Update()
    {

        if (SpawnTime >= MaxSpawnTime * count)
        {
            this.transform.position = StartPos;
            count +=1;
        }
        else
        {
            SpawnTime = Time.time;
        }
    }
}
