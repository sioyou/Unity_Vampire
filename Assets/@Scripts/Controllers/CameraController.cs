using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        // todo
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
    }
}
