﻿namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Posicao = null;
            Tabuleiro = tabuleiro;
            Cor = cor;
            QtdMovimentos = 0;
        }
        public bool ExisteMovimentoPossivel()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (mat[i, j] == true)
                        return true;
                }
            }
            return false;
        }
        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis();

        public void IncrementarQtdDeMovimentos()
        {
            QtdMovimentos++;
        }
        public void DecrementarQtdMovimentos()
        {
            QtdMovimentos--;
        }
    }
}
