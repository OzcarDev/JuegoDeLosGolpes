using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Steering stering;
    public GameObject target;
    public Seek _seek;
    public enum EnemyState
    {
        Seek,
        Attack
    }
    public EnemyState myState;

    private void Start()
    {
        _seek = GetComponent<Seek>();
    }
    void Update()
    {
        switch(myState)
        {
            case EnemyState.Seek:
                _seek.enabled = true;
                _seek.speed = 1;
                break;
            case EnemyState.Attack:
                _seek.enabled = false;
                _seek.speed = 5;
                break;
        }
        stering.Target = target.transform.position;
    }
}
