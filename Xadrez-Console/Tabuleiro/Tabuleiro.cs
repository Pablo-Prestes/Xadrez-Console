namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)//Construtores 
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[Linhas, Colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public Peca peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }
        public void ColocarPeca(Peca p, Posicao pos)//lança o erro(se houver) e coloca peça no tabuleiro
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça no local");
            
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }
        public Peca RetirarPeca(Posicao pos)  
        {
            if (peca(pos) == null)
            {
                return null;
            }
            else 
            {
                Peca aux = peca(pos);
                aux.Posicao = null;
                pecas[pos.Linha, pos.Coluna] = null;
                return aux;
            }
        }

        public bool ExistePeca(Posicao pos)//Verifica se tem uma peça no local
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }
        public bool PosicaoValida(Posicao pos)//Verfica se é uma posição válida no tabuleiro 8x8
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }
        public void ValidarPosicao(Posicao pos)//Lança o erro e válida a posição com a função e dá o retorno se a posição for inválida
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }
    }
}
