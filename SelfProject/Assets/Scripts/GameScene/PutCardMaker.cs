using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutCardMaker : MonoBehaviour
{
    [SerializeField]
    private GameObject MemoryObject;

    [SerializeField]
    private GameObject[] Position_tmp;

    private float random_x, random_z;
    private int count = 0;
    private bool canPut;

    // Start is called before the first frame update
    void Start()
    {
        RandomCardMaker();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RandomCardMaker()
    {
        for (int i = 0; i < Position_tmp.Length; i++)
        {
            Instantiate(MemoryObject, Position_tmp[i].transform.position, Quaternion.identity);
        }
    }
}
