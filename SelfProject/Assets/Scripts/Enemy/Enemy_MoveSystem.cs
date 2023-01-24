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
    private int patarn_compass_point = 0;
    [SerializeField]
    private int nextPatarn_compass_point;

    //�����X�V�ɂǂ̂��炢���Ԃ��J���邩�̕ϐ�
    [SerializeField]
    private float how_wait_seconds;

    //������ς��Ă����^�C�~���O���ۂ�
    bool patarn_change = true;

    // �ړ����Ă�����Ԃ��̔��f
    bool canMove = true;

    //���x�`�F�b�N���Ă����󋵉��̔���
    bool canChack = true;

    //���W�b�h�{�f�B�̊i�[
    Rigidbody rb;

    //������͂̊i�[
    Vector3 force;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        //���W�b�h�{�f�B�̃R���|�[�l���g���i�[
        rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
    }

    void FixedUpdate()
    {
        //���������Ă����^�C�~���O�ȃG�A
        if (patarn_change)
        {
            //���������߂�R���[�`�����Ăяo��
            StartCoroutine("ChangeMoveCompass");
        }

        // ��񂾂��Ă΂��
        if (canMove)
        {
            //�ړ����ɂ���
            canMove = false;

            //�i�ޕ����ɂ���ăP�[�X����
            switch (patarn_compass_point)
            {
                //�k
                case 0:
                    force = new Vector3(0.0f, 8.0f, enemy_moveSpeed);  // �͂�ݒ�
                    break;

                //��
                case 1:
                    force = new Vector3(enemy_moveSpeed, 8.0f, 0.0f);  // �͂�ݒ�
                    break;

                //��
                case 2:
                    force = new Vector3(-enemy_moveSpeed, 8.0f, 0.0f);  // �͂�ݒ�
                    break;

                //��
                case 3:
                    force = new Vector3(0.0f, 8.0f, -enemy_moveSpeed);  // �͂�ݒ�
                    break;
            }

            //�͂�������
            rb.AddForce(force, ForceMode.Impulse);          // �͂�������
        }

        //if ((rb.velocity.x > -0.6f && rb.velocity.x < 0.6f) && (rb.velocity.z > -0.6f && rb.velocity.z < 0.6f))
        if (rb.velocity.x == 0.0f && rb.velocity.z == 0.0f)
        {

            if (canChack)
            {
                StartCoroutine("VelocityChack");
            }
        }

        Debug.Log(rb.velocity);
    }

    [System.Obsolete]
    IEnumerator ChangeMoveCompass()
    {
        //�������܂�܂ŕς���Ȃ��悤�ɂ���
        patarn_change = false;

        //���ɐi�ޕ�����I��
        nextPatarn_compass_point = Random.RandomRange(0, 4);

        //���̐i�ޕ����ƍ���i��ł�����(�����l��0)����v���Ȃ��悤�ɐ������|����
        if (nextPatarn_compass_point != patarn_compass_point)
        {
            //�Ⴄ�Ȃ炻�̂܂ܑ��
            patarn_compass_point = nextPatarn_compass_point;
        }
        else
        {
            //�����Ƃ�
            //���ɐi�ޕ������k�Ȃ�
            if (nextPatarn_compass_point == 0)
            {
                //���ɂ���
                patarn_compass_point = nextPatarn_compass_point + 1;
            }
            //��Ȃ�
            else if (nextPatarn_compass_point == 3)
            {
                //���ɂ���
                patarn_compass_point = nextPatarn_compass_point - 1;
            }
            else
            {
                //�ǂ���ł��Ȃ��Ƃ�
                //�ꎞ�I�ɕϐ��쐬
                int tmp = Random.RandomRange(0, 2);

                //0�Ȃ�
                if (tmp == 0)
                {
                    //���ɐi�ޕ��������݂̕����{�X�O�x
                    patarn_compass_point = nextPatarn_compass_point + 1;
                }
                //1�Ȃ�
                else
                {
                    //���ɐi�ޕ��������݂̕����[�X�O�x
                    patarn_compass_point = nextPatarn_compass_point - 1;
                }
            }
        }

        //���������܂�������ړ��ł���悤�ɂ���
        canMove = true;

        //�w��̎��ԑ҂�
        yield return new WaitForSeconds(how_wait_seconds);

        //���̌�����ϊ��ł���悤�ɕϐ��X�V
        patarn_change = true;
    }

    IEnumerator VelocityChack()
    {
        canChack = false;

        patarn_change = true;


        yield return new WaitForSeconds(0.2f);

        canChack = true;

    }
}
