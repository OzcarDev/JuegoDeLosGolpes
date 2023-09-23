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

    private bool _leftPunching=false;
    private bool _rightPunching=false;
    // Start is called before the first frame update
    void Start()
    {
       
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
        RaycastHit hit;
        Vector3 nextPosition = Vector3.zero;
        var ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f));

        if (Physics.Raycast(ray, out hit, 100))
        {
            nextPosition = hit.point;
        }
        else
        {
            nextPosition = _inicialPosRightTarget.position;
        }

        nextPosition *= punichingOffset;

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
        _rightPunching = false;
    }
    IEnumerator LeftPunchCoroutine(Transform target)
    {
        _leftPunching = true;
        RaycastHit hit;
        Vector3 nextPosition = Vector3.zero;
        var ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f));

        if (Physics.Raycast(ray, out hit, 100))
        {
            nextPosition = hit.point;
        }
        else
        {
            nextPosition = _inicialPosLeftTarget.position;
        }

        nextPosition *= punichingOffset;

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
        _leftPunching = false;
    }
}
