using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    private bool isPlayer;
    private bool isMove;
    private bool isDeath;
    private bool isGoal;

    public ElementObject eo;

    private Rigidbody2D rb;

    private float speed = 500;
    private float jumpForce = 400;

    private bool isJumpPressed;

    void Awake()
    {

        isPlayer = false;
        isMove = false;
        isDeath = false;
        isGoal = false;

        rb = GetComponent<Rigidbody2D>();
        EventCenter.AddListener<ElementObject,ElementBehavior>(EventType.ChangeElementCombination, ChangeElementCombination);
        //isPlayer = true;
    }

    void OnDestroy()
    {
        EventCenter.RemoveListener<ElementObject, ElementBehavior>(EventType.ChangeElementCombination, ChangeElementCombination);
    }

    void Update()
    {
        if (isPlayer)
        {
            if(Input.GetButtonDown("Jump"))
            {
                isJumpPressed = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (isPlayer)
        {
            PlayerMovement();
        }
    }


    private void PlayerMovement()
    {
        float horizaontalMove = Input.GetAxis("Horizontal");
        float faceDirection = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizaontalMove * speed * Time.deltaTime, rb.velocity.y);

        if (faceDirection != 0)
        {
            transform.localScale = new Vector3(faceDirection, 1, 1);
        }

        if (isJumpPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
            isJumpPressed = false;
        }
    }



    private void Death()
    {

    }

    private void Goal()
    {

    }

    public void ChangeElementCombination(ElementObject eo, ElementBehavior behavior)
    {
        if (this.eo == eo)
        {
            if (behavior == ElementBehavior.Player) isPlayer = !isPlayer;
            else if (behavior == ElementBehavior.Death) isDeath = !isDeath;
            else if (behavior == ElementBehavior.Move) isMove = !isMove;
            else if (behavior == ElementBehavior.Goal) isGoal = !isGoal;
        }
    }

}