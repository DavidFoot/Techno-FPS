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
        m_camera.transform.position = transform.position;
        m_camera.transform.rotation = transform.rotation;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * 10f;
        float rotationX = Input.GetAxis("Mouse X") * 50f;
        float straff = Input.GetAxis("Horizontal") * 10f;

        translation *= Time.deltaTime;
        straff *= Time.deltaTime;
        rotationX *= Time.deltaTime;


        transform.Translate(0, 0, translation);
        transform.Translate(straff, 0 , 0);
        transform.Rotate(0, rotationX, 0);
        m_camera.transform.position = transform.position;
        transform.rotation = m_camera.transform.rotation;
    }
}
