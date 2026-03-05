using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

public class Filas_e_Pilhas : MonoBehaviour
{
    Queue<float> fila = new Queue<float>();
    Stack<int> pilha = new Stack<int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Queue();
    }

    void Queue()
    {
        for (int i = 0; i < 3; i++)
        {
            fila.Enqueue((float)i + 1f + (float)i/10);
        }
        
        foreach(float valor in fila)
        {
            Debug.Log("Exibindo " + (float)valor);         // Cresce do primeiro para o ultimo FIFO
        }
        
        while(fila.Count > 0)
        {
            Debug.Log("Removendo " + fila.Peek());          // Cresce do primeiro para o ultimo 
            if(fila.Count > 1) fila.Dequeue();
            else fila.Clear();
        }
    }
    
    void Stack()
    {
        for (int i = 0; i < 4; i++)
        {
            pilha.Push((int)(i + Math.Pow(i, ( i + i ))));
        }

        foreach(int value in pilha)
        {
            Debug.Log("Colocado" + value);                  // Cresce do ultimo para o primeiro LIFO
        }

        while (pilha.Count > 0)
        {
            Debug.Log("Tirando" + pilha.Peek());
            
            if(pilha.Count > 1) pilha.Pop();                // Cresce do ultimo para o primeiro
            else pilha.Clear();
        }

        Debug.Log("La ele 1000 vezes");
    }
}
