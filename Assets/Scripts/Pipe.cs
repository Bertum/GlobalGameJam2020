using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Sprite FixedSprite;
    public Sprite BrokenSprite;
    [HideInInspector]
    public bool IsBroken;
    private SpriteRenderer spriteRenderer;
    private PipesManager pipesManager;

    private void Awake()
    {
        IsBroken = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        pipesManager = GameObject.FindObjectOfType<PipesManager>();
    }

    public void BreakPipe()
    {
        IsBroken = true;
        spriteRenderer.sprite = BrokenSprite;
        pipesManager.CheckBrokenPipes();
    }

    public void FixPipe()
    {
        IsBroken = false;
        spriteRenderer.sprite = FixedSprite;
        pipesManager.CheckBrokenPipes();
    }
}
