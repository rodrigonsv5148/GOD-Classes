using UnityEngine;


[HelpURL("https://www.youtube.com/watch?v=dKIlmntyjQU&t=593s")] // Muda o HELP padrão da classe

[RequireComponent(typeof(Rigidbody))]                       // Obriga o componente a existir no GameObject

[SelectionBase]                                             /* Faz com que ao selecionar um objeto filho, a unity
                                                             selecione o objeto que tem esse script (não quer
                                                             selecionar uma folha ao tentar selecionar uma arvore)*/

[AddComponentMenu("Meus Componentes/GodClassInspector")]    // Cria seu próprio componente unity (achei meio inutil)

[ExecuteInEditMode]                                         //Execute as funções padrões (start, awake...) in EDIT mode
public class GodClassInspector : MonoBehaviour
{
     

    [Header ("Titulo")]                                     // Título
    public string titulo;
    [Space(20)]                                             // Da um espacinho entre as opções
    [Min(0)] public int minZero;                            // Seta um valor mínimo 
    [Range(0,100)] [SerializeField] private int zeroCem;    // Seta um range de valores
    [HideInInspector] public string escondida;              // Esconde do inspector (útil para variáveis públicas)

    [Tooltip("Aqui temos os quatro elementos")]             // Descrição na próxima var
    public elementos quatroElementos;                       // Usando enums

    [TextArea]                                              // Paragraph de string
    public string grandeTexto;
    
    [ContextMenu("setar valor aleatorio em 2")]             // Usa a função ao clicar na classe (Right Mouse)
    void setarEmDois()
    {
        valorAleatorio = 2;
    }

    [ContextMenuItem("Clique no nome da variavel", "Aleatorio")]    // Usa função ao clicar na var (Right Mouse)
    public float valorAleatorio;

    public void Aleatorio()
    {
        valorAleatorio = Random.Range (0, 100);
    }
    
    
}

public enum elementos
{
    agua,
    fogo,
    terra,
    ar
}
