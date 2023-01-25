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
    private int patarn_compass_point = 0;
    [SerializeField]
    private int nextPatarn_compass_point;

    //方向更新にどのくらい時間を開けるかの変数
    [SerializeField]
    private float how_wait_seconds;

    //向きを変えていいタイミングか否か
    bool patarn_change = true;

    // 移動していい状態かの判断
    bool canMove = true;

    //速度チェックしていい状況下の判定
    bool canChack = true;

    //リジッドボディの格納
    Rigidbody rb;

    //加える力の格納
    Vector3 force;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        //リジッドボディのコンポーネントを格納
        rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
    }

    void FixedUpdate()
    {
        //方向換えていいタイミングなエア
        if (patarn_change)
        {
            //方向を決めるコルーチンを呼び出す
            StartCoroutine("ChangeMoveCompass");
        }

        // 一回だけ呼ばれる
        if (canMove)
        {
            //移動中にして
            canMove = false;

            //進む方向によってケース分け
            switch (patarn_compass_point)
            {
                //北
                case 0:
                    force = new Vector3(0.0f, 8.0f, enemy_moveSpeed);  // 力を設定
                    break;

                //東
                case 1:
                    force = new Vector3(enemy_moveSpeed, 8.0f, 0.0f);  // 力を設定
                    break;

                //西
                case 2:
                    force = new Vector3(-enemy_moveSpeed, 8.0f, 0.0f);  // 力を設定
                    break;

                //南
                case 3:
                    force = new Vector3(0.0f, 8.0f, -enemy_moveSpeed);  // 力を設定
                    break;
            }

            //力を加える
            rb.AddForce(force, ForceMode.Impulse);          // 力を加える
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
        //方向決まるまで変えれないようにする
        patarn_change = false;

        //次に進む方向を選択
        nextPatarn_compass_point = Random.RandomRange(0, 4);

        //次の進む方向と今回進んでた方向(初期値は0)が一致しないように制限を掛ける
        if (nextPatarn_compass_point != patarn_compass_point)
        {
            //違うならそのまま代入
            patarn_compass_point = nextPatarn_compass_point;
        }
        else
        {
            //同じとき
            //次に進む方向が北なら
            if (nextPatarn_compass_point == 0)
            {
                //東にする
                patarn_compass_point = nextPatarn_compass_point + 1;
            }
            //南なら
            else if (nextPatarn_compass_point == 3)
            {
                //西にする
                patarn_compass_point = nextPatarn_compass_point - 1;
            }
            else
            {
                //どちらでもないとき
                //一時的に変数作成
                int tmp = Random.RandomRange(0, 2);

                //0なら
                if (tmp == 0)
                {
                    //次に進む方向を現在の方向＋９０度
                    patarn_compass_point = nextPatarn_compass_point + 1;
                }
                //1なら
                else
                {
                    //次に進む方向を現在の方向ー９０度
                    patarn_compass_point = nextPatarn_compass_point - 1;
                }
            }
        }

        //方向が決まったから移動できるようにして
        canMove = true;

        //指定の時間待つ
        yield return new WaitForSeconds(how_wait_seconds);

        //その後方向変換できるように変数更新
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
