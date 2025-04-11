using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private BoxCollider2D col;
    private bool isDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isDead) return;

        CheckObstacleCollision();
        CheckSideGroundCollision();
    }

    void CheckObstacleCollision()
    {
        if (col.IsTouchingLayers(obstacleLayer))
        {
            Die("Tocó un obstáculo");
        }
    }

    void CheckSideGroundCollision()
    {
        float sideRayLength = 0.1f;
        Vector2 leftOrigin = (Vector2)transform.position + Vector2.left * col.bounds.extents.x;
        Vector2 rightOrigin = (Vector2)transform.position + Vector2.right * col.bounds.extents.x;

        RaycastHit2D hitLeft = Physics2D.Raycast(leftOrigin, Vector2.left, sideRayLength, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(rightOrigin, Vector2.right, sideRayLength, groundLayer);

        if (hitLeft.collider != null || hitRight.collider != null)
        {
            Die("Choque lateral con el suelo");
        }

        Debug.DrawRay(leftOrigin, Vector2.left * sideRayLength, Color.red);
        Debug.DrawRay(rightOrigin, Vector2.right * sideRayLength, Color.red);
    }

    void Die(string reason)
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("Player muerto: " + reason);

        // Parar al personaje
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = RigidbodyType2D.Static; // Opcional: evita cualquier movimiento posterior

        // Reiniciar escena tras un segundo
        Invoke(nameof(ReloadScene), 1f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
