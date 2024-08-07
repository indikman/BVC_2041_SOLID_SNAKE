using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandle : MonoBehaviour
{
    private Dictionary<GameObject, int> PlayerItems = new Dictionary<GameObject, int>();
    [SerializeField]private Transform _transform;
    
    
    
    /*public void ItemChange(GameObject _gameObject)
    {
        bool exists = PlayerItems.TryAdd(_gameObject, 1);// use the dictionary to check if gameobject already exists
        if (exists) // does only once per item
        {
            Debug.Log("Instantiate");
            Instantiate(_gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, _transform);
            

        }
        else
        {
            Debug.Log("PlayerItemExists");
            return;
        }

    }*/
}

