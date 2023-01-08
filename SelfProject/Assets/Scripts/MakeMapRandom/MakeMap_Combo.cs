using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMap_Combo : MonoBehaviour
{
    //10個の迷路の型を入れる
    [SerializeField]
    private GameObject[] Maps;

    //ランダムに選ばれる2個のマップを格納
    [SerializeField]
    private GameObject Map_UnderPosi;
    [SerializeField]
    private GameObject Map_UpperPosi;


    // Start is called before the first frame update
    void Start()
    {
        //上部マップ決定・移動・合体
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
