using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Code.Scripts.Managers
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            
        }


    }
}
