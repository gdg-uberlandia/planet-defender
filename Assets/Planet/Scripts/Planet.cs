using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private float currentlHealth = 0;
    public float maxHealth = 10f;
    public GameObject ship;
    public Color damageColor = Color.red; // Cor que o objeto vai piscar quando tomar dano
    public float flashDuration = 0.2f;    // Duração do flash
    private Color originalColor;          // Cor original do objeto
    private SpriteRenderer spriteRenderer;

    public float rotationSpeed = .5f;


    private Animator animator;




    // public float dragFactor = 0.95f;

    private float currentRotationSpeed = 0f;

    private PlanetHealth planetHealth;



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        animator = GetComponent<Animator>();
        planetHealth = GetComponent<PlanetHealth>();

        planetHealth.UpdateHealthText(maxHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        float inputHorizontal = Input.GetAxis("Horizontal");


        // Aumenta a velocidade de rotação baseado no input, invertendo a direção
        currentRotationSpeed = inputHorizontal * rotationSpeed;

        // Aplica a rotação ao sprite
        transform.Rotate(Vector3.forward, currentRotationSpeed * Time.deltaTime);

        // Aplica o fator de arrasto para suavizar a rotação ao longo do tempo
        //currentRotationSpeed *= dragFactor;
    }


    // Chame esta função quando o objeto tomar dano
    public void TakeDamage()
    {
        StartCoroutine(FlashDamage());
    }


    public void Destroyed()
    {
        animator.SetBool("Exploded", true);
        StartCoroutine(Dead());
    }


    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Destroy(ship);
        planetHealth.Dead();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {

            if (planetHealth != null)
            {
                planetHealth.UpdateHealthText(1f, maxHealth); // Reduzir a vida do planeta
                TakeDamage();

                if (currentlHealth <= 0)
                {
                    Destroyed();
                }
            }
        }
    }



    // Corrotina que altera a cor temporariamente
    IEnumerator FlashDamage()
    {
        // Mudar a cor para a cor de dano
        spriteRenderer.color = damageColor;

        // Esperar pela duração do flash
        yield return new WaitForSeconds(flashDuration);

        // Voltar à cor original
        spriteRenderer.color = originalColor;
    }
}
