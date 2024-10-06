using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem deathParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Vector2 hitDirection = (transform.position - collision.transform.position).normalized;

            float angle = Mathf.Atan2(hitDirection.y, hitDirection.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            Instantiate(deathParticles, transform.position, rotation);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
