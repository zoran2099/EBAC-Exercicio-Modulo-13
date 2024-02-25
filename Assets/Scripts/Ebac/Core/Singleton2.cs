using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ebac.Core.Singleton
{
    public class Singleton2 : MonoBehaviour
    {

        private static Singleton2 _instance;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Awake()
        {
            // Garanta que apenas uma inst�ncia do Singleton exista
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            // Mantenha o Singleton vivo entre as cenas
            DontDestroyOnLoad(this.gameObject);
        }
                
        // Propriedade est�tica para acessar a inst�ncia
        public static Singleton2 Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Procure a inst�ncia na cena
                    _instance = FindObjectOfType<Singleton2>();
                    // Se n�o encontrar, crie uma nova inst�ncia
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(Singleton2).Name);
                        _instance = singletonObject.AddComponent<Singleton2>();
                    }
                }
                return _instance;
            }
        }


    }
}