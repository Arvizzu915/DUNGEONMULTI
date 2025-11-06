using UnityEngine;

public abstract class IInteractuable : ScriptableObject
{
    public abstract void Interactuar();

    public virtual void Hover()
    {
        
    }
}
