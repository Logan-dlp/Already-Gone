using UnityEngine;

namespace AlreadyGone.DesignPattern.Singletons
{
    public abstract class MonoSingleton<T> : MonoBehaviour, ISingleton where T : MonoSingleton<T>
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
                    {
                        GameObject obj = new GameObject(typeof(T).Name);
                        _instance = obj.AddComponent<T>();
                        _instance.OnMonoSingletonCreated();
                    }
                }
                return _instance;
            }
        }

        private SingletonInitializationStatus _initializationStatus = SingletonInitializationStatus.None;
        public virtual bool IsInitialized => _initializationStatus == SingletonInitializationStatus.Initialized;

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                InitializeSingleton();
            }
            else
            {
                if (Application.isPlaying)
                {
                    Destroy(gameObject);
                }
                else
                {
                    DestroyImmediate(gameObject);
                }
            }
        }
        
        public virtual void InitializeSingleton()
        {
            if (_initializationStatus != SingletonInitializationStatus.None)
                return;

            _initializationStatus = SingletonInitializationStatus.Initializing;
            OnInitializing();
            _initializationStatus = SingletonInitializationStatus.Initialized;
            OnInitialized();
        }

        public virtual void ClearSingleton() { }

        public static void CreateInstance()
        {
            DestroyInstance();
            _instance = Instance;
        }
        
        public static void DestroyInstance()
        {
            if (_instance == null)
                return;
            
            _instance.ClearSingleton();
            _instance = default(T);
        }
        
        protected virtual void OnMonoSingletonCreated() { }
        protected virtual void OnInitializing() { }
        protected virtual void OnInitialized() { }
    }
}