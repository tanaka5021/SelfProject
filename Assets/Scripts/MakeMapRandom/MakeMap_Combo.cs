using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMap_Combo : MonoBehaviour
{
    //10�̖��H�̌^������
    [SerializeField]
    private GameObject[] Maps;

    //�����_���ɑI�΂��2�̃}�b�v���i�[
    [SerializeField]
    private GameObject Map_UnderPosi;
    [SerializeField]
    private GameObject Map_UpperPosi;


    // Start is called before the first frame update
    void Start()
    {
        //�㕔�}�b�v����E�ړ��E����
        int tmp_Upper = Random.Range(0, Maps.Length);
        Map_UpperPosi = Maps[tmp_Upper];
        Instantiate(Map_UpperPosi, new Vector3(60.0f, 0.0f, 75.0f), Quaternion.identity);


        int tmp_Under = Random.Range(0, Maps.Length);
        Map_UnderPosi = Maps[tmp_Under];
        Instantiate(Map_UnderPosi, new Vector3(0f, 0.0f, 0.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
