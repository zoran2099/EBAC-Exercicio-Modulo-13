using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    // Start is called before the first frame update

    public static Teste instance;

    private void Awake()
    {

        
        if (instance == null)
        {
            instance = this;

        } else {
            Destroy(gameObject);
        }

    }
}
