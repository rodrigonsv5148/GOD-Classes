// Classe Deus do SOLID

#region S - Princípio da responsabilidade única

#region ----------------------------------------------- Problema
public class Classedeus
{
    public void Organiza()
    {
        // Organiza algo   
    }

    public void Exibe()
    {
        //Exibe algo na tela
    }

    public void Envia()
    {
        //Envia algo para alguem    
    }

    public void Testa()
    {
        // testa se esse algo funciona        
    }
}

#endregion

#region ----------------------------------------------- Solução
public class Organizacao()
{    
    public void Organiza()
    {
        // Organiza algo   
    }
}

public class Exibicao()
{    
    public void Exibe()
    {
        //Exibe algo na tela
    }
}

public class Teste()
{    
    public void Testa()
    {
        // testa se esse algo funciona        
    }
}

public class Envio()
{    
    public void Envia()
    {
        //Envia algo para alguem    
    }

}
#endregion

#endregion

#region O - Princípio aberto fechado

#region ----------------------------------------------- Problema
public class Report
{
    public bool GerarReport()
    {
        // Report em formato HTML
        return true;
    }    
}
#endregion

#region ----------------------------------------------- Solução
public interface IgenerateReport
{
    public bool GerarReport();
}

public class GenerateHTMLReport : IgenerateReport
{
    public bool GerarReport()
    {
        // Report HTML
        return true;
    }
}

public class GenerateXMLReport : IgenerateReport
{
    public bool GerarReport()
    {
        // Report XML
        return true;
    }
}


#endregion

#endregion

#region L - Princípio da substituição de Liskov
// Se o minha classe personagem ataca e mago herda de personagem, mago ataca (mesmo que de forma diferente) lembre do curso de POO

#region ----------------------------------------------- Problema
class ClasseProblemaLiskov1
{
    protected string atibutoProblema1 {get; set;}
    protected string atibutoProblema2 {get; set;}

    public ClasseProblemaLiskov1(string valor1, string valor2)
    {
        atributoProblema1 = valor1;
        atributoProblema2 = valor2;
    }

    public virtual void ObterDescricao()
    {
        return atributoProblema1 + " " + atibutoProblema2;
    }
}

class ClasseProblemaLiskov2 : ClasseProblemaLiskov1
{
    public ClasseProblemaLiskov1(string valor1) : base (valor1, null)   
    {                                                                       
    }    

    public override string ObterDescricao()
    {
        throw new NotImplementedException("Essa classe não usa atributoProblema2"); 
                                                                        
                                                                        /*  Classe filha não pode substituir a pai. Nesse caso
                                                                            porque o valor da segunda entrada do construtor fica nulo */
    }

}

#endregion

#region ----------------------------------------------- Solução
// -------------------------------------------------------------------- Com essa solução, todas as classes sabem usar a descrição
abstract class ClasseBase
{
    protected string atributoProblema1 { get; set; }

    protected ClasseBase(string valor1)
    {
        atributoProblema1 = valor1;
    }

    public abstract string ObterDescricao();
}

class ClasseComDoisAtributos : ClasseBase
{
    private string atributoProblema2;

    public ClasseComDoisAtributos(string valor1, string valor2)
        : base(valor1)
    {
        atributoProblema2 = valor2;
    }

    public override string ObterDescricao()
    {
        return atributoProblema1 + " - " + atributoProblema2;
    }
}

class ClasseComUmAtributo : ClasseBase
{
    public ClasseComUmAtributo(string valor1)
        : base(valor1)
    {
    }

    public override string ObterDescricao()
    {
        return atributoProblema1;
    }
}


#endregion

#region ----------------------------------------------- Aplicação
#region -------------------------------------------------------------------- Exemplo 1
// Quebrando o principio
class ContaBancaria
{
    public virtual void Sacar(decimal valor)
    {
        // permite saldo negativo até -1000
    }
}

class ContaPoupanca : ContaBancaria
{
    public override void Sacar(decimal valor)
    {
        if (Saldo - valor < 0)
            throw new Exception("Não pode ficar negativo");
    }
}

// Consertando o principio

abstract class Conta
{
    protected decimal Saldo;

    public abstract void Sacar(decimal valor);
}

class ContaBancaria : Conta
{
    public override void Sacar(decimal valor)
    {
        // permite saldo negativo até -1000
    }
}

class ContaPoupanca : Conta
{
    public override void Sacar(decimal valor)
    {
        if (Saldo - valor < 0)
            throw new Exception("Não pode ficar negativo");
    }
}
#endregion
#region -------------------------------------------------------------------- Exemplo 2
// Quebrando o principio
class Retangulo0
{
    public virtual int largura {get; set;}
    public virtual int altura {get; set;}

    public void CalcularArea()
    {
        return altura * largura;
    }
}

class Quadrado0 : Retangulo0
{
    public int lado {get; set;}

    public override int largura
    {
        get {return lado;}
        set {lado = value;}
    }

    public override int altura
    {
        get {return lado;}
        set {lado = value;}
    }
}

class ProgramAreaBase
{
    static void Main(string[] args)
    {
        Retangulo0 retangulo = new Quadrado0();

        retangulo.altura = 5;
        retangulo.largura = 10;                                         /*  Aqui você dá um segundo valor ao quadrado, que conceitualmente
                                                                            não existe*/

        Console.Writeline(retangulo.CalcularArea());        
    }
}

// Consertando o principio
abstract class Forma
{
    public void CalcularArea();
}

class Retangulo1 : Forma
{
    public int largura {get; set;}
    public int altura {get; set;}

    public void CalcularArea()
    {
        return altura * largura;
    }
}

class Quadrado1 : Forma
{
    public int lado {get; set;}

    public void CalcularArea()
    {
        return lado * lado;
    }
}

class ProgramArea
{
    static void Main(string[] args)
    {
        Forma retangulo = new Retangulo1();
        Forma quadrado = new Quadrado1();

        retangulo.altura = 5;
        retangulo.largura = 10;

        quadrado.lado = 4;              

        Console.Writeline(retangulo.CalcularArea());
        Console.Writeline(quadrado.CalcularArea());    
    }
}
#endregion
#endregion

#endregion

#region I - Princípio da segregação de interface

#region ----------------------------------------------- Problema
public interface _InterfaceI
{
    public void metodo1();
    public void metodo2();
}
public class Classe4 : _InterfaceI
{
    public void metodo1()
    {
        //Andando
    }

    public void metodo2()
    {
        // -------------------------------- Metodo sem funcionalidade útil para a classe4
        throw new NotSupportedException("não tem aplicação nessa classe");
    }
}
#endregion

#region ----------------------------------------------- Solução
public interface _InterfaceI_a
{
    public void metodo1();
}
public interface _InterfaceI_b
{
    public void metodo2();
}

public class Classe4_a : _InterfaceI_a
{
    public void metodo1()
    {
        //codigo
    }
}
// -------------------------------- Já que precisou dos dois métodos, foi só herdar das duas classes
public class Classe4_b : _InterfaceI_a, _InterfaceI_b
{
    public void metodo1()
    {
        //codigo
    }

    public void metodo2()
    {
        //codigo
    }
}
#endregion

#region ----------------------------------------------- Aplicação
public interface Ireproduzivel
{
    public void Reproduzir();
}
public interface Igravavel
{
    public void Gravar();
}

public class ReprodutorMultimidia : Ireproduzivel, Igravavel
{
    public void Reproduzir()
    {
        //codigo
    }

    public void Gravar()
    {
        //codigo
    }
}


public class ReprodutorDeAudio : Ireproduzivel
{
    public void Reproduzir()
    {
        //codigo
    }
}


public class GravadorDeAudio : Igravavel
{
    public void Gravar()
    {
        //codigo
    }
}

#endregion

#endregion

#region D - Princípio da inversão de dependencia

#region ---------------------------------------------- Problema
public class _ClasseBaixoNivel_p
{
    public void metodo()
    {
        //Implementação do método
    }
}

public class _ClasseAltoNivel_p
{
    _ClasseAltoNivel_p instancia;                   // Referencia ao objeto

    public MetodoAltoNivel()   
    {
        instancia = new _ClasseAltoNivel_p();

        instancia.metodo();                        // Menor flexibilidade
                                                   // Se quiser colocar outra classe, terei de fazer
                                                   // mais ajustes "if's" e/ou declarar novas variaveis
    }
}
#endregion

#region ---------------------------------------------- Solução
public interface _interface
{
    public void metodo();
}

public class _ClasseBaixoNivel : _interface
{
    public void metodo()
    {
        //Implementação do método
    }
}

public class _ClasseAltoNivel
{
    _interface Iinterface;                          // Referencia a interface e não ao objeto

    public MetodoAltoNivel(_interface _interface)   // Pega o objeto pela interface
    {
        Iinterface = _interface;

        Iinterface.metodo();                        // Usa o método do objeto
    }
}
#endregion

#region ---------------------------------------------- Aplicação
public interface Ilampada
{
    public void Ligar();
    public void Desligar();
    bool Ligada { get; }
}

public class Lampada : Ilampada
{
    private bool ligada = false;
    public bool Ligada => ligada;
    public void Ligar()
    {
        ligada = true;
        Debug.Log("Lampada esta acesa");
    }

    public void Desligar()
    {
        ligada = false;
        Debug.Log("Lampada esta desacesa");
    }

}

class Interruptor
{
    Ilampada lampada;

    public Interruptor(Ilampada _lampada)
    {
        lampada = _lampada;
    }

    public void Acionar ()
    {
        if (lampada != null)
        {
            if (lampada.Ligada)
            {
                lampada.Desligar();
            }else 
                lampada.Ligar();
        }
    }

}

class Program // Teste do interruptor
{
    static void Main (string args[])
    {
        Ilampada lampada = new Lampada();
        Interruptor interruptor = new Interruptor(lampada);
        interruptor.Acionar();
    }
}
#endregion

#endregion