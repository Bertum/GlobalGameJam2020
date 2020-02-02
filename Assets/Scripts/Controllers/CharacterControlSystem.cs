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
    public bool canJump = true;
    public float forceJump = 5f;
    private InputSystemActionsManager _inputSystemActionsManager;
    private Rigidbody2D _rigidBodyComponent;
    public InputSystemActionsManager.PlayerGeneralActions PlayerGeneralActions { get; set; }
    public Action<InputAction.CallbackContext> Pause { get; set; }
    public Action<InputAction.CallbackContext> Repair { get; set; }
    private bool move;
    private InputAction.CallbackContext moveContext;

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

    public void OnEnable()
    {
        this._inputSystemActionsManager.Enable();
    }

    public void OnDisable()
    {
        this._inputSystemActionsManager.Disable();
    }

    private void FixedUpdate()
    {
        if (this.move)
        {
            Vector2 movementAction = this.moveContext.ReadValue<Vector2>();
            float verticalMovement = movementAction.y;
            float horizontalMovement = movementAction.x;
            
            Move(horizontalMovement, verticalMovement);
            Rotate(horizontalMovement, verticalMovement);
        }
        else
        {
            this._rigidBodyComponent.velocity = new Vector2(0f, this._rigidBodyComponent.velocity.y);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            this.move = true;
            this.moveContext = context;
        }
        
        if(context.canceled)
        {
            this.move = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && this.canJump)
        {
            this._rigidBodyComponent.velocity = new Vector2(0f, this.forceJump);
            this.canJump = false;
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        this.Pause.Invoke(context);
    }

    public void OnRepair(InputAction.CallbackContext context)
    {
        this.Repair.Invoke(context);
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