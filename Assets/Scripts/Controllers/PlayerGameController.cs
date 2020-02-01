using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGameController : MonoBehaviour
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
    private float counterToRepair;
    private Pipe currentPipe;
    private CharacterControlSystem _characterControlSystem;

    void Awake()
    {
        counterToRepair = 0;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomSprite();
        this._rigidBodyComponent = this.GetComponent<Rigidbody2D>();
        this._characterControlSystem = GetComponent<CharacterControlSystem>();
        this._characterControlSystem.Repair += Repair;
    }

    private void Repair(InputAction.CallbackContext context)
    {
        if (currentPipe != null && currentPipe.IsBroken  && context.performed)
        {
            counterToRepair += Time.deltaTime;
            if (counterToRepair >= 1)
            {
                currentPipe.FixPipe();
            }
        }
        else
        {
            counterToRepair = 0;
        }
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            currentPipe = collision.GetComponent<Pipe>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            currentPipe = null;
        }
    }
}
