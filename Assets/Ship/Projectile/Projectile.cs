using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = .5f;



    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime); // Move o projétil
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}