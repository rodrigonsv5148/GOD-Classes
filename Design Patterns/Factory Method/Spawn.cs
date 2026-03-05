using UnityEngine;


public class Spawn : MonoBehaviour
{
    public Fabrica fabrica;

    [ContextMenu("Ativa a Fabrica")]
    public void SpawnItem()
    {
        fabrica.SpawnItem();
    }
}
