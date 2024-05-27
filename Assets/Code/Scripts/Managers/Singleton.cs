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
                    if (_instance == null)
                        Setup();
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            RemoveDuplicates();
            Initialize();
        }

        protected virtual void Initialize()
        {
            
        }
        private static void Setup()
        {
            _instance = FindObjectOfType<T>();
            if (_instance == null)
            {
                GameObject gameObj = new GameObject();
                gameObj.name = typeof(T).Name;
                _instance = gameObj.AddComponent<T>();
                DontDestroyOnLoad(gameObj);
            }
        }

        private void RemoveDuplicates()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
