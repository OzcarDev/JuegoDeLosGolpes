using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : Steering
{
    [SerializeField] private EnemyController enemyController;
    public bool arrival = false;
    public float slowingRadius = 3f;

    private void Start()
    {
        enemyController = GetComponent<EnemyController>();
    }
    public override Vector3 GetForce()
    {
        DesiredVelocity = (Target - Position);
        float distance = DesiredVelocity.magnitude;
        if(arrival && slowingRadius < distance )
        {
            enemyController.myState = EnemyController.EnemyState.Attack;
            DesiredVelocity = (Target - Position).normalized * speed * (distance/slowingRadius);
            return DesiredVelocity - Velocity;
        }
        else
        {
            enemyController.myState = EnemyController.EnemyState.Seek;
            DesiredVelocity = (Target - Position).normalized * speed;
            return DesiredVelocity - Velocity;
        }
    }
}
