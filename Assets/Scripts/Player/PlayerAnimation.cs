using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private bool PMove;
    private bool PJump;
    private bool PAttack;

    private Animator Anim;


    private void Start()
    {
        PMove = false;
        PJump = false;
        PAttack = false;

        Anim  = GetComponent<Animator>();  
    }

    private void Update()
    {
        PMove = PalyerMove.IsMove;
        PJump = PalyerMove.IsJump;
        PAttack = PlayerAttack.IsAttack;
        if (PMove){Anim.SetBool("OnMove", true);}
        else{Anim.SetBool("OnMove", false);}
        if (PJump) { Anim.SetTrigger("OnJump"); }
        if(PAttack){ Anim.SetTrigger("OnAttack"); }
        
    }
}
