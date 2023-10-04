using System;
using UnityEngine;
using TMPro;

public class lifeSystem : MonoBehaviour
{
    [SerializeField] float totalLife = 100;
    [SerializeField] float life;
    public TextMeshProUGUI LifeCounter;
    public GameObject gameOverPanel;
    
    void Start()
    {
        life = totalLife;
    }

    private void Update()
    {
        LifeCounter.text = life.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            life-=1;
            Debug.Log(life);
            if (life <= 0)
            {
                life = 0;
                PlayerController._isPaused = true;
                gameOverPanel.SetActive(true);
            }
        }
    }
}
