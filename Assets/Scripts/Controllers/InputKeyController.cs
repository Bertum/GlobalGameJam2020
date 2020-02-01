using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyController : MonoBehaviour
{
    private const string KEY_HORIZONTAL = "Horizontal";
    private const string KEY_VERTICAL = "Vertical";

    public float moveSpeed = 10f;
    private Rigidbody2D _rigidBodyComponent;
    public float forceJump = 5f;

    private void Awake()
    {
        this._rigidBodyComponent = GetComponent<Rigidbody2D>();
    }

    public void MoveUpdate()
    {
        Move(GetValueHorizontal(), 0f);

        if (IsPressMovement())
        {
            float angle = Mathf.Atan2(0f, -1 * GetValueHorizontal());
            this.transform.rotation = Quaternion.Euler(new Vector3(0, angle * Mathf.Rad2Deg, 0f));
        }
    }

    public void Jump()
    {
        this._rigidBodyComponent.velocity = new Vector2(0f, this.forceJump);
    }

    public bool IsKeyUpArrow()
    {
        return IsKey(KeyCode.UpArrow);
    }

    public bool IsKeyDownArrow()
    {
        return IsKey(KeyCode.DownArrow);
    }

    public bool IsKeyLeftArrow()
    {
        return IsKey(KeyCode.LeftArrow);
    }

    public bool IsKeyRightArrow()
    {
        return IsKey(KeyCode.RightArrow);
    }

    public bool IsKeySpace()
    {
        return IsKey(KeyCode.Space);
    }

    public bool IsKeySpaceDown()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public float GetValueHorizontal()
    {
        return GetAxis(KEY_HORIZONTAL);
    }

    public float GetValueVertical()
    {
        return GetAxis(KEY_VERTICAL);
    }

    public bool IsPressMovement()
    {
        return IsKeyDownArrow() || IsKeyLeftArrow() || IsKeyRightArrow() || IsKeyUpArrow();
    }

    private bool IsKey(KeyCode keyCode)
    {
        return Input.GetKey(keyCode);
    }

    private void Move(float horizontalMovement, float verticalMovement)
    {
        this._rigidBodyComponent.velocity =
            new Vector2(horizontalMovement * this.moveSpeed, this._rigidBodyComponent.velocity.y);
    }

    private float GetAxis(string axisName)
    {
        return Input.GetAxis(axisName);
    }
}