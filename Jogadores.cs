using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ProjetojogoFut
{
    public class Jogadores : Textos
    {

        Cartas Carta = new Cartas();

        public string Nome { get; set; }
        public int NumJogador { get; set; }
        public int Energia { get; set; }

        Random random = new Random();

        public int Gol { get; set; }
        public int Chute { get; set; }
        public int Defesa { get; set; }
        public int QntAmarelo { get; set; }
        public int Pontos { get; set; }
        public int JogadorPC { get; set; }
        public int CartaoAmarelo { get; set; }
        public bool PC { get; set; }
        public bool Fim { get; set; }
        public bool PenaltiChute { get; set; }
        public bool PenaltiDefesa { get; set; }

        public void Reset()
        {
            Nome = "";
            NumJogador = 0;
            Energia = 10;
            Gol = 0;
            Chute = 0;
            Defesa = 0;
            QntAmarelo = 0;
            Pontos = 0;
            JogadorPC = 0;
            CartaoAmarelo = 0;
            PC = false;
            Fim = false;
            PenaltiChute = false;
            PenaltiDefesa = false;

        }

        public void Topo()
        {

            Console.Clear();
            string TextoCentro = textodoGame[11] + Nome;

            int tamanhoDisponivel = BordadeCima.Length - 2;

            int tamanhoTextoCentro = TextoCentro.Length;

            int EmBranco = (tamanhoDisponivel - tamanhoTextoCentro) / 2;

            string textoX = " ";
            string textoZ = " ";

            string textoFinal = textoX + TextoCentro.PadLeft(EmBranco + tamanhoTextoCentro).PadRight(tamanhoDisponivel) + textoZ;
            
            Console.WriteLine(BordadeCima.PadLeft(Console.WindowWidth / 2 + BordadeCima.Length / 2));
            Console.WriteLine(textoFinal.PadLeft(Console.WindowWidth / 2 + textoFinal.Length / 2));
            Console.WriteLine(BordadeBaixo.PadLeft(Console.WindowWidth / 2 + BordadeBaixo.Length / 2));

        }

        public void Inicio()
        {
            Console.WriteLine(BordadeCima.PadLeft(Console.WindowWidth / 2 + BordadeCima.Length / 2));
            Console.WriteLine(textodoGame[0].PadLeft(Console.WindowWidth / 2 + textodoGame[0].Length / 2));
            Console.WriteLine(BordadeBaixo.PadLeft(Console.WindowWidth / 2 + BordadeBaixo.Length / 2));
            Console.WriteLine("Deseja jogar:\n [ 1 ] - Player x Player\n [ 2 ] - Player x Computador");

            JogadorPC = int.Parse(Console.ReadLine());
            Console.Clear();
        }

        public void NumeroJogador()
        {
            Console.WriteLine(BordadeCima.PadLeft(Console.WindowWidth / 2 + BordadeCima.Length / 2));
            string linha = ("Jogador " + NumJogador);
            Console.WriteLine(linha.PadLeft(Console.WindowWidth / 2 + linha.Length / 2));
            Console.WriteLine(BordadeBaixo.PadLeft(Console.WindowWidth / 2 + BordadeBaixo.Length / 2));
        }
        public void NomeJogador()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                Energia = 10;
                Fim = false;
                if (PC == true)
                {
                    this.Nome = "NETO";
                }
                else
                {
                    Console.WriteLine("Digite o nome do jogador: ");
                    this.Nome = Console.ReadLine().ToUpper();
                    Console.Clear();
                }
            }
        }
        public void Pontuacao()
        {
            Console.WriteLine(BordadeCima.PadLeft(Console.WindowWidth / 2 + BordadeCima.Length / 2));
            if (this.Energia <= 0)
            {
                string text4 = (string.Format(textodoGame[13], Nome));
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine(text4.PadLeft(Console.WindowWidth / 2 + text4.Length / 2));
                Console.ResetColor();
            }
            
            string text1 = (string.Format(textodoGame[15], Pontos));
            string text2 = (string.Format(textodoGame[16], Gol));
            string text3 = (string.Format(textodoGame[17], Energia));
            Console.WriteLine(text1.PadLeft(Console.WindowWidth / 2 + text1.Length / 2));
            Console.WriteLine(text2.PadLeft(Console.WindowWidth / 2 + text2.Length / 2));
            Console.WriteLine(text3.PadLeft(Console.WindowWidth / 2 + text3.Length / 2));




            Console.WriteLine(BordadeBaixo.PadLeft(Console.WindowWidth / 2 + BordadeBaixo.Length / 2));
            Console.WriteLine("");

        }

        public void GolMarcado()
        {
            this.Gol++;
            Console.WriteLine(BordadeCima.PadLeft(Console.WindowWidth / 2 + BordadeCima.Length / 2));
            Console.WriteLine(textodoGame[1].PadLeft(Console.WindowWidth / 2 + textodoGame[1].Length / 2) + this.Nome); 
            Console.WriteLine(textodoGame[2].PadLeft(Console.WindowWidth / 2 + textodoGame[2].Length / 2) + this.Gol);
            Console.WriteLine(BordadeBaixo.PadLeft(Console.WindowWidth / 2 + BordadeBaixo.Length / 2));
            Console.WriteLine("");
            Console.ReadKey();
        }

        public void DefesaGoleiro()
        {
            Console.WriteLine("");
            Console.WriteLine(textodoGame[3].PadLeft(Console.WindowWidth / 2 + textodoGame[3].Length / 2)); 

            Console.WriteLine("");
            Console.ReadKey();

        }

        public void Ganhador()
        {
            Console.Clear();
            Console.WriteLine(textodoGame[4].PadLeft(Console.WindowWidth / 2 + textodoGame[4].Length / 2) + Nome);
            Console.WriteLine(textodoGame[5].PadLeft(Console.WindowWidth / 2 + textodoGame[5].Length / 2));
            Pontuacao();
        }
        public void Perdedor()
        {

            Console.WriteLine(textodoGame[6].PadLeft(Console.WindowWidth / 2 + textodoGame[6].Length / 2) + Nome);
            Console.WriteLine(textodoGame[7].PadLeft(Console.WindowWidth / 2 + textodoGame[7].Length / 2));
            Pontuacao();
        }
        public void Empate()
        {

            Console.WriteLine(textodoGame[8].PadLeft(Console.WindowWidth / 2 + textodoGame[8].Length / 2));
        }
        public void encerrandoRodada()
        {
            Energia--;
            if (Energia <= 0)
            {
                Console.WriteLine("");
                Fim = true;
            }
        }
        public void PenalidadeChute()
        {
            Console.WriteLine("");

            Console.WriteLine(textodoGame[9].PadLeft(Console.WindowWidth / 2 + textodoGame[9].Length / 2));
            Console.WriteLine(textodoGame[10].PadLeft(Console.WindowWidth / 2 + textodoGame[10].Length / 2));

            Console.WriteLine("");

            Console.WriteLine(Nome + ", o jogador da vez, deve tentar o chute.");
            if (PC == true) { Chute = random.Next(1, 4); Console.WriteLine("O chute foi {0}", Chute); }
            else
            {
                Console.WriteLine("Digite: [1] - Chute na Esquerda | | [2] Chute no Centro | | [3] Chute a direita");
                Chute = int.Parse(Console.ReadLine());
            }

        }
        public void PenalidadeDefesa()
        {
            Console.WriteLine("");

            Console.WriteLine(textodoGame[9].PadLeft(Console.WindowWidth / 2 + textodoGame[9].Length / 2)); 

            Console.WriteLine("Agora a vez da defesa, o Goleiro do jogador {0} deverá tentar defender o chute.", Nome);
            if (PC == true) { Defesa = random.Next(1, 4); Console.WriteLine("A Defesa foi {0}", Defesa); }
            else
            {
                Console.WriteLine("Digite: [1] - Defesa na Esquerda | | [2] - Defesa no Centro | | [3] - Defesa a direita");
                Defesa = int.Parse(Console.ReadLine());
            }
        }
        public void JogoRodando()
        {
            Console.Clear();
            Topo();
            Console.ResetColor();
            Console.WriteLine();

            Carta.SorteioCartas();
            if (Carta.Rep == false)
            {
                this.Pontos += Carta.PontuacaoCarta;
            }
            Console.ResetColor();

            Carta.CartaoGol();
            if (Carta.Gol == true)
            {
                GolMarcado();
                Carta.Gol = false;
            }
            Carta.CartaoPenalti();
            if (Carta.Penalti == true)
            {
                PenaltiChute = true;
                Carta.Penalti = false;
            }
            if (PenaltiChute == true) { PenalidadeChute(); }

            Carta.CartaoEnergia();
            if (Carta.Energia == true)
            {
                Energia++;
                Carta.Energia = false;
            }

            Carta.CartaoAmarelo();
            if (Carta.Amarela == true)
            {
                QntAmarelo++;
                if (QntAmarelo > 1) { Energia = Energia - 2; }
                else { encerrandoRodada(); }
                Carta.Amarela = false;
            }

            Carta.CartaoVermelho();
            if (Carta.Vermelho == true)
            {
                Energia = Energia - 2;
                Carta.Vermelho = false;
            }
            Carta.CartaoFalta();
            Console.WriteLine("");
        }


    }
}

