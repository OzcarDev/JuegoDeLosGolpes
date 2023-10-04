using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeSystem : MonoBehaviour
{
    [SerializeField] float totalLife = 100;
    [SerializeField] float life;
    
    void Start()
    {
        life = totalLife;
    }

    // Update is called once per frame
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            life-=1;
            Debug.Log(life);
            if (life <= 0)
            {
                Debug.Log("GameOver");
            }
        }
    }
}
