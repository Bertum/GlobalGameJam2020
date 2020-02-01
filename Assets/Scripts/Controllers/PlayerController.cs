using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite FemaleSprite;
    public Sprite MaleSprite;
    public AnimationClip FemaleAnimatonClip;
    public AnimationClip MaleAnimationClip;
    private Rigidbody2D _rigidBodyComponent;
    private JoystickController _joystickController;
    private InputKeyController _inputKeyController;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
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
                animator.SetBool("IsFemale", true);
                break;
            case 1:
                spriteRenderer.sprite = MaleSprite;
                animator.SetBool("IsFemale", false);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe") && (Input.GetKeyDown(KeyCode.E) || _joystickController.IsPressButtonX()))
        {
            collision.GetComponent<Pipe>().FixPipe();
        }
    }
}
