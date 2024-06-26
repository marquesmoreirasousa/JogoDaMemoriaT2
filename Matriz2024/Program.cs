using System;
using System.Runtime.CompilerServices;

namespace Matriz2024
{
    internal class Program
    {
        static void PrintMatrix(int[,] screen) {
            Console.Write("   ");
            for (int i = 1; i <= 4; i++)
            {
                Console.Write(" {0}  ", i);
            }
            Console.WriteLine("\n  -----------------");
            //Impressão
            for (int j = 0; j < 4; j++)
            {
                Console.Write("{0} |", j + 1);
                for (int k = 0; k < 4; k++)
                {
                    Console.Write(" {0} |", screen[j, k]);
                }
                Console.WriteLine("\n  -----------------");

            }
            Console.WriteLine();
        }
        static void Main(String[] Args)
        {
            int[,] tela = new int[4, 4];
            int[,] jogo = new int[4, 4];
            int acertos = 0;
            Player p1;
            Player p2;

            Console.WriteLine("Entre com o nome do P1:");
            string nameP1 = Console.ReadLine();
            Console.WriteLine("Entre com o nome do P2:");
            string nameP2 = Console.ReadLine();

            p1 = new Player(nameP1);
            p2 = new Player(nameP2);

            


            Random gerador = new Random();
            
            int lin, col;
            //Vamos gerar os pares de números e adicionar
            //na matriz jogo
            for (int i = 1; i <= 8; i++)
            {
                for (int n = 0; n < 2; n++)
                {
                    do
                    {
                        lin = gerador.Next(0, 4);
                        col = gerador.Next(0, 4);
                    } while (jogo[lin, col] != 0);

                    jogo[lin, col] = i;
                }
            }
            //Sortear jogador que começa
            int jogador = gerador.Next(1, 3);
            Program.PrintMatrix(jogo);
            Console.WriteLine();
            do
            {
                //Imprimir o nome do jogador da vez.
                //if(jogador == 1)
                //    Console.WriteLine(p1.Name);
                //else
                //    Console.WriteLine(p2.Name);

                Console.WriteLine("{0} É A SUA VEZ!",
                    jogador == 1? p1.Name: p2.Name);

                //Começa a contar o tempo.
                DateTime begin = DateTime.Now;

                //Imprimir conteúdo da matriz tela
                Program.PrintMatrix(tela);

                int lin1, col1;
                do
                {
                    do
                    {
                        Console.WriteLine("Entre com a linha [1, 4]");
                        lin1 = int.Parse(Console.ReadLine());
                    } while (lin1 <= 0 || lin1 >= 5);

                    do
                    {
                        Console.WriteLine("Entre com a coluna [1, 4]");
                        col1 = int.Parse(Console.ReadLine());
                    } while (col1 <= 0 || col1 >= 5);

                    lin1--; //diminuir, pois o usuário não sabe
                    col1--; //que existe linha e coluna zero
                            //Atribuir o valor da matriz jogo na tela
                    if (tela[lin1, col1] != 0)
                        Console.WriteLine("ERRO: VOCÊ JÁ ESCOLHEU ESTA POSIÇÃO!");
                } while (tela[lin1, col1] != 0);


                tela[lin1, col1] = jogo[lin1, col1];

                Console.Write("   ");
                for (int i = 1; i <= 4; i++)
                {
                    Console.Write(" {0}  ", i);
                }
                Console.WriteLine("\n  -----------------");
                //Impressão
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("{0} |", j + 1);
                    for (int k = 0; k < 4; k++)
                    {
                        Console.Write(" {0} |", tela[j, k]);
                    }
                    Console.WriteLine("\n  -----------------");

                }
                Console.WriteLine();

                int lin2, col2;
                do
                {
                    do
                    {
                        Console.WriteLine("Entre com a linha [1, 4]");
                        lin2 = int.Parse(Console.ReadLine());
                    } while (lin2 <= 0 || lin2 >= 5);
                    do
                    {
                        Console.WriteLine("Entre com a coluna [1, 4]");
                        col2 = int.Parse(Console.ReadLine());
                    } while (col2 <= 0 || col2 >= 5);

                    lin2--; //diminuir, pois o usuário não sabe
                    col2--; //que existe linha e coluna zero
                            //Atribuir o valor da matriz jogo na tela
                    if (tela[lin2, col2] != 0)
                        Console.WriteLine("ERRO: VOCÊ JÁ ESCOLHEU ESTA POSIÇÃO!");
                } while (tela[lin2, col2] != 0);

                tela[lin2, col2] = jogo[lin2, col2];

                Console.Write("   ");
                for (int i = 1; i <= 4; i++)
                {
                    Console.Write(" {0}  ", i);
                }
                Console.WriteLine("\n  -----------------");
                //Impressão
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("{0} |", j + 1);
                    for (int k = 0; k < 4; k++)
                    {
                        Console.Write(" {0} |", tela[j, k]);
                    }
                    Console.WriteLine("\n  -----------------");

                }
                Console.WriteLine();

                if (tela[lin1, col1] == tela[lin2, col2])
                {
                    if (jogador == 1)
                        p1.Score = 1;
                    else
                        p2.Score = 1;

                    acertos++;
                }
                else //Caso não tenha acertado o par
                {
                    TimeSpan timeSpan = DateTime.Now - begin;

                    //Soma do tempo de partida.
                    if(jogador == 1)
                        p1.GameTime = timeSpan;
                    else
                        p2.GameTime = timeSpan;

                    //Inversão dos jogadores
                    jogador = jogador % 2 + 1;

                    tela[lin1, col1] = 0;
                    tela[lin2, col2] = 0;
                }
                //Console.WriteLine("Digite 0 para sair ou outro número para continuar:");
                //int valor = int.Parse(Console.ReadLine());

                //if (valor == 0)
                //    break;

                Console.WriteLine(p1.ToString());
                Console.WriteLine(p2.ToString());
            } while (acertos < 8);

            


            //Console.WriteLine($"Tempo total de jogo: {timeSpan.ToString(@"hh\:mm\:ss")}");

        }
    }
}















////Declaração da matriz para armazenar a tabuada
//int[,] tab = new int[11, 11];

////Atribui valores às posições
//for (int i = 0; i < 11; i++) //Índices das linhas
//{
//    for (int j = 0; j < 11; j++) //Índices das colunas 
//    {
//        tab[i, j] = i * j; //Calcula a multiplicação e salva
//    }
//}

//for (int i = 0; i < 11; i++) //Índices das linhas
//{
//    for (int j = 0; j < 11; j++) //Índices das colunas
//    {
//        Console.WriteLine("{0} * {1} = {2} ", i, j, tab[i, j]);
//    }
//    Console.WriteLine();
//}


//int[,] jogo = new int[4, 4];
//int[,] tela = new int[4, 4];

////Para criar números aleatórios
//Random gerador = new Random();

//for (int i = 1; i <= 8; i++) //Atribui os pares de números às posições
//{
//    //Escolhe a posição do primeiro número do par
//    int lin, col;
//    do
//    {
//        lin = gerador.Next(0, 4);
//        col = gerador.Next(0, 4);

//    } while (jogo[lin, col] != 0);
//    jogo[lin, col] = i;

//    //Escolhe a posição do primeiro número do par
//    do
//    {
//        lin = gerador.Next(0, 4);
//        col = gerador.Next(0, 4);

//    } while (jogo[lin, col] != 0);
//    jogo[lin, col] = i;
//}

//int acertos = 0;
//do
//{
//    for (int i = 0; i < 4; i++)
//    {
//        for (int j = 0; j < 4; j++)
//        {
//            Console.Write("{0} ", tela[i, j]);
//        }
//        Console.WriteLine();
//    }
//    Console.WriteLine();

//    //Pedir as posições do primeiro número
//    Console.WriteLine("Escolha uma linha para jogar [1, 4]: ");
//    int lin1 = int.Parse(Console.ReadLine());

//    Console.WriteLine("Escolha uma coluna para jogar [1, 4]: ");
//    int col1 = int.Parse(Console.ReadLine());

//    lin1--;
//    col1--;

//    tela[lin1, col1] = jogo[lin1, col1];

//    for (int i = 0; i < 4; i++)
//    {
//        for (int j = 0; j < 4; j++)
//        {
//            Console.Write("{0} ", tela[i, j]);
//        }
//        Console.WriteLine();
//    }
//    Console.WriteLine();

//    //Pedir as posições do segundo número
//    Console.WriteLine("Escolha uma linha para jogar [1, 4]: ");
//    int lin2 = int.Parse(Console.ReadLine());

//    Console.WriteLine("Escolha uma coluna para jogar [1, 4]: ");
//    int col2 = int.Parse(Console.ReadLine());

//    lin2--;
//    col2--;

//    tela[lin2, col2] = jogo[lin2, col2];

//    for (int i = 0; i < 4; i++)
//    {
//        for (int j = 0; j < 4; j++)
//        {
//            Console.Write("{0} ", tela[i, j]);
//        }
//        Console.WriteLine();
//    }
//    Console.WriteLine();

//    //Em caso de acerto, a matriz tela permanece como está.
//    //Em caso de erro, precisamos voltar as posições para zero.
//    if (jogo[lin1, col1] != jogo[lin2, col2])
//    {
//        tela[lin1, col1] = 0;
//        tela[lin2, col2] = 0;
//    }
//    else
//    {
//        acertos++;
//    }

//} while (acertos < 8);