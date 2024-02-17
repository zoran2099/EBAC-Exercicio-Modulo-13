using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.Core.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Inst�ncia est�tica para o Singleton
        private static T instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = GetComponent<T>();
            } else
            {
                Destroy(gameObject);
            }

        }
    }
}
