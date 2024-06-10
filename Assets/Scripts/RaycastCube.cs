using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class RaycastCube : MonoBehaviour
{

    [SerializeField] private float m_maxDistance = 10;
    [SerializeField] private LayerMask m_layerMask;
    [SerializeField] private LayerMask m_groundMask;
    [SerializeField] private float m_speed = 1; 
    [SerializeField] private GameObject pointer; 
    private LineRenderer m_lineRenderer;
    private Camera m_camera;
    private Vector3 targetPosition = Vector3.zero;
    private bool m_shouldMove = false;
    private Vector3 m_directionNormalized;

    // Start is called before the first frame update
    void Start()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
        m_lineRenderer.SetPosition(1, Vector3.forward * m_maxDistance);
        m_camera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit m_hit;
       
        if (Input.GetMouseButtonDown(0))
        {
            Ray camera_ray = m_camera.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(camera_ray.origin, camera_ray.direction * 25f, Color.black);
            if (Physics.Raycast(camera_ray, out m_hit,50f, m_groundMask))
            {              
                targetPosition = m_hit.point;
                targetPosition.y = 0.5f;
                m_shouldMove = true;
                m_directionNormalized = Vector3.Normalize(m_hit.point - transform.position);
                pointer.transform.position = targetPosition;
                pointer.SetActive(true);
            }         
        }

        if (m_shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, m_speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(m_directionNormalized), 0.5f);
        }
        if ((Vector3.Distance(transform.position, targetPosition) <= 0.5f)) { m_shouldMove = false; pointer.SetActive(false); }



        Ray m_ray = new Ray(transform.position, transform.forward);
        m_lineRenderer.SetPosition(0, Vector3.zero);
        var endOfray = Vector3.forward * m_maxDistance;
        if (Physics.Raycast(m_ray,out m_hit,m_maxDistance, m_layerMask))
        {
          //  m_hit.normal  => perpendiculaire avec la surface touchée
          //  m_hit.point  => point que touche le raycast
          //  m_hit.distance => Distance entre point de départ et point touché
          //  m_hit.collider.gameObject.GetComponent<>   => accès au collider ainsi que tout les composants de l'objet touché
            transform.position = Vector3.MoveTowards(transform.position,m_hit.point,m_speed * Time.deltaTime);
            m_lineRenderer.enabled = true;
            endOfray=  Vector3.forward * m_hit.distance;
        }
        m_lineRenderer.SetPosition(1, endOfray);

    }
}
