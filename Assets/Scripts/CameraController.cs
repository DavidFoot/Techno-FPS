using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera m_camera;
    void Start()
    {
        m_camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(m_camera.transform.forward.x, 0, m_camera.transform.forward.z));
    }
}
