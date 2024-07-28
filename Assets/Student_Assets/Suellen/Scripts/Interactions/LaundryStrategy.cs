using UnityEngine;

public class LaundryStrategy : IStrategy
{
    private Interaction _interaction;

    public LaundryStrategy(Interaction interaction)
    {
        _interaction = interaction;
    }

    public void Execute()
    {
        Debug.Log("LaundryStrategy in use");
    }
}
