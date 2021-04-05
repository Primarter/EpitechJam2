using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;

    private float hMove = 0f;
    [SerializeField] bool m_AllowCrouch = true;
    private bool crouch = false;
    private bool jump = false;

    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(hMove));

        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (m_AllowCrouch && Input.GetButtonDown("Crouch"))
            crouch = true;
        else if (m_AllowCrouch && Input.GetButtonUp("Crouch"))
            crouch = false;
    }

    void FixedUpdate()
    {
        controller.Move(hMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLandEvent()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouchEvent(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
}
