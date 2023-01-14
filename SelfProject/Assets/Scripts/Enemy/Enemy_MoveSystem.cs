using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MoveSystem : MonoBehaviour
{
    //敵の移動スピード
    [SerializeField]
    private float enemy_moveSpeed;

    //方角のパターンを決める
    //0:北、1:東、2:西、3:南
    [SerializeField]
    private int patarn_compass_point;

    bool isFirst = true; // 最初の一回を判定するフラグ

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        patarn_compass_point = Random.RandomRange(0, 4);

        Debug.Log(patarn_compass_point);
    }

    void FixedUpdate()
    {
        // 一回だけ呼ばれる
        if (isFirst)
        {
            isFirst = false;  // 一回はすぎた
            Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
            Vector3 force = new Vector3(0.0f, 8.0f, 1.0f);  // 力を設定
            rb.AddForce(force, ForceMode.Impulse);          // 力を加える
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
