using UnityEngine;

public class FabricaTomo : Fabrica
{
    public Tomo tomoPrefab;

    protected override Item CriarInstancia()
    {
        return Instantiate(tomoPrefab);
    }
}
