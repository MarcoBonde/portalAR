using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensManager : MonoBehaviour
{
    public GameObject lenti;
    public AudioSource background;

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<AudioSource>();
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
            background.Play();
        }
        if (other.CompareTag("SpegniLenti"))
        {
            lenti.SetActive(false);
            
        }
    }

}
