using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public float speedPlayer = 6f;
    public float speedJumpPlayer = 7f;
    public float gravity = -20f;
    //public float MouseSensivityPlayer = 2f;
    

    //private Camera PlayerCamera;
    private CharacterController CharacterController;
    private Vector3 velocity;
    public bool IsGrounded;

    public void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        
    }

    public void Update()
    {
        IsGrounded = CharacterController.isGrounded;

        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // —брасываем скорость по Y, если на земле
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            velocity.y += Mathf.Sqrt(speedJumpPlayer * -2f * gravity);
        }


        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        velocity.y += gravity * Time.deltaTime;

        CharacterController.Move(move * speedPlayer * Time.deltaTime);
        CharacterController.Move(velocity * Time.deltaTime);





    }


}
