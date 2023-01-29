using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOver_EnemyMove : MonoBehaviour
{
    //�G�̃I�u�W�F�N�g���i�[
    [SerializeField]
    private GameObject EnemyObject;

    //���b�ŏI�������邩
    [SerializeField]
    private float waitSeconds;

    //�ǂ��܂ňړ������邩
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
