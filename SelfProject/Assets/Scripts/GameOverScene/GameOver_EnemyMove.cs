using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOver_EnemyMove : MonoBehaviour
{
    //敵のオブジェクトを格納
    [SerializeField]
    private GameObject EnemyObject;

    //何秒で終了させるか
    [SerializeField]
    private float waitSeconds;

    //どこまで移動させるか
    [SerializeField]
    private Vector3 goalPoint;

    private Animator anim;
    bool isStop;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine("ComeEnemy");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ComeEnemy()
    {
        EnemyObject.transform.DOLocalMove(goalPoint, waitSeconds);

        yield return new WaitForSeconds(waitSeconds-1f);

        anim.SetBool("isStop", true);

    }
}
