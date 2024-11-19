using UnityEngine;

public class CharactorPara : MonoBehaviour
{
    public CharaPara CharaPara;

    private int HP;
    private int Attack;
    private string myTag;

    private bool touchPlayer;
    private bool touchEnemy;

    private int damage;
    public static bool GameOver;
    private void Start()
    {
        HP = CharaPara.Hp;
        myTag = gameObject.tag;
        GameOver = false;
    }

    private void Update()
    {
        //�L�����N�^�[�̃_���[�W����
        Damage();
        //�L�����N�^�[�̎��S����
        Dead();
    }
    private void Damage()
    {
        //Player
        //Enemy�ɓ��������Ƃ�
        if(myTag == "Palyer" && touchEnemy)
        {
            HP -= damage;
        }
        //Enemy
        //Player�ɓ��������Ƃ�
        else if (myTag == "Enmey" && touchPlayer)
        {
            HP -= damage;
        }
    }
    private void Dead()
    {
        if(HP <= 0)
        {
            if(myTag == "Player")
            {
                GameOver = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            touchPlayer = true;
            //���������L������CharaPara�X�N���v�g����Ap�����擾���Adaamage�ɓ����
            CharactorPara touch = collision.gameObject.GetComponent<CharactorPara>();
            damage = touch.Attack;
        }
        
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            touchEnemy = true;
            CharactorPara touch = collision.gameObject.GetComponent<CharactorPara>();
            damage = touch.Attack;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touchPlayer = false;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            touchEnemy = false;
        }
    }
}
