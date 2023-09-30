using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetecter : MonoBehaviour
{
    [SerializeField] private ConfigurableJoint[] joints;
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyController enemyController;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Fist")
        {
            Debug.Log("Hit");
            Dead();
        }
    }

    private void Dead()
    {
        ActiveRagdoll();
        enemyController.isDead = true;
        Destroy(enemyController.gameObject,6);
    }

    private void ActiveRagdoll()
    {
        animator.enabled = false;
        foreach (ConfigurableJoint joint in joints)
        {
            JointDrive jointDrive = joint.angularXDrive;
            jointDrive.positionSpring = 0f;
            jointDrive.positionDamper = 0f;
            joint.angularXDrive = jointDrive;

            joint.angularYZDrive = jointDrive;
        }
    }
}
