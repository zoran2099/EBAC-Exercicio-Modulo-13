using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyerHelper : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;

    public void KillPlayer()
    {
        player.DestroyMe();
    }
}
