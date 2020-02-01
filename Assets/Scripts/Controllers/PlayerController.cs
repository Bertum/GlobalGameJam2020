using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBodyComponent;
    private JoystickController _joystickController;
    private InputKeyController _inputKeyController;
    public Sprite FemaleSprite;
    public Sprite MaleSprite;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomSprite();
        this._rigidBodyComponent = this.GetComponent<Rigidbody2D>();
        this._joystickController = this.GetComponent<JoystickController>();
        this._inputKeyController = this.GetComponent<InputKeyController>();
    }

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

    private void SetRandomSprite()
    {
        var rnd = Random.Range(0, 2);
        switch (rnd)
        {
            case 0:
                spriteRenderer.sprite = FemaleSprite;
                break;
            case 1:
                spriteRenderer.sprite = MaleSprite;
                break;
        }
    }
}
