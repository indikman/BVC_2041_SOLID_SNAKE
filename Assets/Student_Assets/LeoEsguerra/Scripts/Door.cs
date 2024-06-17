using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Door : MonoBehaviour
{
    [SerializeField] private bool _isOpen = false;
    [SerializeField] private float _rotationDuration = 1.0f;
    [SerializeField] private Vector3 _closedRotation;
    [SerializeField] private Vector3 _openRotation;

    // Start is called before the first frame update
    void Start()
    {
        if(!_isOpen)
        {
            _closedRotation = transform.localEulerAngles;
        }
        else
        {
            _openRotation = transform.localEulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        if(_isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Open()
    {
        _isOpen = true;
        transform.DOLocalRotate(_openRotation, _rotationDuration);
    }

    public void Close()
    {
        _isOpen = false;
        transform.DOLocalRotate(_closedRotation, _rotationDuration);
    }
}
