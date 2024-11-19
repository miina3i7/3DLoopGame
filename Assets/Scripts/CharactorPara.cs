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
        //キャラクターのダメージ処理
        Damage();
        //キャラクターの死亡処理
        Dead();
    }
    private void Damage()
    {
        //Player
        //Enemyに当たったとき
        if(myTag == "Palyer" && touchEnemy)
        {
            HP -= damage;
        }
        //Enemy
        //Playerに当たったとき
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
            //当たったキャラのCharaParaスクリプトからAp情報を取得し、daamageに入れる
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
