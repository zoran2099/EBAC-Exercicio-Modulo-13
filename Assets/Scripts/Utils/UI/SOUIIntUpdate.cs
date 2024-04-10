using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SOUIIntUpdate : MonoBehaviour
{

    public TextMeshProUGUI textCoins;
    public SOInt soInt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textCoins.text = soInt.value.ToString();
    }
}
