using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeStick : MonoBehaviour
{
    public int max_z; //�t�B�[���h�̏c���B5�ȏ�̊�ɂ��邱�ƁB
    public int max_x; //�t�B�[���h�̉����B5�ȏ�̊�ɂ��邱�ƁB
    int z; //�t�B�[���h�z��̏c�̗v�f�ԍ�
    int x; //�t�B�[���h�z��̉��̗v�f�ԍ�
    int r; //�����̒l
    Object wall; //�ǃI�u�W�F�N�g
    GameObject wallgo; //�ǂ̃Q�[���I�u�W�F�N�g

    void Start()
    {
        int[,] field = new int[max_z, max_x]; //�t�B�[���h�i0���ʘH�ŁA1���ǁB�j
        wall = Resources.Load("Wall"); //�ǃI�u�W�F�N�g��ǂݍ��ށB

        //�ʘH�i0�j�̐���
        for (z = 0; z < max_z; z = z + 1) //�t�B�[���h�̏c���̕��������[�v����B
        {
            for (x = 0; x < max_x; x = x + 1) //�t�B�[���h�̉����̕��������[�v����B
            {
                field[z, x] = 0;
            }
        }

        //�㉺�̊O�ǁi1�j�̐���
        for (x = 0; x < max_x; x = x + 1) //�t�B�[���h�̉����̕��������[�v����B
        {
            field[0, x] = 1;
            field[max_z - 1, x] = 1;
        }

        //���E�̊O�ǁi1�j�̐���
        for (z = 0; z < max_z; z = z + 1) //�t�B�[���h�̏c���̕��������[�v����B
        {
            field[z, 0] = 1;
            field[z, max_x - 1] = 1;
        }

        //�_�|���@���g�����ǁi1�j�̐����i1�s�߂̂݁j
        z = 2; //1�s��
        for (x = 2; x < max_x - 1; x = x + 2) //�v�f�ԍ�x��2����v�f�ԍ�max_x-1�̒l�܂ŁA1�}�X��΂��Ŗ_�|���B
        {
            r = Random.Range(1, 13); //���������ir = 1����12�̃����_���Ȓl�j
            field[z, x] = 1; //���S����c�c
            if (r <= 3) //r��3�ȉ��̂Ƃ�
            {
                if (field[z - 1, x] == 0) //��ɖ_�i�ǁj���Ȃ����
                {
                    field[z - 1, x] = 1; //��ɖ_��|���B
                }
                else if (field[z - 1, x] == 1) //��ɖ_�i�ǁj�������
                {
                    x = x - 2; //�_��|�����ɁA������������蒼���B
                }
            }
            if (r >= 4 && r <= 6) //r��4����6�̂Ƃ�
            {
                if (field[z + 1, x] == 0) //���ɖ_�i�ǁj���Ȃ����
                {
                    field[z + 1, x] = 1; //���ɖ_��|���B
                }
                else if (field[z + 1, x] == 1) //���ɖ_�i�ǁj�������
                {
                    x = x - 2; //�_��|�����ɁA������������蒼���B
                }
            }
            if (r >= 7 && r <= 9) //r��7����9�̂Ƃ�
            {
                if (field[z, x - 1] == 0) //���ɖ_�i�ǁj���Ȃ����
                {
                    field[z, x - 1] = 1; //���ɖ_��|���B
                }
                else if (field[z, x - 1] == 1) //���ɖ_�i�ǁj�������
                {
                    x = x - 2; //�_��|�����ɁA������������蒼���B
                }
            }
            if (r >= 10) //r��10�ȏ�̂Ƃ�
            {
                if (field[z, x + 1] == 0) //�E�ɖ_�i�ǁj���Ȃ����
                {
                    field[z, x + 1] = 1; //�E�ɖ_��|���B
                }
                else if (field[z, x + 1] == 1) //�E�ɖ_�i�ǁj�������
                {
                    x = x - 2; //�_��|�����ɁA������������蒼���B
                }
            }
        }

        //�_�|���@���g�����ǁi1�j�̐����i2�s�߈ȍ~�j
        for (z = 4; z < max_z - 1; z = z + 2) //z�̗v�f�ԍ�4����v�f�ԍ�max_z-1�܂ŁA1�}�X��΂��Ŗ_�|���B
        {
            for (x = 2; x < max_x - 1; x = x + 2) //x�̗v�f�ԍ�2����v�f�ԍ�max_x-1�܂ŁA1�}�X��΂��Ŗ_�|���B
            {
                r = Random.Range(1, 13); //���������ir = 1����12�̃����_���Ȓl�j
                field[z, x] = 1; //���S����c�c
                if (r <= 4) //r��4�ȉ��̂Ƃ�
                {
                    if (field[z + 1, x] == 0) //���ɖ_�i�ǁj���Ȃ����
                    {
                        field[z + 1, x] = 1; //���ɖ_��|���B
                    }
                    else if (field[z + 1, x] == 1) //���ɖ_�i�ǁj�������
                    {
                        x = x - 2; //�_��|�����ɁA������������蒼���B
                    }
                }
                if (r >= 5 && r <= 8) //r��5����8�̂Ƃ�
                {
                    if (field[z, x - 1] == 0) //���ɖ_�i�ǁj���Ȃ����
                    {
                        field[z, x - 1] = 1; //���ɖ_��|���B
                    }
                    else if (field[z, x - 1] == 1) //���ɖ_�i�ǁj�������
                    {
                        x = x - 2; //�_��|�����ɁA������������蒼���B
                    }
                }
                if (r >= 9) //r��9�ȏ�̂Ƃ�
                {
                    if (field[z, x + 1] == 0) //�E�ɖ_�i�ǁj���Ȃ����
                    {
                        field[z, x + 1] = 1; //�E�ɖ_��|���B
                    }
                    else if (field[z, x + 1] == 1) //�E�ɖ_�i�ǁj�������
                    {
                        x = x - 2; //�_��|�����ɁA������������蒼���B
                    }
                }
            }
        }

        field[0, 1] = 0; //�X�^�[�g�n�_�̕ǂ�P������B
        field[max_z - 1, max_x - 2] = 0; //�S�[���n�_�̕ǂ�P������B

        //�ǂ̔z�u
        for (z = 0; z < max_z; z = z + 1) //�t�B�[���h�̏c���̕��������[�v����B
        {
            for (x = 0; x < max_x; x = x + 1) //�t�B�[���h�̉����̕��������[�v����B
            {
                if (field[z, x] == 0) //�ʘH�Ȃ�
                {
                    //�����z�u���Ȃ��B
                }
                else if (field[z, x] == 1) //�ǂȂ�
                {
                    wallgo = (GameObject)Instantiate(wall, new Vector3(5.0f * x, 5.0f, 5.0f * z), Quaternion.identity); //�ǂ�z�u����B
                }
            }
        }
    }
}