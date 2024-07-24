using UnityEngine;

public class Balloon : MonoBehaviour
{
    public Sprite poppedSprite; // Спрайт лопнувшего шарика
    private SpriteRenderer spriteRenderer;
    private bool isPopped = false;
    private GameManager gameManager;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (!isPopped)
        {
            transform.Translate(Vector3.up * Time.deltaTime * gameManager.balloonSpeed);
        }
    }

    void OnMouseDown()
    {
        if (!isPopped)
        {
            Pop();
        }
    }

    void Pop()
    {
        isPopped = true;
        spriteRenderer.sprite = poppedSprite;
        gameManager.IncreaseScore();
        StartCoroutine(DestroyAfterDelay(1f)); // Удалить шарик через 1 секунду
    }

    System.Collections.IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        if (!isPopped)
        {
            gameManager.GameOver();
        }
    }
}
