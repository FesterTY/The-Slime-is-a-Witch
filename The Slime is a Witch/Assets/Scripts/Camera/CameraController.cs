using UnityEngine;

public class CameraController : MonoBehaviour
{

    Transform targetPos;

    public float moveSpeed = 5f;

    private void Awake()
    {
        targetPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 newTargetPos = new Vector3(targetPos.position.x, targetPos.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newTargetPos, moveSpeed * Time.deltaTime);
    }
}