using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.LevelScene
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager SharedInstance;
        public List<GameObject> pooledObjects;
        public GameObject objectToPool;
        public int poolSize;
        
        void Awake()
        {
            SharedInstance = this;
        }

        void Start()
        {
            pooledObjects = new List<GameObject>();
            GameObject tmp;
            
            for(var i = 0; i < poolSize; i++)
            {
                tmp = Instantiate(objectToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }

        public GameObject GetObjectFromPool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                if(!pooledObjects[i].activeInHierarchy)                {
                    return pooledObjects[i];
                }
            }
            return null;
        }
    }
}