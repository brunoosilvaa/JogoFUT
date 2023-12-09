using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetojogoFut
{
    public class Textos
    {
        public const string Tela = "| {0,-100} {1,3} |";
        public string linha = new string('.', 120);
        public const string BordadeCima = "  ";
        public const string BordadeBaixo = "  ";
        public string[] textodoGame = new string[]
        {
            "'~~~~ Bem Vindo Ao Jogo  De FUTEBOL ~~~~'",
           "GOOL! GOOL! GOOL! GOOL! GOOL! Do ",
           "Saldo de gols é de ",
           "Bela defesa do Goleiro !!", "tente novamente";
           "Parabens! ",
           " É o(a) ganhador(a)!",
           "Infelizmente o jogador ",
           " não ganhou dessa vez!",
           "Apesar do empate, parabens aos jogadores! ",
           "Penalidade MAXIMA!",
           " É uma boa chance de tentar marcar um gol",
           " Rodada da vez : Jogador ",
           "Pontuação: ",
           "                Jogador  {0,-23}  ",
            "Energia restante: ",
           " Pontuação: {0,-37} ",
           " Gols marcados: {0,-34}",
           " Energia restante: {0,-30} "

        };

        public void LinhaTraçada()
        {
            Console.WriteLine(linha.PadLeft(Console.WindowWidth / 2 + linha.Length / 2));
        }
        public void LinhaTraçada2()
        {
            string linha = new string('_', 120);
            Console.WriteLine(linha.PadLeft(Console.WindowWidth / 2 + linha.Length / 2));
        }
    }
}
