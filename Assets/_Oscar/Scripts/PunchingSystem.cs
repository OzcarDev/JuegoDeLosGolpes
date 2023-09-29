using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingSystem : MonoBehaviour
{
    [SerializeField] private Transform rightTarget;
    [SerializeField] private Transform leftTarget;
    [SerializeField] private float punchingSpeed;

    [SerializeField] private Transform _inicialPosRightTarget;
    [SerializeField] private Transform _inicialPosLeftTarget;
    [SerializeField] private float punichingOffset;

    [SerializeField] private Transform leftHitPoint;
    [SerializeField] private Transform rightHitPoint;

    [SerializeField] private SphereCollider leftCollider;
    [SerializeField] private SphereCollider rightCollider;
    private bool _leftPunching=false;
    private bool _rightPunching=false;
    // Start is called before the first frame update
    void Start()
    {
        leftCollider.enabled = false;
        rightCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)&&!_leftPunching)
        {
            StartCoroutine(LeftPunchCoroutine(leftTarget));
            
        }
        if (Input.GetMouseButtonDown(1)&&!_rightPunching)
        {
            StartCoroutine(RightPunchCoroutine(rightTarget));
        }
        
    }

   

    IEnumerator RightPunchCoroutine(Transform target)
    {
        _rightPunching = true;

        rightCollider.enabled = true;

        Vector3 nextPosition = rightHitPoint.position;

        while (target.position!=nextPosition)
        {
            target.position = Vector3.MoveTowards(target.position, nextPosition,punchingSpeed * Time.deltaTime);
            yield return null;
        }
        while (target.position != _inicialPosRightTarget.position)
        {
            target.position = Vector3.MoveTowards(target.position, _inicialPosRightTarget.position, punchingSpeed*Time.deltaTime);
            yield return null;
        }
        rightCollider.enabled = false;
        _rightPunching = false;
    }
    IEnumerator LeftPunchCoroutine(Transform target)
    {
        _leftPunching = true;

        leftCollider.enabled = true;
        Vector3 nextPosition = leftHitPoint.position;
        

        while (target.position != nextPosition)
        {
            target.position = Vector3.MoveTowards(target.position, nextPosition, punchingSpeed * Time.deltaTime);
            yield return null;
        }
        while (target.position != _inicialPosLeftTarget.position)
        {
            target.position = Vector3.MoveTowards(target.position, _inicialPosLeftTarget.position, punchingSpeed*Time.deltaTime);
            yield return null;
        }
        leftCollider.enabled = false;
        _leftPunching = false;
    }
}
