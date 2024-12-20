using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks.Dataflow;
namespace Donkeykong
{
    //public static class SharedStrings
    //{
    //}
    public class Person
    {
        public static bool Anschalten = false;
        public static int xposMario2;
        public static int yposMario2;
        public static char Steuerung;
        public static int xposMario;
        public static int yposMario;
        public static int xposBall;
        public static int yposBall;
        public static bool GameRunning = true;
        public static int xposBall2;
        public static int yposBall2;
        public async Task Jump()
        {
            char key;
            while (GameRunning == true)
            {
                key = Console.ReadKey(true).KeyChar;
                if (key == ' ')
                {
                    //if (xposMario <= 19 && xposMario >= 25 && yposMario <= 24 && yposMario >= 12)
                    //{
                    yposMario += 5;
                    //}
                    //else
                    //{
                    yposMario -= 3;
                    await Task.Delay(300);
                    yposMario += 3;
                    //}
                }
            }
        }
        public async Task XposMario()
        {
            char A;
            while (GameRunning == true)
            {
                A = Console.ReadKey(true).KeyChar;
                if (A == 'a' /*|| A == 'A'*/)
                {
                    //if (xposMario >= 1 && xposMario <= 151)
                    //{
                    xposMario--;
                    //}
                }
                await Task.Delay(10);
            }
        }
        public async Task NegXposMario()
        {
            char Y;
            while (GameRunning == true)
            {
                Y = Console.ReadKey(true).KeyChar;
                if (Y == 'd'/* || Y == 'D'*/)
                    //if (xposMario >= 0 && xposMario <= 150)
                    //{
                    xposMario++;
                //}
                await Task.Delay(10);
            }
        }

        //}
        //public class Programm
        //{
        //public static bool Aenderung = false;
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Char Startkey;
            Console.WriteLine("Gehen sie ins Vollbild und starten sie das Spiel");
            while (Anschalten == false)
            {

                Startkey = Console.ReadKey().KeyChar;
                switch (Startkey)
                {
                    case 's':
                        Anschalten = true;
                        break;
                    case 'S':
                        Anschalten = true;
                        break;
                    default:
                        Anschalten = false;
                        Console.WriteLine("Drücken sie S/sss zu, starten.");
                        break;
                        Person person = new Person();
                        await person.Jump();
                        await person.XposMario();
                        await person.NegXposMario();
                }
            }
            xposMario = 0;
            yposMario = 29;
            xposBall = 0;
            yposBall = 2;

            Console.Clear();
            //Thread a = new Thread(MarioControll);
            //Thread d = new Thread(steuerung);
            //d.Start();
            //a.Start();
            MarioControll();
            //}
        }
        /* public async Task Async()
         {
             Person spieler = new Person();
             await spieler.Jump();
             await spieler.XposMario();
             await spieler.NegXposMario();

         }*/
        public static void MarioControll()
        {
            while (GameRunning == true)
            {
                Console.SetCursorPosition(0, 0);
                /*if (Aenderung == true)
                {*/
                Structure();
                Mario();
                Ball();
                Thread.Sleep(30);         //IMPORTANT!!!
                //Thread.Sleep(5);
                //Thread.Sleep(5);
                /*Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine("▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁");
                 Console.WriteLine("╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳");
                 Console.WriteLine("▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔");
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine("▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁");
                 Console.WriteLine("╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳");
                 Console.WriteLine("▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔");
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine("▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁");
                 Console.WriteLine("╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳");
                 Console.WriteLine("▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔┣━━━┫▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔");
                 Console.WriteLine("                                               ┣━━━┫                                                                                                        ");
                 Console.WriteLine("                                               ┣━━━┫                                                                                                        ");
                 Console.WriteLine("                                               ┣━━━┫                                                                                                        ");
                 Console.WriteLine("                                               ┣━━━┫                                                                                                        ");
                 Console.WriteLine("▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁┣━━━┫▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁");
                 Console.WriteLine("╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳");
                 Console.WriteLine("▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔");
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine("▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁");
                 Console.WriteLine("╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳");
                 Console.WriteLine("▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔");*/
                //Thread.Sleep(10);
                //break
                /*Console.SetCursorPosition(xposBall, yposBall);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  ");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  ");
                Console.ResetColor();*/
                //break
                /*xposMario2 = xposMario;
                yposMario2 = yposMario;
                Console.SetCursorPosition(xposMario2, yposMario2);
                yposMario2++;
                Console.SetCursorPosition(xposMario2, yposMario2);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" ");
                yposMario2++;
                Console.SetCursorPosition(xposMario2, yposMario2);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" ");
                yposMario2++;
                Console.SetCursorPosition(xposMario2, yposMario2);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("   ");
                yposMario2++;
                Console.SetCursorPosition(xposMario2, yposMario2);
                Console.BackgroundColor = ConsoleColor.Black;
                Thread.Sleep(40);*/
                //Aenderung = false;
                //}
            }
        }

        /*public static void steuerung()
        {
            while (GameRunning == true)
            {
                Steuerung = Console.ReadKey(true).KeyChar;
                switch (Steuerung)
                {
                    /*case ' ':
                        if (xposMario <= 19 && xposMario >= 25 && yposMario <= 24 && yposMario >= 12)
                        {
                            yposMario += 5;
                            //Aenderung = true;
                        }*/
        /*else
        {
            yposMario -= 3;
            Thread.Sleep(300);
            yposMario += 3;
            //Aenderung = true;
        }*/

        //case 'a':
        /*if (xposMario >= 1 && xposMario <= 151)
        {
            xposMario--;
            //Aenderung = true;
        }*/
        //break;
        /*case 's':

            break;*/
        /*case 'd':
            if (xposMario >= 0 && xposMario <= 150)
            {
                xposMario++;
                //Aenderung = true;
            }
            break;
        default:

            break;
        }
    }*/

        /*public async Task Climb()
        {
            while (GameRunning == true)
            {
            }
        }*/
        public static void Mario()
        {
            xposBall2 = xposBall;
            yposBall2 = yposBall;
            xposMario2 = xposMario;
            yposMario2 = yposMario;
            Console.SetCursorPosition(xposMario2, yposMario2);
            yposMario2++;
            Console.SetCursorPosition(xposMario2, yposMario2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" ");
            yposMario2++;
            Console.SetCursorPosition(xposMario2, yposMario2);
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" ");
            yposMario2++;
            Console.SetCursorPosition(xposMario2, yposMario2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("   ");
            yposMario2++;
            Console.SetCursorPosition(xposMario2, yposMario2);
            Console.BackgroundColor = ConsoleColor.Black;
            //Thread.Sleep(20);
        }
        public static void Ball()
        {
            Console.SetCursorPosition(xposBall2, yposBall2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("  ");
            yposBall2++;
            Console.SetCursorPosition(xposBall2, yposBall2);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("  ");
            yposBall2++;
            Console.SetCursorPosition(xposBall2, yposBall2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("  ");
            yposBall2++;
            Console.SetCursorPosition(xposBall2, yposBall2);
            Console.ResetColor();
            //Thread.Sleep(20);
        }
        public static void Structure()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            //Console.Clear();
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁");
            Console.WriteLine("╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳");
            Console.WriteLine("▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁");
            Console.WriteLine("╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳");
            Console.WriteLine("▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁");
            Console.WriteLine("╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳");
            Console.WriteLine("▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔┣━━━┫▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔");
            Console.WriteLine("                                               ┣━━━┫                                                                                                        ");
            Console.WriteLine("                                               ┣━━━┫                                                                                                        ");
            Console.WriteLine("                                               ┣━━━┫                                                                                                        ");
            Console.WriteLine("                                               ┣━━━┫                                                                                                        ");
            Console.WriteLine("▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁┣━━━┫▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁");
            Console.WriteLine("╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳");
            Console.WriteLine("▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁");
            Console.WriteLine("╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳");
            Console.WriteLine("▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔");
        }
    }
}