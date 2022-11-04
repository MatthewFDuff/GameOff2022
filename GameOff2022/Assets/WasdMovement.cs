using UnityEngine;

public class WasdMovement : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");
        var verticalMovement = Input.GetAxis("Vertical");

        var effectiveSpeed = speed * Time.deltaTime;
        var movementVec = new Vector3(horizontalMovement, verticalMovement, 0);
        if (movementVec.magnitude > 1) movementVec = movementVec.normalized;

        transform.position += movementVec * effectiveSpeed;
    }
}
