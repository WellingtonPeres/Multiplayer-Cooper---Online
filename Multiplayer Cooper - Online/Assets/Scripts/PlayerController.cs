
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveRotation = 0.15f;

    // Get Controls
    private Vector2 move;
    private bool isInteraction;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Interact.performed += OnInteraction;
    }

    private void OnDisable()
    {
        inputActions.Disable();

        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Interact.performed -= OnInteraction;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        isInteraction = context.ReadValueAsButton();
    }

    private void Update()
    {
        MovePlayer();
        InterectionItems();
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), moveRotation);
        }
    }

    private void InterectionItems()
    {
        if (isInteraction)
        {
            Debug.Log("Interagi com algo está: " + isInteraction);// Sempre fica positivo antes da interação
            isInteraction = !isInteraction;
            Debug.Log("Interagi com algo está: " + isInteraction);// Sempre fica negativo depois da interação
        }
    }
}
