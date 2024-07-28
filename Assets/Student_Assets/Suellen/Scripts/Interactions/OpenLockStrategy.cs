using UnityEngine;

public class OpenLockStrategy : IStrategy
{
    private Interaction _interaction;

    public OpenLockStrategy(Interaction interaction)
    {
        _interaction = interaction;
    }

    public void Execute()
    {
        _interaction.rotateDoor?.OpenCloseDoor();
        Debug.Log("OpenLockStrategy in use");
    }
}
