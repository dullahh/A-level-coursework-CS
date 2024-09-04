using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class movement : MonoBehaviour
{
    public CharacterController controller;

    Rigidbody rb;// abbreviative purpose

    public float gravity = -0.8f;
    public float jumpHeight = 3f;

    
    private float moveSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float crouchingSpeed;


    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.C;
    
    
    
    public float crouchingYState;
    private float OriginalYState;
    

    private void Start()
    {
        OriginalYState = transform.localScale.y;
    }
       
    private void stateHandling()
    {    // sprinting mode
        if(isGrounded && Input.GetKey(runKey))
        {
            
            moveSpeed = runSpeed;
        }
        else
        {   // walk
            
            moveSpeed = walkSpeed;
        }
        //start crouch
        
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchingYState, transform.localScale.z);
            rb.AddForce(Vector3.down * 6f, ForceMode.Impulse);
        }
        //standing up
        if(Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, OriginalYState, transform.localScale.z);
        }

        //crouch speed
        if (Input.GetKey(crouchKey))
        {
           
            moveSpeed = crouchingSpeed;
        }
    }

    public Transform groundCheck; //he Transform component determines the Position, Rotation, and Scale of each object in the scene. Every GameObject has a Transform.
    public float groundDistance = 0.2f; //radius of feet checker
    public LayerMask groundMask; //Layer masking is a nondestructive way to hide parts of an image or layer without erasing them.
                                 //They're great for making image composites, modifying background colors, removing or cutting out objects, and targeting your edits so they affect only certain areas, rather than the entire layer.

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {

        
        stateHandling();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        print(isGrounded);   
        controller.Move(move * moveSpeed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // creates a sphere based on the 'groundcheck position', ground distance as the radius, and groundmask as a layermask
       
        if (Input.GetButtonDown("Jump") && isGrounded)//the word 'jump' here gets mapped to the spacebar input
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

    velocity.y += gravity* Time.deltaTime;

    controller.Move(velocity* Time.deltaTime);
    }
}