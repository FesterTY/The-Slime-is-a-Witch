using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyPatrol patrol;

    public float moveSpeed = 5f;

    void Start()
    {
        patrol = GetComponent<EnemyPatrol>();
    }

    void Update()
    {
        patrol.Move(moveSpeed);
    }

    private void FixedUpdate()
    {
        patrol.CheckPatrolGround();
        patrol.CheckPatrolWall();
    }
}
