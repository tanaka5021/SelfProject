using UnityEngine;
using System.Collections;

public class PlayerSC : MonoBehaviour
{

    public float speed = 6.0F;      //移動速度
    public float jumpSpeed = 8.0F;  //ジャンプ速度
    public float gravity = 20.0F;   //重力
    public GameObject charaobj;     //キャラクターオブジェクト
    public GameObject camobj;       //カメラオブジェクト

    private Vector3 moveDirection = Vector3.zero;  //移動方向

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        //CharacterControllerのisGroundedで接地判定
        if (controller.isGrounded)
        {
            //入力値にカメラのオイラー角を掛ける事で、カメラの角度に応じた移動方向に補正する
            moveDirection = Quaternion.Euler(0, camobj.transform.localEulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //移動方向をローカルからワールド空間に変換する
            moveDirection = transform.TransformDirection(moveDirection);
            //移動速度を掛ける
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
                //ジャンプボタンが押下された場合、y軸方向への移動を追加する
                moveDirection.y = jumpSpeed;

        }

        //移動方向に向けてキャラを回転させる
        charaobj.transform.rotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
        //y軸方向への移動に重力を加える
        moveDirection.y -= gravity * Time.deltaTime;
        //CharacterControllerを移動させる
        controller.Move(moveDirection * Time.deltaTime);
    }
}