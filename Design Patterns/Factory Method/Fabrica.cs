using UnityEngine;

public abstract class Fabrica : MonoBehaviour
{
    public Item SpawnItem()
    {
        return CriarInstancia();
    }

    protected abstract Item CriarInstancia();
}