using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetojogoFut
{
    public class Cartas
    {
        public List<string> Carta = new List<string> { "Gol", "Pênalti", "Energia", "Falta", "Cartão Amarelo", "Cartão Vermelho"};
        public List<int> PontosCarta = new List<int> { 3, 2, 2, 1, 1, 0 };
        public List<string> CartaRodada = new List<string>();
        public List<int> PontuacaoDaRodada = new List<int>();

        public int CartaJogada { get; set; }
        public int PontuacaoCarta { get; set; }
        public bool Amarela { get; set; }
        public bool Vermelho { get; set; }
        public bool Energia { get; set; }
        public bool Penalti { get; set; }
        public bool Gol { get; set; }
        public bool Rep { get; set; }
        public const string BordaUP = "          ";
        public const string BordaDown = "          ";

        Random random = new Random();

        public void Borda1()
        {
            Console.WriteLine("          ");
            Console.WriteLine("");
        }

        public void Borda2()
        {
            Console.WriteLine("          ");
            Console.WriteLine("");
        }

        public void SorteioCartas()
        {
            CartaRodada.Clear();
            PontuacaoDaRodada.Clear();
            PontuacaoCarta = 0;


            for (int i = 0; i < 3; i++)
            {
                string textCarta = "";
                if (i < 2)
                {
                    textCarta = " {0,-21} Pontos: {1,3}   Aguarde ,carregando a proxima carta...";
                }
                else
                {
                    textCarta = " {0,-21} Pontos: {1,3}    Todas as Cartas  já foram Sorteadas!";
                }


                CartaJogada = random.Next(6);
                CartaRodada.Add(Carta[CartaJogada]);
                PontuacaoDaRodada.Add(PontosCarta[CartaJogada]);
                PontuacaoCarta += PontosCarta[CartaJogada];
                string CartaMoment = Carta[CartaJogada];


                string Pontos = $"{PontosCarta[CartaJogada]}";
                string linhaCarta = string.Format(textCarta, CartaMoment, Pontos).PadRight(BordaUP.Length - 2);

                Console.WriteLine(BordaUP);
                Console.WriteLine(linhaCarta);
                Console.WriteLine(BordaDown);
            }


            if (CartaRodada[0] == CartaRodada[1] && CartaRodada[1] == CartaRodada[2])
            {
                Rep = true;

            }
            else
            {
                Borda1();

                Console.WriteLine($" Score da Rodada: {PontuacaoCarta.ToString().PadRight(13)} ");

                Borda2();
            }
        }

        public void CartaoAmarelo()
        {
            if (Rep == true && CartaJogada == 4)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;

                Borda1();
                Console.WriteLine("Cartão Amarelo!");
                Borda2();

                this.Amarela = true;
                Rep = false;
                Console.ResetColor();
            }
        }
        public void CartaoVermelho()
        {
            if (Rep == true && CartaJogada == 5)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Borda1();
                Console.WriteLine("Cartão Vermelho!");
                Console.WriteLine(" O jogador Perdeu 2 energias!");
                Borda2();
                this.Vermelho = true;
                Rep = false;
                Console.ResetColor();
            }
        }
        public void CartaoEnergia()
        {
            if (Rep == true && CartaJogada == 2)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Borda1();
                Console.WriteLine(" ganho  de Energia ");
                Borda2();

                this.Energia = true;
                Rep = false;

                Console.ResetColor();
            }
        }
        public void CartaoPenalti()
        {
            if (Rep == true && CartaJogada == 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Borda1();
                Console.WriteLine("Penalti");
                Borda2(); ;

                this.Penalti = true;
                Rep = false;
                Console.ResetColor();
            }
        }
        public void CartaoGol()
        {
            if (Rep == true && CartaJogada == 0)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Borda1();
                Console.WriteLine("Gol");
                Borda2();
                this.Gol = true;
                Rep = false;
                Console.ResetColor();
            }
        }

        public void CartaoFalta()
        {
            if (Rep == true && CartaJogada == 3)
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.White;
                Borda1();
                Console.WriteLine("Falta!! Perdeu uma rodada");
                Rep = false;
                Borda2();

                Console.ResetColor();
            }
        }

    }
}

