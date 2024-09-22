using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{
    [Tooltip("Assign here the sprite to rotate around.")]
    public Transform RotateAround;
    public float RotationSpeed = 60f;
    private bool isMovingLeft = false;
    private bool isMovingRight = false;
    public Button leftButton;  // Referência ao botão esquerdo
    public Button rightButton; // Referência ao botão direito

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (RotateAround != null) 
        {
            Vector3 directionToCenter = RotateAround.position - transform.position;

            float angle = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // Spin the object around the target
            MoveShip(h);
            if (Mathf.Abs(h) != 1) { 
                // Adiciona a movimentação com botões
                if (isMovingLeft)
                {
                    MoveShip(-1); // Move para a esquerda
                }
                else if (isMovingRight)
                {
                    MoveShip(1); // Move para a direita
                }
            }
           
        }
    }

    public void MoveLeft()
    {
        isMovingLeft = true;
    }
    public void MoveRight()
    {
        isMovingRight = true;
    }
    public void OnPointerUp()
    {
        isMovingLeft = false;
        isMovingRight = false;
    }

    private void MoveShip(float direction)
    {
        transform.RotateAround(RotateAround.position, -Vector3.forward, direction * RotationSpeed * Time.deltaTime);
    }
}
