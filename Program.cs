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

            negyedikFeladatX();
            
            
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

        static void negyedikFeladatX(){
            Console.WriteLine("4. feladat: Kérem adja meg a feladvány méretét [4..9]: ");
            String x = Console.ReadLine();
            try{
                int meretX = Int32.Parse(x);
                if(meretX < 10 && meretX > 3){
                    negyedikFeladat(meretX);
                }else{
                    negyedikFeladatX();
                }
            }catch(Exception e){
                Console.WriteLine(e);
                negyedikFeladatX();
            }
        } 

        static void negyedikFeladat(int meretX){
            int talatMeret = 0;
            
            List<Feladvany> feladvanysz = new List<Feladvany>();

            foreach (Feladvany feladvany in feladvanyLIST){
                if(feladvany.Meret == meretX){
                    talatMeret++;
                    feladvanysz.Add(feladvany);

                }
            }


            
            Console.WriteLine(meretX+"x"+meretX + " méretű feladványból " + talatMeret + " darab van tárolva\n");
      
            Feladvany veletlenFeladvany = feladvanysz[new Random().Next(0, feladvanysz.Count - 1)];

            Console.WriteLine("5. feladat: A kiválaszott feladvány:\n" + veletlenFeladvany.Kezdo);

            int kitoltottMezok = 0;
            double osszesMezo = veletlenFeladvany.Kezdo.Length;

            foreach(char karakter in veletlenFeladvany.Kezdo){
                if(karakter != '0') kitoltottMezok++;
            }

            double szazalek = (kitoltottMezok/osszesMezo)*100;
            Console.WriteLine("6. feladat: A feladvány kitöltöttsége: " + Math.Round(szazalek,0)+"%\n");
            Console.WriteLine("7. feladat: A feladvány kirajzolva:");
            veletlenFeladvany.Kirajzol();

            StreamWriter streamWriter = new StreamWriter("sudoku" + meretX + ".txt");
            foreach (Feladvany feladvany in feladvanysz){
                streamWriter.WriteLine(feladvany.Kezdo);
            }
            streamWriter.Flush();
            streamWriter.Close();
            
            Console.WriteLine("8. feladat: sudoku" + meretX + ".txt állomány " + feladvanysz.Count + " darab feladvánnyal létrehozva");

        }
    }
}
