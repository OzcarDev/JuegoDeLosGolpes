using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, 0, 0);
        } 
        if (Input.GetButton("Vertical"))
        {
            transform.position += new Vector3(0, 0, Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);
        }
    }
}