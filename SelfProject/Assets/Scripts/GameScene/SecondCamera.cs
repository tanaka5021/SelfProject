using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerObject;

    Vector3 camerasTransform;

    // Start is called before the first frame update
    void Start()
    {
        camerasTransform = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        camerasTransform.x = PlayerObject.transform.position.x;

        camerasTransform.z = PlayerObject.transform.position.x;

    }
}
