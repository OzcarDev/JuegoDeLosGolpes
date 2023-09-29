using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private ConfigurableJoint hipJoint;
    [SerializeField] private Rigidbody hip;
    public Transform Position;
    [SerializeField] private Animator targetAnimator;

    [SerializeField] private Fabrik fabrikRightArm;
    [SerializeField] private Transform rightArmPivot;
    [SerializeField] private Fabrik fabrikLeftArm;
    [SerializeField] private Transform leftArmPivot;

    private bool walk = false;


    [SerializeField] private Transform rightTarget;
    [SerializeField] private Transform leftTarget;
    [SerializeField] private float punchingSpeed;

    [SerializeField] private Transform _inicialPosRightTarget;
    [SerializeField] private Transform _inicialPosLeftTarget;
    [SerializeField] private float punichingOffset;
    [SerializeField] private float punchingFrecuency;

    private bool _leftPunching = false;
    private bool _rightPunching = false;

    private Transform _player;

   
    [SerializeField] private float radiusAttack;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        fabrikRightArm.startPosition = rightArmPivot.position;
        fabrikLeftArm.startPosition = leftArmPivot.position;
        Vector3 direction = (_player.position - Position.position).normalized;
        // Debug.Log(Vector3.Distance(_player.position, Position.position));
        if (Vector3.Distance(_player.position,Position.position)>radiusAttack)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            this.hipJoint.targetRotation = Quaternion.Euler(targetAngle, 0f, 0f);

            this.hip.AddForce(direction * this.speed);

            this.walk = true;
        }  else {
            this.walk = false;
           

            if (!_leftPunching)
            {
                StartCoroutine(LeftPunchCoroutine(leftTarget));

            }
            if (!_rightPunching)
            {
                StartCoroutine(RightPunchCoroutine(rightTarget));
            }
        }

       this.targetAnimator.SetBool("Walk", this.walk);

        
    }


    IEnumerator RightPunchCoroutine(Transform target)
    {
        _rightPunching = true;
        
        Vector3 nextPosition = Vector3.zero;
       

        nextPosition = _player.position;

        nextPosition *= punichingOffset;

        while (target.position != nextPosition)
        {
            target.position = Vector3.MoveTowards(target.position, nextPosition, punchingSpeed * Time.deltaTime);
            yield return null;
        }
        while (target.position != _inicialPosRightTarget.position)
        {
            target.position = Vector3.MoveTowards(target.position, _inicialPosRightTarget.position, punchingSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(punchingFrecuency);
        _rightPunching = false;
    }
    IEnumerator LeftPunchCoroutine(Transform target)
    {
        _leftPunching = true;
       
        Vector3 nextPosition = Vector3.zero;
      

        nextPosition = _player.position;

        nextPosition *= punichingOffset;

        while (target.position != nextPosition)
        {
            target.position = Vector3.MoveTowards(target.position, nextPosition, punchingSpeed * Time.deltaTime);
            yield return null;
        }
        while (target.position != _inicialPosLeftTarget.position)
        {
            target.position = Vector3.MoveTowards(target.position, _inicialPosLeftTarget.position, punchingSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(punchingFrecuency);
        _leftPunching = false;
    }
}
