using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    string ItemName { get; }
    void Interact();
}
