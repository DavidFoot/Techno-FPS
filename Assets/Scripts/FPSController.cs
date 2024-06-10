using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera m_camera;
    void Start()
    {
        m_camera = Camera.main;
        m_camera.transform.position = transform.position;
        m_camera.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        float translation = Input.GetAxis("Vertical") * 10f;
        float rotationX = Input.GetAxis("Mouse X") * 50f;
        //float rotationY = Input.GetAxis("Mouse Y") * 40f;
        float straff = Input.GetAxis("Horizontal") * 10f;

        translation *= Time.deltaTime;
        straff *= Time.deltaTime;
        rotationX *= Time.deltaTime;
        //rotationY *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Translate(straff, 0 , 0);

        transform.Rotate(0, rotationX, 0);
        //m_camera.transform.Rotate(rotationY, 0, 0);

        m_camera.transform.position = transform.position;
        m_camera.transform.rotation = transform.rotation;

        //m_camera.transform.rotation = transform.rotation;
    }
}
