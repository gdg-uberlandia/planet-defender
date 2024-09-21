using UnityEngine;

public class ShipFire : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do projétil
    public Transform firePoint; // Ponto de onde o projétil será disparado

    private float nextFireTime = 0f;

    public float fireRate = 0.5f; // Taxa de disparo em segundos

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Atualiza o tempo para o próximo disparo
        }
    }

    private void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}