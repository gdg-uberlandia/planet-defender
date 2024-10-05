using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float rotationSpeed = .5f;
    // public float dragFactor = 0.95f;

    private float currentRotationSpeed = 0f;
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
}
