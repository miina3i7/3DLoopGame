using Unity.VisualScripting;
using UnityEngine;

public class PalyerMove : MonoBehaviour
{
    //private
    private Rigidbody rb;       //Rigidbodyの取得
    private float x;            //キーボード（AD）の取得
    private float z;            //キーボード（WS）の取得
    private bool isGround;      //地面との当たり判定

    //public
    [SerializeField] float moveSpeed;    //Playerの移動速度
    [SerializeField] float jumpForce;     //Playerのジャンプ力
    public static bool IsMove;
    public static bool IsJump;



    private void Start()
    {
        //Rigidbodyの取得
        rb = GetComponent<Rigidbody>();
        //フラグをfalseにする
        isGround = false;
        IsMove = false;
        IsJump = false;
    }

    private void Update()
    {

        //Playerの移動処理
        //Xにキー情報(AD)を格納
        //Zにキー情報(WS)を格納
        //velocityでの移動処理(X ×　moveSpeed, y ,Z ×　moveSpeed)
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //Playerの移動時の向きを変える
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 cameraRight = Vector3.Scale(Camera.main.transform.right, new Vector3(1, 0, 1)).normalized;

        Vector3 moveForward = (cameraForward * z + cameraRight * x).normalized;
        //Vector3 moveForward = (cameraForward  + cameraRight );

        if(x != 0 || z != 0)
        {
            IsMove = true;
        }
        else
        {
            IsMove = false;
        }

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
        
        transform.position += moveForward * moveSpeed * Time.deltaTime;

        //Playerのジャンプ処理
        //Spaceボタンが押された&&Playerが地面に触れている
        //ジャンプ処理(AddForce)
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(new Vector3(0,jumpForce,0));
            IsJump = true;
        }
    }

    //Playerと地面が触れているか
    private void OnCollisionStay(Collision other)
    { 
        //Playerが"Planes"に触れているか
        //isGroundフラグをtureに
        if(other.gameObject.CompareTag("Plane"))
        {
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        //Playerが"Planes"に触れていないか
        //isGroundフラグをfalseに
        if (other.gameObject.CompareTag("Plane"))
        {
            isGround = false;
            IsJump = false;
        }
    }
}
