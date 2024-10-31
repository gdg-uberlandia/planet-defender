using UnityEngine;

public class RemoveVelocity : MonoBehaviour
{

    public float lifetime = 1.5f;

    private void Update()
    {

        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            GameObject ship = GameObject.FindGameObjectWithTag("Ship");
            ship.GetComponent<ShipMovement>().AddVelocity(-5f);
        }
    }
}
