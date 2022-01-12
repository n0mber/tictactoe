using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        public static bool fieldFree;
        public static bool youWon;

        static char[,] playField =
        {
            {'1', '2', '3'},
            {'4', '5', '6'},
            {'7', '8', '9'}
        };

        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = false;
            
            

            do
            {
                PlaySetup();
                if (player == 2)
                {
                    player = 1;
                }
                else if (player == 1)
                    player = 2;

                switch (player)
                {
                    case 1:
                        {
                            while (inputCorrect == false)
                            {
                                input = GiveInput(player);
                                fieldFree = CheckIfFree(input, player);                               

                                if (fieldFree == false)
                                {
                                    Console.WriteLine("Incorrect input! Field is already chosen! Please choose another field!");
                                }
                                if (fieldFree == true)
                                {
                                    inputCorrect = true;
                                }

                            }


                            youWon = CheckIfWon(player);

                            if (youWon == true)
                            {
                                Console.WriteLine("Congratulations player 1, you won!");
                            }

                            inputCorrect = false;

                        }
                        break;

                    case 2:
                        {
                            
                            while (inputCorrect == false)
                            {
                                input = GiveInput(player);
                                fieldFree = CheckIfFree(input, player);
                                
                                youWon = CheckIfWon(player);

                                if (youWon == true)
                                {
                                    Console.WriteLine("Congratulations player 1, you won!");
                                }

                                if (fieldFree == false)
                                {
                                    if (NoFree() == true)
                                    {
                                        Console.WriteLine("No winners!");
                                        youWon = true;
                                    }

                                    else
                                    {
                                        Console.WriteLine("Incorrect input! Field is already chosen! Please choose another field!");
                                    }
                                }
                                if (fieldFree == true)
                                {
                                    inputCorrect = true;
                                }

                            }

                            

                            inputCorrect = false;
                            

                        }
                        break;

                }





            }
            while (youWon == false);

            Console.ReadKey();
        }

        public static bool CheckIfWon(int player)
        {
            int count = 0;
            

            for (int i = 0; i < playField.GetLength(0); i++)
            {
                for (int j = 0; j < playField.GetLength(1); j++)
                {
                    if (player == 1)
                    {
                        if (playField[i, j] == 'X')
                        {
                           //miten tsekata onko numero rivissä vika tai viimeinen rivi

                            

                                if (playField[i, ++j] == 'X')
                                {
                                    ++count;

                                    if (count == 2)
                                    {
                                        return true;
                                    }
                                }

                                else if (playField[++i, ++j] == 'X')
                                {
                                    ++count;

                                    if (count == 2)
                                    {
                                        return true;
                                    }
                                }

                                else if (playField[++i, --j] == 'X')
                                {
                                    ++count;

                                    if (count == 2)
                                    {
                                        return true;
                                    }
                                }

                                else if (playField[++i, j] == 'X')
                                {
                                    ++count;

                                    if (count == 2)
                                    {
                                        return true;
                                    }
                                }

                                else
                                {
                                    count = 0;
                                }
                            
                                                       
                            
                        }
    
                    }

                    if (player == 2)
                    {
                        if (playField[i, j] == 'O')
                        {
                            ++count;

                            if (count == 3)
                            {
                                return true;
                            }

                        }
                        
                    }

                }
            }

            return false;
        }

        public static bool CheckIfFree(int field, int player)
        {
            switch (player)
            {
                case 1:
                    {
                        for (int i = 0; i < playField.GetLength(0); i++)
                        {
                            for (int j = 0; j < playField.GetLength(1); j++)
                            {
                                //Inputin convertointi char-muotoon ei toimi tai ole edes mahdollista? Jolloin se ei tunnista onko input valueta matriisissa -> muuta int ensin stringiksi ja sitten chariksi

                                if (playField[i, j] == Convert.ToChar(field.ToString()))
                                {
                                    playField[i, j] = 'X';
                                    return true;
                                }
                            }
                        }     
                    }
                    break;

                case 2:
                    {
                        for (int i = 0; i < playField.GetLength(0); i++)
                        {
                            for (int j = 0; j < playField.GetLength(1); j++)
                            {
                                //Inputin convertointi char-muotoon ei toimi tai ole edes mahdollista? Jolloin se ei tunnista onko input valueta matriisissa -> muuta int ensin stringiksi ja sitten chariksi

                                if (playField[i, j] == Convert.ToChar(field.ToString()))
                                {
                                    playField[i, j] = 'O';
                                    return true;
                                }
                            }
                        }
                    }
                    break;
            }

            return false;
            
        }

        public static bool NoFree()
        {
            for (int i = 0; i < playField.GetLength(0); i++)
            {
                for (int j = 0; j < playField.GetLength(1); j++)
                {
                    for (int z = 1; z < 10; z++)
                    {

                        if (playField[i, j] == Convert.ToChar(z.ToString()))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static int GiveInput(int player)
        {
            bool inputCorrect;
            string place;
            int input = 0;


            switch (player)
            {
                case 1:
                    {
                        Console.WriteLine("Player 1: Choose your field!");
                        place = Console.ReadLine();
                        do
                        {
                            inputCorrect = int.TryParse(place, out input);
                            if (!inputCorrect)
                                Console.WriteLine("Please enter number!");
                        }
                        while (false);
                        input = int.Parse(place);

                        return input;
                    }

                case 2:
                    {
                        Console.WriteLine("Player 2: Choose your field!");
                        place = Console.ReadLine();
                        do
                        {
                            inputCorrect = int.TryParse(place, out input);
                            if (!inputCorrect)
                                Console.WriteLine("Please enter number!");
                        }
                        while (false);
                        input = int.Parse(place);

                        return input;
                    }

            }
            return input;


        }


        public static void PlaySetup()
        {
            Console.WriteLine("    |    |    |");
            Console.WriteLine(" {0}  | {1}  | {2}  |", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("____|____|____|");
            Console.WriteLine("    |    |    |");
            Console.WriteLine(" {0}  | {1}  | {2}  |", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("____|____|____|");
            Console.WriteLine("    |    |    |");
            Console.WriteLine(" {0}  | {1}  | {2}  |", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("____|____|____|");
            Console.WriteLine("    |    |    |");

        }
    }
}
