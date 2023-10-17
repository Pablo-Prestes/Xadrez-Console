using tabuleiro;
namespace Xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        { }
        public override string ToString()
        {
            return "R";
        }
        private bool PodeMover(Posicao pos) 
        {
            Peca p = Tabuleiro.peca(pos);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis() 
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

             Posicao pos = new Posicao(0, 0);

            //Peça acima do rei
            pos.DefinirValores(pos.Linha -1, pos.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Peça NE do rei
            pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Peça a direita do rei
            pos.DefinirValores(pos.Linha, pos.Coluna +1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Peça a SE do rei
            pos.DefinirValores(pos.Linha +1, pos.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Peça abaixo do rei
            pos.DefinirValores(pos.Linha + 1, pos.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Peça a SO do rei
            pos.DefinirValores(pos.Linha + 1, pos.Coluna -1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Peça a esquerda do rei
            pos.DefinirValores(pos.Linha, pos.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Peça a NO do rei
            pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            return mat; 
        }
    }
}
    