using System;
using tabuleiro;
using Xadrez_Console;

namespace Xadrez {
    class Program {
        static void Main(string[] args) 
        {
            Tabuleiro tab = new Tabuleiro(8,8);
            Tela.ImprimirTabuleiro(tab);
        }
    }
}