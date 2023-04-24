using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    [SerializeField]
    Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = transform.position + offset;
    }
}
