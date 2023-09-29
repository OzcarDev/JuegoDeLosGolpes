using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeTest : MonoBehaviour
{
    private Renderer[] allChildRenderers;
    public Material[] allMaterials;

    private void Start()
    {
        allChildRenderers = GetComponentsInChildren<Renderer>();
        allMaterials = new Material[allChildRenderers.Length];
        for (int i = 0; i < allChildRenderers.Length; i++)
        {
            allMaterials[i] = allChildRenderers[i].GetComponent<Renderer>().material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ColorChanger());
        }
    }

    IEnumerator ColorChanger()
    {
        for (int i = 0; i < this.allMaterials.Length; i++)
        {
            this.allMaterials[i].SetColor("_Color", Color.red);
        }
        yield return new WaitForSeconds(.25f);

        for (int i = 0; i < this.allMaterials.Length; i++)
        {
            this.allMaterials[i].SetColor("_Color", Color.white);
        }
    }
}
