using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBodyComponent;
    private JoystickController _joystickController;
    private InputKeyController _inputKeyController;

    void Awake()
    {
        this._rigidBodyComponent = this.GetComponent<Rigidbody2D>();
        this._joystickController = this.GetComponent<JoystickController>();
        this._inputKeyController = this.GetComponent<InputKeyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this._joystickController.IsPressAnyButton())
        {
            this._joystickController.Jump();
        }
        else if (this._inputKeyController.IsKeySpaceDown())
        {
            this._inputKeyController.Jump();
        }
    }

    void FixedUpdate()
    {
        if (this._joystickController.IsPressJoystick())
        {
            this._joystickController.MoveUpdate();
        }
        else if (this._inputKeyController.IsPressMovement())
        {
            this._inputKeyController.MoveUpdate();
        }
        else
        {
            this._rigidBodyComponent.velocity = new Vector2(0f, this._rigidBodyComponent.velocity.y);
        }
    }
}