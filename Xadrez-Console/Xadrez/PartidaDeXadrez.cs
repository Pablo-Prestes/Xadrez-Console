using tabuleiro;
namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; set; }
        public int Turno { get; private set;}
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; set; }
                
        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPecas();          
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) 
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQtdDeMovimentos();
            Peca PecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }
        public void RealizaJogada(Posicao origem,Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }
        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if(Tab.peca(pos) == null) 
            {
                throw new TabuleiroException("Não existe peça na origem escolhida!");
            }
            if (JogadorAtual != Tab.peca(pos).Cor)
            {
                throw new TabuleiroException("Peça escholida não é sua !");
            }
            if (!Tab.peca(pos).ExisteMovimentoPossivel())
            {
                throw new TabuleiroException("Não há movimentos possíveis paraa a peça !");
            }
        }
        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.peca(origem).PodeMoverPara(destino)) 
            {
                throw new TabuleiroException("Posição de destino inválida ! (A peça só pode ser movimentada nas linhas mostrada)");
            }
        }
        private void MudaJogador() 
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else 
            {
                JogadorAtual = Cor.Branca;
            }
        }
        private void ColocarPecas() 
        {
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 2).toPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('h', 4).toPosicao());
        }
    }
}
