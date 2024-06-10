using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float m_jumpHeight;
    public float gravity = -9.81f;
    public float gravityScale = 1f;
    private float m_velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_velocity += gravity * gravityScale * Time.deltaTime;
        if (IsGrounded() && m_velocity < 0)
        {
            m_velocity = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            m_velocity = m_jumpHeight;
        }
        transform.Translate(new Vector3(0, m_velocity, 0) * Time.deltaTime);

    }
    private bool IsGrounded()
    {
        if (Physics.Raycast(transform.position,Vector3.down,1f))
        {
            return true;
        }
        return false;
    }
}
