using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alertaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("autoDestruccion", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void autoDestruccion()
    {
        this.gameObject.SetActive(false);
    }
}
