using System;
using tabuleiro;

namespace chess_system
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Posicao P;

            P = new Posicao(3, 4);

            //Testar antes de criar o ToString na classe Posicao
            Console.WriteLine("Posição: " + P);
        }
    }
}
