using Unity.VisualScripting;
using UnityEngine;

public class PalyerMove : MonoBehaviour
{
    //private
    private Rigidbody rb;       //Rigidbody�̎擾
    private float x;            //�L�[�{�[�h�iAD�j�̎擾
    private float z;            //�L�[�{�[�h�iWS�j�̎擾
    private bool isGround;      //�n�ʂƂ̓����蔻��

    //public
    [SerializeField] float moveSpeed;    //Player�̈ړ����x
    [SerializeField] float jumpForce;     //Player�̃W�����v��
    public static bool IsMove;
    public static bool IsJump;



    private void Start()
    {
        //Rigidbody�̎擾
        rb = GetComponent<Rigidbody>();
        //�t���O��false�ɂ���
        isGround = false;
        IsMove = false;
        IsJump = false;
    }

    private void Update()
    {

        //Player�̈ړ�����
        //X�ɃL�[���(AD)���i�[
        //Z�ɃL�[���(WS)���i�[
        //velocity�ł̈ړ�����(X �~�@moveSpeed, y ,Z �~�@moveSpeed)
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //Player�̈ړ����̌�����ς���
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

        //Player�̃W�����v����
        //Space�{�^���������ꂽ&&Player���n�ʂɐG��Ă���
        //�W�����v����(AddForce)
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(new Vector3(0,jumpForce,0));
            IsJump = true;
        }
    }

    //Player�ƒn�ʂ��G��Ă��邩
    private void OnCollisionStay(Collision other)
    { 
        //Player��"Planes"�ɐG��Ă��邩
        //isGround�t���O��ture��
        if(other.gameObject.CompareTag("Plane"))
        {
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        //Player��"Planes"�ɐG��Ă��Ȃ���
        //isGround�t���O��false��
        if (other.gameObject.CompareTag("Plane"))
        {
            isGround = false;
            IsJump = false;
        }
    }
}
