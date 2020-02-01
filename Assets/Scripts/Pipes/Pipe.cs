using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Sprite FixedSprite;
    public Sprite BrokenSprite;
    [HideInInspector]
    public bool IsBroken;
    private SpriteRenderer spriteRenderer;
    private PipesManager pipesManager;
    public GameObject Water;

    private void Awake()
    {
        Water.SetActive(false);
        IsBroken = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        pipesManager = GameObject.FindObjectOfType<PipesManager>();
    }

    public void BreakPipe()
    {
        IsBroken = true;
        Water.SetActive(true);
        spriteRenderer.sprite = BrokenSprite;
        pipesManager.CheckBrokenPipes();
    }

    public void FixPipe()
    {
        IsBroken = false;
        Water.SetActive(false);
        spriteRenderer.sprite = FixedSprite;
        pipesManager.CheckBrokenPipes();
    }
}
