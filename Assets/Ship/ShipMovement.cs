using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [Tooltip("Assign here the sprite to rotate around.")]
    public Transform RotateAround;
    public float RotationSpeed = 60f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        if(RotateAround != null) {
            Vector3 directionToCenter = RotateAround.position - transform.position;

            float angle = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg + 90;

            transform.rotation = Quaternion.Euler(0, 0, angle);

            // Spin the object around the target
            transform.RotateAround(RotateAround.position, -Vector3.forward, h * RotationSpeed * Time.deltaTime);
        }
        
    }
}