using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "PlayerSO", menuName = "SOs/Player/PlayerSO", order = 0)]
public class PlayerDataSO : ScriptableObject
{
    [field: SerializeField]
    public float Speed { get; private set; }
    [field:SerializeField]
    public float Acceleration { get; private set; }
}
