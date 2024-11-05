using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdImpulse = 5;
    public GameObject ExplosionPrefab;

    private PointEffector2D effector;

    private BoxCollider2D boxCollider;

    private SpriteRenderer spriteRenderer;

    internal void Start()
    {
        effector = GetComponent<PointEffector2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void Destruct()
    {
        Destroy(gameObject);
    }

    private void Boom()
    {
        effector.enabled = true;
        spriteRenderer.enabled = false;
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
        Invoke("Destruct", 0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var contact in collision.contacts)
        {
            if (contact.normalImpulse >= ThresholdImpulse)
            {
                Boom();
                return;
            }
        }
    }
}