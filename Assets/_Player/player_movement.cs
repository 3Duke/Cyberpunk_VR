using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    //public float speed = 10.0f;
    //private Rigidbody _rigidbody;

    // Start is called before the first frame update
    //void Start()
    //{
    //    _rigidbody = gameObject.GetComponent<Rigidbody>();
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, _rigidbody.velocity.z + (speed * Time.deltaTime));
    //    }
    //}

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    private float mouseX;
    private float mouseY;
    public float sensitivity;

    void Update()
    {
        CharacterController controller = gameObject.GetComponent<CharacterController>();

        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }

        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        if (mouseX != 0)
        {
            mouseX = Mathf.Clamp(mouseX, -90f, 90f);
            transform.rotation = Quaternion.Euler(mouseX, 0, 0);
        }
        if (mouseY != 0)
        {
            mouseY = Mathf.Clamp(mouseY, -90f, 90f);
            transform.rotation = Quaternion.Euler(0, mouseY, 0);
        }

        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }
}
