using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform targetPos;

    public float moveSpeed = 5f;

    
    void Update()
    {
        Vector3 newTargetPos = new Vector3(targetPos.position.x, targetPos.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newTargetPos, moveSpeed * Time.deltaTime);
    }
}
