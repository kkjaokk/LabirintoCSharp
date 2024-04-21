﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LabirintoCSharp
{
    internal class Program
    {

        private const int limit = 15;


        static void mostrarLabirinto(char[,] array, int l, int c)
        {

            Console.Write("\n Labirinto do Ratão");
            Console.Write("\n");

            for (int i = 0; i < l; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < c; j++)
                {
                    Console.Write($" {array[i, j]} ");
                }
            }
            Console.WriteLine();
        }


        static void criaLabirinto(char[,] meuLab)
        {
            Random random = new Random();
            for (int i = 0; i < limit; i++)
            {
                for (int j = 0; j < limit; j++)
                {
                    meuLab[i, j] = random.Next(4) == 1 ? '|' : '.';
                }
            }


            for (int i = 0; i < limit; i++)
            {
                meuLab[0, i] = '*';
                meuLab[limit - 1, i] = '*';
                meuLab[i, 0] = '*';
                meuLab[i, limit - 1] = '*';
            }


            int x = random.Next(limit);
            int y = random.Next(limit);

            if(meuLab[x, y] =='*')
            {

                x = random.Next(limit);
                y = random.Next(limit);

            }

            meuLab[x, y] = 'Q';

            

        }

        static void buscarQueijo(char[,] meuLab, int i, int j)
 {
        Stack<int> minhaPilha = new Stack<int>();
            int a, b;    

            


            do
     {
         meuLab[i, j] = 'R';

         if (meuLab[i, j + 1] == '.') //move direita
         {

                    a = i;
                    b = j;
                    minhaPilha.Push(i);
                    minhaPilha.Push(j);
                    
                    
                    
                    j++;

         }else if (meuLab[i+1, j] == '.') //move baixo
                {

                    a = i;
                    b = j;
                    minhaPilha.Push(i);
                    minhaPilha.Push(j);

                    

                    i++;

                }

         else if (meuLab[i, j-1] == '.') //move esquerda
                {

                    a = i;
                    b = j;
                    minhaPilha.Push(i);
                    minhaPilha.Push(j);

                    

                    j--;

                }

         else if (meuLab[i - 1, j] == '.') //move cima
                {

                    a = i;
                    b = j;
                    minhaPilha.Push(i);
                    minhaPilha.Push(j);

                    

                    i--;

                }

         

         else if (minhaPilha.Count() > 0)
                {
                    a = i;
                    b = j;
                    meuLab[i, j] = 'x';
                    i = minhaPilha.Pop();
                    j = minhaPilha.Pop();
                    

                }else{

                    Console.Write("ERRO");
                    
                    break;
                }

                
                //else if baixo i+1
                // else if esquerda j-1
                // else if cima i-1
                // if nao tiver vazio minhaPilha.Count()>0
                // i, j = pop
                // se tiver vazio
                // return false


         System.Threading.Thread.Sleep(200);
         Console.Clear();
         mostrarLabirinto(meuLab, limit, limit);
         

     } while (meuLab[i, j] != 'Q');

            

                Console.Write("ACHO");

            

            // encontrou
        }




        static void Main(string[] args)
        {

            char[,] labirinto = new char[limit, limit];
            
            criaLabirinto(labirinto);
            mostrarLabirinto(labirinto, limit, limit);
           
            buscarQueijo(labirinto, 1, 1);
            Console.ReadKey();


        }
    }
}