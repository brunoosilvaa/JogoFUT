namespace ProjetojogoFut;

class comandos
{
    static void Main(string[] args)
    {


        int FimJogo = 0;

        Random random = new Random();
        while (FimJogo == 0)
        {
            bool sair = false, rodada = false, fim = true;
            int d = 0, d1 = 0;

            Random aleatorio = new Random();



            List<Jogadores> Player1 = new List<Jogadores>();
            List<Jogadores> Player2 = new List<Jogadores>();
            Jogadores p = new Jogadores();
            Jogadores p2 = new Jogadores();
            Cartas c = new Cartas();


            p.Reset();
            p2.Reset();
            Console.Clear();
            p.Inicio();
            if (p.JogadorPC == 2)
            { p2.PC = true; }

            string linha1 = " Player 1 ";
            string linha2 = " Player 2 ";

            p.NumJogador = 1;
            p.NumeroJogador();
            p.NomeJogador();
            p2.NumJogador = 2;
            p2.NumeroJogador();
            p2.NomeJogador();

            Console.Clear();
            rodada = random.Next(1, 3) == 1 ? true : false;

            while (sair == false)
            {

                if (rodada == false)
                {
                    if (p.PenaltiDefesa == true && p2.PenaltiChute == true)
                    {
                        if (p.PenaltiDefesa == true) { p.PenalidadeDefesa(); }
                        if (p.Defesa == p2.Chute) { p.DefesaGoleiro(); }
                        else { p2.GolMarcado(); }
                        p2.Topo();
                        p2.Pontuacao();
                        Console.ReadKey();
                        p.PenaltiDefesa = false;
                        p2.PenaltiChute = false;
                    }
                    if (p.Fim == false)
                    {
                        p.JogoRodando();
                        if (p.PenaltiChute == true)
                        {
                            p2.PenaltiDefesa = true;
                        }

                        p.Pontos += c.PontuacaoCarta;
                        Player1.Add(p);
                        if (p.PenaltiChute != true) { p.Pontuacao(); }
                        Console.ReadKey();
                        Console.Clear();
                        p.encerrandoRodada();
                        d++;
                        rodada = true;
                    }
                    else
                    {
                        Console.WriteLine("Jogador {0} está sem energia! ", p.Nome);
                        fim = true;
                        rodada = true;
                    }

                }

                if (rodada == true)
                {
                    if (p2.Fim == false)
                    {
                        if (p2.PenaltiDefesa == true) { p2.PenalidadeDefesa(); }
                        if (p2.PenaltiDefesa == true && p.PenaltiChute == true)
                        {
                            if (p2.Defesa == p.Chute) { p2.DefesaGoleiro(); }
                            else { p.GolMarcado(); }
                            p.Topo();
                            p.Pontuacao();
                            Console.ReadKey();
                            p2.PenaltiDefesa = false;
                            p.PenaltiChute = false;
                        }
                        p2.JogoRodando();
                        if (p2.PenaltiChute == true)
                        {
                            p.PenaltiDefesa = true;
                        }

                        p2.Pontos += c.PontuacaoCarta;
                        Player2.Add(p2);
                        if (p2.PenaltiChute != true) { p2.Pontuacao(); }
                        Console.ReadKey();
                        Console.Clear();
                        p2.encerrandoRodada();
                        d1++;
                        rodada = false;
                    }
                    else
                    {
                        Console.WriteLine("Jogador {0} está sem energia! ", p2.Nome);
                        fim = true;
                        rodada = false;
                    }
                }


                if (p2.Fim == true && p.Fim == true) { fim = false; sair = true; }


            }

            if (p.Gol > p2.Gol) { p.Ganhador(); p2.Perdedor(); }
            else if (p2.Gol > p.Gol) { p2.Ganhador(); p.Perdedor(); }
            else if (p.Gol == p2.Gol && p2.Pontos > p.Pontos) { p2.Ganhador(); p.Perdedor(); }
            else if (p.Gol == p2.Gol && p.Pontos > p2.Pontos) { p.Ganhador(); p2.Perdedor(); }
            else { p.Empate(); Console.WriteLine(p.Nome + " e " + p2.Nome); p.Pontuacao(); p2.Pontuacao(); }
            Console.WriteLine("Rodadas {0} e {1}", d, d1);

            Console.WriteLine("");
            Console.WriteLine("Deseja Continuar? \n [ 0 ] - Sim; \n [ 1 ] - Não;");
            FimJogo = int.Parse(Console.ReadLine());
        }



    }
}