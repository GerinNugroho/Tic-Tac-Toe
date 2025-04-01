using System;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace tictactoe
{
 class Program
 {
  static char[,] field = {
   {'1', '2', '3'},
   {'4','5','6'},
   {'7', '8', '9'}
  };

  static int turns = 0;

  static char playerwin = 'D';

  static void setField()
  {
   Console.Clear();
   Console.WriteLine("     |     |   ");
   Console.WriteLine("  {0}  |  {1}  |  {2}", field[0, 0], field[0, 1], field[0, 2]);
   Console.WriteLine(" ----|-----|------ ");
   Console.WriteLine("  {0}  |  {1}  |  {2}", field[1, 0], field[1, 1], field[1, 2]);
   Console.WriteLine(" ----|-----|------ ");
   Console.WriteLine("  {0}  |  {1}  |  {2}", field[2, 0], field[2, 1], field[2, 2]);
   turns++;
  }

  static void turnPlayer(string player, char playerSign)
  {
   int input = 0;
   bool validate = true;
   do
   {
    Console.Write("{0} choose your field: ", player);
    string? inpt = Console.ReadLine();
    if (int.TryParse(inpt, out int num))
    {
     input = num;
    }
    else
    {
     Console.WriteLine("Please enter a number");
    }

    if (input >= 1 && input <= 10)
    {
     validate = false;
    }
    else
    {
     Console.WriteLine("Please enter in field!");
    }
   } while (validate);
   if ((input == 1) && (field[0, 0] == '1'))
   {
    field[0, 0] = playerSign;
   }
   else if ((input == 2) && (field[0, 1] == '2'))
   {
    field[0, 1] = playerSign;
   }
   else if ((input == 3) && (field[0, 2] == '3'))
   {
    field[0, 2] = playerSign;
   }
   else if ((input == 4) && (field[1, 0] == '4'))
   {
    field[1, 0] = playerSign;
   }
   else if ((input == 5) && (field[1, 1] == '5'))
   {
    field[1, 1] = playerSign;
   }
   else if ((input == 6) && (field[1, 2] == '6'))
   {
    field[1, 2] = playerSign;
   }
   else if ((input == 7) && (field[2, 0] == '7'))
   {
    field[2, 0] = playerSign;
   }
   else if ((input == 8) && (field[2, 1] == '8'))
   {
    field[2, 1] = playerSign;
   }
   else if ((input == 9) && (field[2, 2] == '9'))
   {
    field[2, 2] = playerSign;
   }
  }

  static bool checkVictory(char[] arr)
  {
   bool status = true;
   foreach (var element in arr)
   {
    if ((field[0, 0] == field[0, 1]) && (field[0, 1] == field[0, 2]))
    {
     status = false;
     playerwin = element;
    }
    else if ((field[1, 0] == field[1, 1]) && (field[1, 1] == field[1, 2]))
    {
     status = false;
     playerwin = element;
    }
    else if ((field[2, 0] == field[2, 1]) && (field[2, 1] == field[2, 2]))
    {
     status = false;
     playerwin = element;
    }
    else if ((field[2, 0] == field[2, 1]) && (field[2, 1] == field[2, 2]))
    {
     status = false;
     playerwin = element;
    }
    else if ((field[0, 0] == field[1, 0]) && (field[1, 0] == field[2, 0]))
    {
     status = false;
     playerwin = element;
    }
    else if ((field[0, 1] == field[1, 1]) && (field[1, 1] == field[2, 1]))
    {
     status = false;
     playerwin = element;
    }
    else if ((field[0, 2] == field[1, 2]) && (field[1, 2] == field[2, 2]))
    {
     status = false;
     playerwin = element;
    }
    else if ((field[0, 0] == field[1, 1]) && (field[1, 1] == field[2, 2]))
    {
     status = false;
     playerwin = element;
    }
    else if ((field[0, 2] == field[1, 1]) && (field[1, 1] == field[2, 0]))
    {
     status = false;
     playerwin = element;
    }
   }
   return status;
  }
  static void Main(string[] args)
  {
   bool player1 = true, match = true;
   char[] playerSymbol = { 'X', 'O' };
   do
   {
    setField();
    if(turns == 10) {
     match = false;
    }else {
     match  = checkVictory(playerSymbol);
    }
    if (player1 && match)
    {
     turnPlayer("Player 1", 'X');
     player1 = false;
    }
    else if(!(player1) && match)
    {
     turnPlayer("Player 2", 'O');
     player1 = true;
    }
    Console.WriteLine(match);
   } while (match);

   if(playerwin == 'X') {
    Console.WriteLine("Player 1 Win!");
   }else if (playerwin == 'O') {
    Console.WriteLine("Player 2 Win!");
   }else {
    Console.WriteLine("Match Draw!");
   }
  }
 }
}