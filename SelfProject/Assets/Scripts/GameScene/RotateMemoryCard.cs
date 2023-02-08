using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RotateMemoryCard : MonoBehaviour
{
    [SerializeField]
    private GameObject RotateCardObject;

    // Start is called before the first frame update
    void Start()
    {
        RotateCardObject.transform.DOLocalRotate(new Vector3(0, 380f, 0f), 6f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnColliderEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //memory�̎擾
            this.gameObject.SetActive(false);
        }
        else if (collider.gameObject.tag == "wall")
        {
            //memory���Ǔ��ɂ��邩��o�O��Ȃ��悤�ɍ폜���Ă���
            Destroy(this.gameObject);
        }
    }

    public void OnColliderExit(Collider other)
    {
        
    }
}
