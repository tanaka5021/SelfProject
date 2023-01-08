using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform tf; //Main Camera��Transform
    Camera cam; //Main Camera��Camera
    Rigidbody hrb; //Human�i�e�I�u�W�F�N�g�j��Rigidbody

    void Start()
    {
        tf = this.gameObject.GetComponent<Transform>(); //Main Camera��Transform���擾����B
        cam = this.gameObject.GetComponent<Camera>(); //Main Camera��Camera���擾����B
        hrb = transform.parent.gameObject.GetComponent<Rigidbody>(); //Human�i�e�I�u�W�F�N�g�j��Rigidbody���擾����B
    }

    void FixedUpdate()
    {
        if (!(Input.GetKey(KeyCode.LeftShift)) && Input.GetKey(KeyCode.UpArrow)) //��L�[��������Ă����
        {
            hrb.position = hrb.position + (transform.forward * Time.deltaTime * 7.0f); //�l��O�i������B
        }
        else if (!(Input.GetKey(KeyCode.LeftShift)) && Input.GetKey(KeyCode.DownArrow)) //���L�[��������Ă����
        {
            hrb.position = hrb.position - (transform.forward * Time.deltaTime * 7.0f); //�l���ジ���肳����B
        }
        if (!(Input.GetKey(KeyCode.LeftShift)) && Input.GetKey(KeyCode.LeftArrow)) //���L�[��������Ă����
        {
            hrb.position = hrb.position - (transform.right * Time.deltaTime * 7.0f); //�l�����փJ�j����������B
        }
        else if (!(Input.GetKey(KeyCode.LeftShift)) && Input.GetKey(KeyCode.RightArrow)) //�E�L�[��������Ă����
        {
            hrb.position = hrb.position + (transform.right * Time.deltaTime * 7.0f); //�l���E�փJ�j����������B
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.UpArrow)) //������Shift�Ə�L�[��������Ă����
        {
            transform.Rotate(new Vector3(-2.0f, 0.0f, 0.0f)); //�J��������։�]�B
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.DownArrow)) //������Shift�Ɖ��L�[��������Ă����
        {
            transform.Rotate(new Vector3(2.0f, 0.0f, 0.0f)); //�J���������։�]�B
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow)) //������Shift�ƍ��L�[��������Ă����
        {
            transform.Rotate(new Vector3(0.0f, -2.0f, 0.0f)); //�J���������։�]�B
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow)) //������Shift�ƉE�L�[��������Ă����
        {
            transform.Rotate(new Vector3(0.0f, 2.0f, 0.0f)); //�J�������E�։�]�B
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.R)) //������Shift��R�L�[��������Ă����
        {
            tf.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f); //�J�����̉�]�����Z�b�g����B
        }
    }
}