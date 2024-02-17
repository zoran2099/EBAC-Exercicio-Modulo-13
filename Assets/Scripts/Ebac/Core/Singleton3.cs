using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.Core.Singleton
{
    public class Singleton3<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Inst�ncia est�tica para o Singleton
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject singleton = new GameObject(typeof(T).Name);
                        instance = singleton.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                // Se n�o, define a inst�ncia para esta
                instance = this as T;
                // Define que este n�o ser� destru�do ao recarregar a cena
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                // Se a inst�ncia j� existe e n�o � esta, destr�i esta. Isso impede duplicatas.
                Destroy(gameObject);
            }
        }

    }
}
