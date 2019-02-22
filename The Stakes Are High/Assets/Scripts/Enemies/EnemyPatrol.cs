using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyPatrol : MonoBehaviour
{
    public Transform patrolDetection;
    public float groundDetectionDistance = 1f;
    public LayerMask detectionLayerMask;

    public float wallDetectionDistance = 0.3f;

    bool movingLeft = true;

    public void Move(float _moveSpeed)
    {
        transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
    }

    public void CheckPatrolGround()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(patrolDetection.position, Vector2.down, groundDetectionDistance, detectionLayerMask);
        if (groundInfo.collider == null)
        {
            CheckMovement();
        }
    }

    public void CheckPatrolWall()
    {
        RaycastHit2D wallInfo = Physics2D.Raycast(patrolDetection.position, Vector2.left, wallDetectionDistance, detectionLayerMask);

        if (wallInfo.collider != null)
        {
            CheckMovement();
        }
    }

    public void CheckMovement()
    {
        if (movingLeft)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingLeft = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            movingLeft = true;
        }
    }
}
