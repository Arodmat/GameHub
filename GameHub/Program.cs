using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub
{

    class Program
    {

        static void ShowMenu()
        {

            Console.WriteLine("G A M E   H U B");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar usuário");
            Console.WriteLine("2 - Entrar na plataforma");
            Console.WriteLine("0 - Fechar programa");

        }


        static void ShowMenu(string[,] matriz)
        {
            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"[{matriz[0, 0]}] [{matriz[0, 1]}] [{matriz[0, 2]}]");
            Console.WriteLine();
            Console.WriteLine($"[{matriz[1, 0]}] [{matriz[1, 1]}] [{matriz[1, 2]}]");
            Console.WriteLine();
            Console.WriteLine($"[{matriz[2, 0]}] [{matriz[2, 1]}] [{matriz[2, 2]}]");
            Console.WriteLine();

        }

        static void Cabecalho(int X, int O)
        {
            Console.Clear();
            Console.WriteLine("JOGO DA VELHA");
            Console.WriteLine("-----------------");
            Console.WriteLine();
            Console.WriteLine("PLACAR ");
            Console.WriteLine($"Jogador X: {X}");
            Console.WriteLine($"Jogador O: {O}");
            Console.WriteLine();
            Console.WriteLine("-----------------");
        }
        static void Inserir(ref int num, ref string[,] matriz, string auxiliar, ref int line, ref int column)
        {
            switch (num)
            {
                case 1:
                    matriz[0, 0] = auxiliar;
                    line = 0;
                    column = 0;
                    break;

                case 2:
                    matriz[0, 1] = auxiliar;
                    line = 0;
                    column = 1;

                    break;

                case 3:
                    matriz[0, 2] = auxiliar;
                    line = 0;
                    column = 2;
                    break;

                case 4:
                    matriz[1, 0] = auxiliar;
                    line = 1;
                    column = 0;
                    break;

                case 5:
                    matriz[1, 1] = auxiliar;
                    line = 1;
                    column = 1;
                    break;

                case 6:
                    matriz[1, 2] = auxiliar;
                    line = 1;
                    column = 2;
                    break;

                case 7:
                    matriz[2, 0] = auxiliar;
                    line = 2;
                    column = 0;
                    break;

                case 8:
                    matriz[2, 1] = auxiliar;
                    line = 2;
                    column = 1;

                    break;

                case 9:
                    matriz[2, 2] = auxiliar;
                    line = 2;
                    column = 2;
                    break;
            }

        }

        static bool VitoriaLinha(ref string[,] matriz, ref int line)
        {
            if (string.Equals(matriz[line, 0], matriz[line, 1]))
            {
                if (string.Equals(matriz[line, 0], matriz[line, 2]))
                    return true;

                else
                    return false;
            }
            else
                return false;
        }

        static bool VitoriaColuna(ref string[,] matriz, ref int column)
        {
            if (string.Equals(matriz[0, column], matriz[1, column]))
            {
                if (string.Equals(matriz[0, column], matriz[2, column]))
                    return true;

                else
                    return false;
            }
            else
                return false;

        }

        static bool VitoriaDiagonal(ref string[,] matriz)
        {
            if (string.Equals(matriz[1, 1], matriz[0, 2]))
            {
                if (string.Equals(matriz[1, 1], matriz[2, 0]))
                    return true;

                else
                    return false;
            }

            else if (string.Equals(matriz[1, 1], matriz[0, 0]))
            {
                if (string.Equals(matriz[1, 1], matriz[2, 2]))
                    return true;

                else
                    return false;
            }

            else
                return false;

        }








        public class Naval
        {
            public string[,] grade = new string[5, 5];

            public Naval(string[,] grade)
            {
                this.grade = grade;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        grade[i, j] = "-";
                    }

                }

            }

            public void ShowGrade() // Mostra os elementos da matriz
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write($"{grade[i, j]}    ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }

            public void Inserir(string var, int line, int column)
            {
                grade[line - 1, column - 1] = var;
            }

            public bool Verificacao(int line, int column, string var)
            {

                if (grade[line - 1, column - 1] == var)
                    return true;
                else
                    return false;
            }
        }










        static void Main(string[] args)
        {
            int num;
            string password, user;
            List<string> Usuarios = new List<string>();
            List<string> Senhas = new List<string>();


            //VARIAVEIS JOGO DA VELHA
            int opcao, li = 0, col = 0, jogadas = 0, placarX = 0, placarO = 0, cont = 0, FimDeJogo = 1;
            string[,] grade = new string[3, 3];
            string auxiliar;


            //VARIAVEIS BATALHA NAVAL
            string[,] mat = new string[5, 5];
            string[,] mat2 = new string[5, 5];
            string[,] mat3 = new string[5, 5];
            string[,] mat4 = new string[5, 5];
            string nick1, nick2;
            int linha, coluna, aux = 0, fimp1 = 0, fimp2 = 0;
            bool vezp1 = true;




            do
            {
                Console.Clear();
                ShowMenu();
                Console.WriteLine();
                do
                {
                    Console.WriteLine();
                    Console.Write("Digite número: ");
                    num = int.Parse(Console.ReadLine());
                } while (num < 1 || num > 2);


                if (num == 1)
                {
                    Console.Write("Digite nome de usuário: ");
                    Usuarios.Add(Console.ReadLine());
                    Console.Write("Digite sua senha: ");
                    Senhas.Add(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Cadastrado com sucesso!");
                    Console.WriteLine("Voltando ao menu");
                    Console.ReadKey();
                }
                if (num == 2)
                {
                    Console.Write("Usuario: ");
                    user = Console.ReadLine();
                    Console.Write("Senha: ");
                    password = Console.ReadLine();

                    if (!Usuarios.Contains(user)) //vendo se tem usuario na lista
                    {
                        Console.WriteLine("Usuario nao existente.");
                        Console.WriteLine("Voltando ao menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Olá {Usuarios[Usuarios.IndexOf(user)]}");
                        Console.WriteLine();
                        Console.WriteLine("Escolha o jogo:");
                        Console.WriteLine("1 - JOGO DA VELHA");
                        Console.WriteLine("2 - BATALHA NAVAL");
                        int opjogo = int.Parse(Console.ReadLine());
                        while( opjogo<1 || opjogo>2)
                        {
                            Console.WriteLine("Inválido");
                            Console.WriteLine();
                            Console.WriteLine("Escolha o jogo:");
                            Console.WriteLine("1 - JOGO DA VELHA");
                            Console.WriteLine("2 - BATALHA NAVAL");
                            opjogo = int.Parse(Console.ReadLine());
                        }


                        if(opjogo == 1)
                        {
                            //JOGO DA VELHA
                            while (FimDeJogo == 1)
                            {
                                jogadas = 0; li = 0; col = 0; cont = 0;

                                //inicializando a matriz
                                grade[0, 0] = "1"; grade[0, 1] = "2"; grade[0, 2] = "3";
                                grade[1, 0] = "4"; grade[1, 1] = "5"; grade[1, 2] = "6";
                                grade[2, 0] = "7"; grade[2, 1] = "8"; grade[2, 2] = "9";


                                // 
                                while (jogadas < 9 && (!VitoriaColuna(ref grade, ref col) && !VitoriaLinha(ref grade, ref li) && !VitoriaDiagonal(ref grade)))
                                {
                                    do
                                    {
                                        Cabecalho(placarX, placarO);
                                        ShowMenu(grade);
                                        if ((!VitoriaLinha(ref grade, ref li) && !VitoriaColuna(ref grade, ref col) && !VitoriaDiagonal(ref grade)))
                                        {
                                            Console.WriteLine();
                                            Console.Write("Escolha um botão: ");

                                        }

                                        opcao = int.Parse(Console.ReadLine());

                                    } while (opcao < 1 || opcao > 9); // fica rodando enquanto o numero for invalido

                                    cont++; // Serve para alterar as jogadas entre X e O
                                    if (cont % 2 == 0)
                                        Inserir(ref opcao, ref grade, "O", ref li, ref col);
                                    else
                                        Inserir(ref opcao, ref grade, "X", ref li, ref col);

                                    jogadas++;//conta uma jogada
                                    Cabecalho(placarX, placarO); // Mostra o placar
                                    ShowMenu(grade);
                                    if ((!VitoriaLinha(ref grade, ref li) && !VitoriaColuna(ref grade, ref col) && !VitoriaDiagonal(ref grade)))
                                    {
                                        Console.WriteLine();
                                        Console.Write("Escolha um botão: ");

                                    }
                                }

                                //Atualizando os placares

                                if (cont % 2 == 0)
                                {
                                    placarO++;
                                    auxiliar = "O";
                                }

                                else
                                {
                                    placarX++;
                                    auxiliar = "X";
                                }

                                if ((VitoriaLinha(ref grade, ref li) || VitoriaColuna(ref grade, ref col) || VitoriaDiagonal(ref grade)))
                                    Console.WriteLine($"VITORIA DO {auxiliar}!");

                                else if (jogadas == 9 && (!VitoriaColuna(ref grade, ref col) || !VitoriaLinha(ref grade, ref li) || !VitoriaDiagonal(ref grade)))
                                    Console.WriteLine("EMPATE!");

                                Console.WriteLine();
                                do
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Novo jogo?");
                                    Console.Write("1 - SIM      2 - NAO");
                                    FimDeJogo = int.Parse(Console.ReadLine());
                                } while (FimDeJogo < 1 || FimDeJogo > 2);

                            }





                        }

                        else if(opjogo == 2)
                        {
                            Console.WriteLine("B A T A L H A     N A V A L");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Nickname jogador 1: ");
                            nick1 = Console.ReadLine();
                            Console.WriteLine();
                            Console.WriteLine("Adicionado com sucesso");
                            Console.WriteLine();
                            Console.Write("Nickname jogador 2: ");
                            nick2 = Console.ReadLine();

                            while (nick1.Equals(nick2))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nicknames iguais.");
                                Console.WriteLine();
                                Console.Write("Nickname jogador 2: ");
                                nick2 = Console.ReadLine();

                            }


                            Naval player1 = new Naval(mat);
                            Naval player2 = new Naval(mat2);
                            Naval player3 = new Naval(mat3); // matriz auxiliar para o player1
                            Naval player4 = new Naval(mat4); //matriz auxiliar para o player2   

                            Console.Clear();

                            Console.WriteLine("B A T A L H A     N A V A L");
                            Console.WriteLine();
                            Console.WriteLine();

                            while (aux < 6)
                            {
                                Console.Clear();

                                player1.ShowGrade();
                                Console.WriteLine();
                                Console.WriteLine($"Jogador {nick1}");
                                Console.WriteLine();
                                Console.WriteLine($"Adicione o {aux + 1} submarino:");
                                Console.WriteLine();
                                Console.Write("Linha: ");
                                linha = int.Parse(Console.ReadLine());
                                Console.Write("Coluna: ");
                                coluna = int.Parse(Console.ReadLine());

                                if (player1.Verificacao(linha, coluna, "-")) // Se a posição esta com o "-"
                                {
                                    player1.Inserir("S", linha, coluna);
                                }
                                else
                                {
                                    while (!player1.Verificacao(linha, coluna, "-")) // Se já existe alguma letra lá
                                    {
                                        Console.WriteLine("Posição já ocupada.");
                                        Console.WriteLine();
                                        Console.Write("Linha: ");
                                        linha = int.Parse(Console.ReadLine());
                                        Console.Write("Coluna: ");
                                        coluna = int.Parse(Console.ReadLine());
                                    }
                                    player1.Inserir("S", linha, coluna);
                                }
                                aux++;
                            }
                            Console.Clear();
                            player1.ShowGrade();
                            Console.WriteLine();
                            Console.WriteLine($"{nick1} adicionou os submarinos com sucesso!");
                            Console.WriteLine($"Hora do jogador {nick2}");
                            Console.WriteLine();
                            Console.ReadKey();

                            aux = 0;

                            while (aux < 6)
                            {
                                Console.Clear();

                                player2.ShowGrade();
                                Console.WriteLine();
                                Console.WriteLine($"Jogador {nick2}");
                                Console.WriteLine();
                                Console.WriteLine($"Adicione o {aux + 1} submarino:");
                                Console.WriteLine();
                                Console.Write("Linha: ");
                                linha = int.Parse(Console.ReadLine());
                                Console.Write("Coluna: ");
                                coluna = int.Parse(Console.ReadLine());

                                if (player2.Verificacao(linha, coluna, "-")) // Se a posição esta com o "-"
                                {
                                    player2.Inserir("S", linha, coluna);
                                }
                                else
                                {
                                    while (!player2.Verificacao(linha, coluna, "-")) // Se já existe alguma letra lá
                                    {
                                        Console.WriteLine("Posição já ocupada.");
                                        Console.WriteLine();
                                        Console.Write("Linha: ");
                                        linha = int.Parse(Console.ReadLine());
                                        Console.Write("Coluna: ");
                                        coluna = int.Parse(Console.ReadLine());
                                    }
                                    player2.Inserir("S", linha, coluna);
                                }
                                aux++;
                            }
                            aux = 0;

                            Console.Clear();
                            player2.ShowGrade();
                            Console.WriteLine();
                            Console.WriteLine($"{nick2} adicionou os submarinos com sucesso!");
                            Console.WriteLine("Agora é hora de jogar!");
                            Console.WriteLine();
                            Console.ReadKey();

                            while (fimp1 < 6 && fimp2 < 6) // Enquanto não for o fim do jogo
                            {
                                if (vezp1 == true)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Vez de {nick1}");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    player4.ShowGrade();
                                    Console.WriteLine();
                                    Console.WriteLine("Selecione lugar para bombardear");
                                    Console.Write("Linha: ");
                                    linha = int.Parse(Console.ReadLine());
                                    while (linha < 1 || linha > 5)
                                    {
                                        Console.WriteLine("Linha inválida");
                                        Console.Write("Linha: ");
                                        linha = int.Parse(Console.ReadLine());
                                    }

                                    Console.WriteLine();
                                    Console.Write("Coluna: ");
                                    coluna = int.Parse(Console.ReadLine());
                                    while (coluna < 1 || coluna > 5)
                                    {
                                        Console.WriteLine("Coluna inválida");
                                        Console.Write("Coluna: ");
                                        coluna = int.Parse(Console.ReadLine());
                                    }

                                    while (!player4.Verificacao(linha, coluna, "-"))
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Posição ja bombardeada");
                                        Console.WriteLine();
                                        Console.WriteLine("Selecione lugar para bombardear");
                                        Console.Write("Linha: ");
                                        linha = int.Parse(Console.ReadLine());
                                        while (linha < 1 || linha > 5)
                                        {
                                            Console.WriteLine("Linha inválida");
                                            Console.Write("Linha: ");
                                            linha = int.Parse(Console.ReadLine());
                                        }

                                        Console.WriteLine();
                                        Console.Write("Coluna: ");
                                        coluna = int.Parse(Console.ReadLine());
                                        while (coluna < 1 || coluna > 5)
                                        {
                                            Console.WriteLine("Coluna inválida");
                                            Console.Write("Coluna: ");
                                            coluna = int.Parse(Console.ReadLine());
                                        }

                                    }

                                    if (player2.Verificacao(linha, coluna, "S")) // VAI NA MATRIZ BASE VER SE O SUBMARINO ESTÁ LÁ
                                    {
                                        player4.Inserir("S", linha, coluna);
                                        fimp2++;
                                        Console.Clear();
                                        Console.WriteLine($"Vez de {nick1}");
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        player4.ShowGrade();
                                        Console.WriteLine();
                                        Console.WriteLine("Acertou um submarino!");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        player4.Inserir("X", linha, coluna);
                                        Console.Clear();
                                        Console.WriteLine($"Vez de {nick1}");
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        player4.ShowGrade();
                                        Console.WriteLine();
                                        Console.WriteLine("Bomba na água!");
                                        Console.ReadKey();

                                    }
                                    vezp1 = false; // altera a vez

                                }



                                else // mesma coisa, mas com o jogador 2
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Vez de {nick2}");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    player3.ShowGrade();
                                    Console.WriteLine();
                                    Console.WriteLine("Selecione lugar para bombardear");
                                    Console.Write("Linha: ");
                                    linha = int.Parse(Console.ReadLine());
                                    while (linha < 1 || linha > 5)
                                    {
                                        Console.WriteLine("Linha inválida");
                                        Console.Write("Linha: ");
                                        linha = int.Parse(Console.ReadLine());
                                    }

                                    Console.WriteLine();
                                    Console.Write("Coluna: ");
                                    coluna = int.Parse(Console.ReadLine());
                                    while (coluna < 1 || coluna > 5)
                                    {
                                        Console.WriteLine("Coluna inválida");
                                        Console.Write("Coluna: ");
                                        coluna = int.Parse(Console.ReadLine());
                                    }

                                    while (!player3.Verificacao(linha, coluna, "-"))
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Posição ja bombardeada");
                                        Console.WriteLine();
                                        Console.WriteLine("Selecione lugar para bombardear");
                                        Console.Write("Linha: ");
                                        linha = int.Parse(Console.ReadLine());
                                        while (linha < 1 || linha > 5)
                                        {
                                            Console.WriteLine("Linha inválida");
                                            Console.Write("Linha: ");
                                            linha = int.Parse(Console.ReadLine());
                                        }

                                        Console.WriteLine();
                                        Console.Write("Coluna: ");
                                        coluna = int.Parse(Console.ReadLine());
                                        while (coluna < 1 || coluna > 5)
                                        {
                                            Console.WriteLine("Coluna inválida");
                                            Console.Write("Coluna: ");
                                            coluna = int.Parse(Console.ReadLine());
                                        }

                                    }


                                    if (player1.Verificacao(linha, coluna, "S")) // VAI NA MATRIZ BASE VER SE O SUBMARINO ESTÁ LÁ
                                    {
                                        player3.Inserir("S", linha, coluna);
                                        fimp1++;
                                        Console.Clear();
                                        Console.WriteLine($"Vez de {nick2}");
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        player3.ShowGrade();
                                        Console.WriteLine();
                                        Console.WriteLine("Acertou um submarino!");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        player3.Inserir("X", linha, coluna);
                                        Console.Clear();
                                        Console.WriteLine($"Vez de {nick2}");
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        player3.ShowGrade();
                                        Console.WriteLine();
                                        Console.WriteLine("Bomba na água!");
                                        Console.ReadKey();

                                    }
                                    vezp1 = true; // altera a vez

                                }



                            }

                            //FIM DE JOGO A PARTIR DAQUI

                            if (fimp1 > 5)
                            {
                                Console.Clear();
                                Console.WriteLine($"Parabéns {nick2}! Você venceu! Bom trabalho");
                                Console.WriteLine();
                                Console.ReadKey();
                            }
                            else if (fimp2 > 5)
                            {
                                Console.Clear();
                                Console.WriteLine($"Parabéns {nick1}! Você venceu! Bom trabalho");
                                Console.WriteLine();
                                Console.ReadKey();

                            }

                        }

                        Console.WriteLine();
                        Console.WriteLine("Voltando ao menu");
                        Console.ReadKey();

                    }
            }


            } while (num!=0);



        }
    }
}
