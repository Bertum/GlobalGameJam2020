using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CharacterControlSystem : MonoBehaviour, InputSystemActionsManager.IPlayerGeneralActions
{
    public float maxHorizontalSpeed = 10f;
    public float maxVerticalSpeed = 10f;
    public int numberPlayer = 1;
    public bool fixVerticalMove = false;
    public bool canJump = false;
    public float forceJump = 5f;
    private InputSystemActionsManager _inputSystemActionsManager;
    private Rigidbody2D _rigidBodyComponent;
    public InputSystemActionsManager.PlayerGeneralActions PlayerGeneralActions { get; set; }

    void Awake()
    {
        this._inputSystemActionsManager = new InputSystemActionsManager();
        this._rigidBodyComponent = GetComponent<Rigidbody2D>();
        this.PlayerGeneralActions = this._inputSystemActionsManager.PlayerGeneral;
        this._inputSystemActionsManager.PlayerGeneral.SetCallbacks(this);

        if (fixVerticalMove)
        {
            this.maxVerticalSpeed = 0f;
        }
    }

    private void OnEnable()
    {
        this._inputSystemActionsManager.Enable();
    }

    private void OnDisable()
    {
        this._inputSystemActionsManager.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 movementAction = context.ReadValue<Vector2>();
            float verticalMovement = movementAction.y;
            float horizontalMovement = movementAction.x;
            
            Move(horizontalMovement, verticalMovement);
            Rotate(horizontalMovement, verticalMovement);
        }
        else if(context.canceled)
        {
            this._rigidBodyComponent.velocity = new Vector2(0f, this._rigidBodyComponent.velocity.y);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && this.canJump)
        {
            this._rigidBodyComponent.velocity = new Vector2(0f, this.forceJump);
        }
    }

    private void Rotate(float horizontalMovement, float verticalMovement)
    {
        float x = 0f;
        float y = 0f;
        float z = 0f;
        Quaternion transformRotation;

        if (this.fixVerticalMove)
        {
            y = Mathf.Atan2(0, -1 * horizontalMovement);
            transformRotation = Quaternion.Euler(new Vector3(x, y * Mathf.Rad2Deg, z));
        }
        else
        {
            z = Mathf.Atan2(-1 * horizontalMovement, verticalMovement);
            transformRotation = Quaternion.Euler(new Vector3(x, y, z * Mathf.Rad2Deg));
        }

        this.transform.rotation = transformRotation;
    }

    private void Move(float horizontalMovement, float verticalMovement)
    {
        float y;
        float x = horizontalMovement * this.maxHorizontalSpeed;

        if (this.fixVerticalMove)
        {
            y = this._rigidBodyComponent.velocity.y;
        }
        else
        {
            y = verticalMovement * this.maxVerticalSpeed;
        }

        this._rigidBodyComponent.velocity = new Vector2(x, y);
    }
}