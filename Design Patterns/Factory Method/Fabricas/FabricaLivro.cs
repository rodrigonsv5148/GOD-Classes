using Unity.VisualScripting;
using UnityEngine;

public class FabricaLivro : Fabrica
{
    public Livro livroPrefab;

    protected override Item CriarInstancia()
    {
        return Instantiate(livroPrefab);
    }
}
