using System;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    private static readonly string JOYSTICK_LEFT_ONE_HORIZONTAL = "JLH"; //Joystick Left - horizontal
    private static readonly string JOYSTICK_LEFT_ONE_VERTICAL = "JLV"; //Joystick Left - vertical
    private static readonly string JOYSTICK_A = "AB"; //Joystick A button
    private static readonly string JOYSTICK_B = "BB"; //Joystick B button
    private static readonly string JOYSTICK_X = "XB"; //Joystick X button
    private static readonly string JOYSTICK_Y = "YB"; //Joystick Y button
    private static readonly string TAG_PLAYER = "Player";

    public float maxHorizontalSpeed = 10f;
    public float maxVerticalSpeed = 10f;
    public int numberPlayer = 1;
    public bool fixVerticalMove = false;
    public bool canJump = false;
    public string keyJump = "AB";
    public float forceJump = 5f;

    private Rigidbody2D _rigidBodyComponent;

    private void Awake()
    {
        if (!TAG_PLAYER.Equals(this.tag))
        {
            throw new Exception("El TAG del jugador debe ser establecido a Player.");
        }

        this._rigidBodyComponent = GetComponent<Rigidbody2D>();

        if (fixVerticalMove)
        {
            this.maxVerticalSpeed = 0f;
        }
    }

    public void MoveUpdate()
    {
        float verticalMovement = GetValueJoystickLeftVertical();
        float horizontalMovement = GetValueJoystickLeftHorizontal();

        Move(horizontalMovement, verticalMovement);

        if (IsPressJoystick())
        {
            float y = verticalMovement;
            float x = horizontalMovement;

            Rotate(y, x);
        }
    }

    private void Rotate(float verticalMovement, float horizontalMovement)
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

    public void Jump()
    {
        if (this.canJump && GetButtonDown(this.keyJump))
        {
            this._rigidBodyComponent.velocity = new Vector2(0f, this.forceJump);
        }
    }

    private float GetAxis(string axisName)
    {
        return Input.GetAxis(axisName + GetNumberPlayer());
    }

    private bool GetButtonDown(string buttonName)
    {
        return Input.GetButtonDown(buttonName + GetNumberPlayer());
    }

    private string GetNumberPlayer()
    {
        return this.tag + this.numberPlayer.ToString();
    }

    public bool IsJoystickLeftHorizontalLeft()
    {
        return GetAxis(JOYSTICK_LEFT_ONE_HORIZONTAL) < 0f;
    }

    public bool IsJoystickLeftHorizontalRight()
    {
        return GetAxis(JOYSTICK_LEFT_ONE_HORIZONTAL) > 0f;
    }

    public bool IsJoystickLeftVerticalTop()
    {
        return GetAxis(JOYSTICK_LEFT_ONE_VERTICAL) < 0f;
    }

    public bool IsJoystickLeftVerticalDown()
    {
        return GetAxis(JOYSTICK_LEFT_ONE_VERTICAL) > 0f;
    }

    public float GetValueJoystickLeftHorizontal()
    {
        return GetAxis(JOYSTICK_LEFT_ONE_HORIZONTAL);
    }

    public float GetValueJoystickLeftVertical()
    {
        return GetAxis(JOYSTICK_LEFT_ONE_VERTICAL);
    }

    public bool IsPressButtonA()
    {
        return GetButtonDown(JOYSTICK_A);
    }

    public bool IsPressButtonB()
    {
        return GetButtonDown(JOYSTICK_B);
    }

    public bool IsPressButtonX()
    {
        return GetButtonDown(JOYSTICK_X);
    }

    public bool IsPressButtonY()
    {
        return GetButtonDown(JOYSTICK_Y);
    }

    public bool IsPressAnyButton()
    {
        return IsPressButtonA() || IsPressButtonB() ||
               IsPressButtonX() || IsPressButtonY();
    }

    public bool IsPressJoystick()
    {
        return IsJoystickLeftHorizontalLeft() || IsJoystickLeftHorizontalRight() || IsJoystickLeftVerticalTop() ||
               IsJoystickLeftVerticalDown();
    }

    public bool IsPressJoystickOrAnyButton()
    {
        return IsPressAnyButton() || IsPressJoystick();
    }
}
