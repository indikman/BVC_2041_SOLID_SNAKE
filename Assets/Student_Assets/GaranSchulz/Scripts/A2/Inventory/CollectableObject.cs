using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectableObject : MonoBehaviour
{
    public event Action<ObjectSO> ObjectPickedUp;
    public void PickupEvent() => ObjectPickedUp?.Invoke(_objectData);
    
    [SerializeField] private ObjectSO _objectData;
    private bool _isPickedUp = false;
    private MeshFilter _mesh;
    private MeshRenderer _meshRenderer;
    
    private void Awake()
    {
        _mesh = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _mesh.mesh = _objectData.WorldModel; //set mesh to be model specified in SO
        _meshRenderer.material = _objectData.ModelMaterial; //set material to be material specified in SO
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isPickedUp) //prevents entering triggering multiple times - likely unnecessary but better safe than sorry
            return;
        if (!other.CompareTag("Player")) //if you're not the player, irrelevant
            return;
        _isPickedUp = true;
        PickupEvent(); //trigger event so listeners can respond
        //Debug.Log("?");
        Destroy(this.gameObject);
    }
}
