using UnityEngine;

public class FabricaPocao : Fabrica
{
    public Pocao pocaoPrefab;

    protected override Item CriarInstancia()
    {
        return Instantiate(pocaoPrefab);
    }
}
