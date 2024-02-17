using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.Core.Singleton
{
    public class Singleton3<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Instância estática para o Singleton
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
                // Se não, define a instância para esta
                instance = this as T;
                // Define que este não será destruído ao recarregar a cena
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                // Se a instância já existe e não é esta, destrói esta. Isso impede duplicatas.
                Destroy(gameObject);
            }
        }

    }
}
