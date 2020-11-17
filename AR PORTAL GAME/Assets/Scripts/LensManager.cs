using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensManager : MonoBehaviour
{
    public GameObject lenti;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AccendiLenti"))
        {
            lenti.SetActive(true);
        }
        if (other.CompareTag("SpegniLenti"))
        {
            lenti.SetActive(false);
        }
    }

}
