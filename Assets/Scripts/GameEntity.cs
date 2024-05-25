using UnityEngine;

public abstract class GameEntity : MonoBehaviour, IMovable
{
    public abstract void Move();
}
