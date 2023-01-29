using UnityEngine;
using System.Collections;

public class PlayerSC : MonoBehaviour
{

    public float speed = 6.0F;      //�ړ����x
    public float jumpSpeed = 8.0F;  //�W�����v���x
    public float gravity = 20.0F;   //�d��
    public GameObject charaobj;     //�L�����N�^�[�I�u�W�F�N�g
    public GameObject camobj;       //�J�����I�u�W�F�N�g

    private Vector3 moveDirection = Vector3.zero;  //�ړ�����

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        //CharacterController��isGrounded�Őڒn����
        if (controller.isGrounded)
        {
            //���͒l�ɃJ�����̃I�C���[�p���|���鎖�ŁA�J�����̊p�x�ɉ������ړ������ɕ␳����
            moveDirection = Quaternion.Euler(0, camobj.transform.localEulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //�ړ����������[�J�����烏�[���h��Ԃɕϊ�����
            moveDirection = transform.TransformDirection(moveDirection);
            //�ړ����x���|����
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
                //�W�����v�{�^�����������ꂽ�ꍇ�Ay�������ւ̈ړ���ǉ�����
                moveDirection.y = jumpSpeed;

        }

        //�ړ������Ɍ����ăL��������]������
        charaobj.transform.rotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
        //y�������ւ̈ړ��ɏd�͂�������
        moveDirection.y -= gravity * Time.deltaTime;
        //CharacterController���ړ�������
        controller.Move(moveDirection * Time.deltaTime);
    }
}