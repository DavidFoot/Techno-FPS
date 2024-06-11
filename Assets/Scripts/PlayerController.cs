using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_jumpHeight;
    public float gravity = -9.81f;
    public float gravityScale = 1f;
    private float m_velocity;
    private CharacterController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * 10f;
        float straff = Input.GetAxis("Horizontal") * 10f;

        // World space To LocalSpace
        //transform.position += transform.TransformDirection(new Vector3(0, 0, translation * Time.deltaTime));
        //transform.position += transform.TransformDirection(new Vector3(straff * Time.deltaTime, 0, 0));

        // Mini Teleport en local Space ? 

        //transform.Translate(0, 0, translation * Time.deltaTime);
        //transform.Translate(straff * Time.deltaTime , 0, 0);


        // Using CharacterController
        //playerController.Move(transform.TransformDirection(new Vector3(0, 0, translation * Time.deltaTime)));
        //playerController.Move(transform.TransformDirection(new Vector3(straff * Time.deltaTime, 0, 0)));


        m_velocity += gravity * gravityScale * Time.deltaTime;
        if (IsGrounded() && m_velocity < 0)
        {
            m_velocity = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            m_velocity = m_jumpHeight;
        }
        Debug.Log("Player Grounded : " + IsGrounded());

        playerController.Move(transform.TransformDirection(new Vector3(straff, m_velocity, translation ) * Time.deltaTime));

    }
    // Inutile avec le CharacterController

    private bool IsGrounded()
    {
        // Bigger Raycast 'cause of CharacterController Height
        if (Physics.Raycast(transform.position,Vector3.down,1.1f))
        {
            return true;
        }
        return false;
    }
}
