using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MoveSystem : MonoBehaviour
{
    //�G�̈ړ��X�s�[�h
    [SerializeField]
    private float enemy_moveSpeed;

    //���p�̃p�^�[�������߂�
    //0:�k�A1:���A2:���A3:��
    [SerializeField]
    private int patarn_compass_point;

    bool isFirst = true; // �ŏ��̈��𔻒肷��t���O

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        patarn_compass_point = Random.RandomRange(0, 4);

        Debug.Log(patarn_compass_point);
    }

    void FixedUpdate()
    {
        // ��񂾂��Ă΂��
        if (isFirst)
        {
            isFirst = false;  // ���͂�����
            Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
            Vector3 force = new Vector3(0.0f, 8.0f, 1.0f);  // �͂�ݒ�
            rb.AddForce(force, ForceMode.Impulse);          // �͂�������
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Obsolete]
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            patarn_compass_point = Random.RandomRange(0, 4);

            Debug.Log(patarn_compass_point);
        }
    }
}
