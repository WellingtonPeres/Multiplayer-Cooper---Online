using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask objectInteractionLayer;
    [SerializeField] private Transform itemPoint;
    
    private bool isWalking;
    private Vector3 lastInteractDirection;

    private bool isInteracted;

    private void Update()
    {
        HandleMovement();
        handleInteractions();
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void handleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDirection != Vector3.zero)
        {
            lastInteractDirection = moveDirection;
        }

        float interactDisctance = 2f;
        RaycastHit raycastHit;
        if (Physics.Raycast(transform.position, lastInteractDirection, out raycastHit, interactDisctance))
        {
            //Debug.Log(raycastHit.collider.name);
            isInteracted = true;

            if (isInteracted && Input.GetKeyDown(KeyCode.E))// Colocar o controle do gamepad também
            {
                raycastHit.collider.GetComponentInChildren<Item>().gameObject.transform.position = itemPoint.parent.position;
                //Debug.Log("Peguei o item: " + raycastHit.collider.GetComponentInChildren<Item>().name);
            }
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 2;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance);

        if (!canMove)
        {
            // Cannot move towards moveDirection
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0, 0).normalized;// Attempt only X movement
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionX, moveDistance);

            if (canMove)
            {
                moveDirection = moveDirectionX;// Can move only on the X
            }
            else
            {
                // Cannot move only on the X
                Vector3 moveDirectionZ = new Vector3(0, 0, moveDirection.z).normalized;// Attempt only Z movement
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionZ, moveDistance);

                if (canMove)
                {
                    moveDirection = moveDirectionZ;//Can move only on the Z
                }
                else
                {
                    // Cannot move in any direction
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        isWalking = moveDirection != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }
}
