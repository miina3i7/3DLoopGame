using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static bool IsAttack;
    private int count;

    private void Start()
    {
        IsAttack = false;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PAttack();
            //count = 1;
        }
        else 
        {
            IsAttack = false;
        }
        
    }
    void PAttack()
    {
        //if (count == 1)
        //{
            IsAttack = true;
            count = 0;
        //}
    }
}
