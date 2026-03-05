using UnityEngine;
public class FabricaPedra : Fabrica
{
    public Pedra pedraPrefab;

    protected override Item CriarInstancia()
    {
        return Instantiate(pedraPrefab);
    }
}