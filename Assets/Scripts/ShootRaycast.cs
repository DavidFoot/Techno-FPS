using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRaycast : MonoBehaviour
{
    [SerializeField] Camera m_camera;
    [SerializeField] Transform m_gun;
    private LineRenderer m_lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        m_lineRenderer = m_gun.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_lineRenderer.enabled = false;
        RaycastHit hit;
        //Debug.DrawRay(m_camera.transform.position, m_camera.transform.forward * 100f, Color.red);
        if (Input.GetMouseButton(0)){
            m_lineRenderer.enabled = true;
            m_lineRenderer.SetPosition(0, m_gun.transform.position);
            m_lineRenderer.SetPosition(1, m_camera.transform.position + m_camera.transform.forward * 100f);
            if (Physics.Raycast(m_gun.transform.position, m_camera.transform.forward.normalized, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}
