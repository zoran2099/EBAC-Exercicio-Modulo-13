using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class UIInGameManager : Singleton3<UIInGameManager>
{
   
    public  TextMeshProUGUI textCoins;
    
    public static void UpdateTextCoins(string amount)
    {
        Instance.textCoins.text = amount;
    }

    
}
