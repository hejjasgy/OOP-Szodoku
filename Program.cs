using System;
using System.Collections.Generic;
using System.IO;

namespace sudokuCLI{
    class Feladvany{
        public string Kezdo{get;private set;}
        public int Meret{get;private set;}

        public Feladvany(string sor){
            Kezdo = sor;
            Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
        }

        public void Kirajzol(){
            for (int i = 0; i < Kezdo.Length; i++){
                if(Kezdo[i] == '0'){
                    Console.Write(".");
                }
                else{
                    Console.Write(Kezdo[i]);
                }
                if(i % Meret == Meret - 1){
                    Console.WriteLine();
                }
            }
        }
    }


    internal class Program{

        private static List<Feladvany> feladvanyLIST = new List<Feladvany>();
        
        public static void Main(string[] args){

            feladvanyLIST = beolvasas();
            Console.WriteLine("3. feladat: Beolvasva " + feladvanyLIST.Count + " feladvány\n");

            Console.ReadKey();
        }

        static List<Feladvany> beolvasas(){
            List<Feladvany> ideiglenes = new List<Feladvany>();
            StreamReader streamReader = new StreamReader("feladvanyok.txt");
            while(!streamReader.EndOfStream){
                ideiglenes.Add(new Feladvany(streamReader.ReadLine()));
            }

            return ideiglenes;
        }
    }
}
