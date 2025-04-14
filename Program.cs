namespace tictactoe;
class Program
{
  static char[] field = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

  static int turns = 0;

  static char winStatus = 'D';

  static Random rnd = new Random();

  static void setField()
  {
    Console.Clear();
    Console.WriteLine("     |     |   ");
    Console.WriteLine("  {0}  |  {1}  |  {2}", field[0], field[1], field[2]);
    Console.WriteLine(" ----|-----|------ ");
    Console.WriteLine("  {0}  |  {1}  |  {2}", field[3], field[4], field[5]);
    Console.WriteLine(" ----|-----|------ ");
    Console.WriteLine("  {0}  |  {1}  |  {2}", field[6], field[7], field[8]);
  }

  static void turnPlayer()
  {
    int input = 0;
    bool validate = true;
    do
    {
      Console.Write("Player choose your field: ");
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
    if ((input == 1) && (field[0] == '1'))
    {
      field[0] = 'X';
    }
    else if ((input == 2) && (field[1] == '2'))
    {
      field[1] = 'X';
    }
    else if ((input == 3) && (field[2] == '3'))
    {
      field[2] = 'X';
    }
    else if ((input == 4) && (field[3] == '4'))
    {
      field[3] = 'X';
    }
    else if ((input == 5) && (field[4] == '5'))
    {
      field[4] = 'X';
    }
    else if ((input == 6) && (field[5] == '6'))
    {
      field[5] = 'X';
    }
    else if ((input == 7) && (field[6] == '7'))
    {
      field[6] = 'X';
    }
    else if ((input == 8) && (field[7] == '8'))
    {
      field[7] = 'X';
    }
    else if ((input == 9) && (field[8] == '9'))
    {
      field[8] = 'X';
    }
    turns++;
  }

  static void cpuMove()
  {
    int index = 0;
    if (field[0] == field[1] && field[2] == '3' || field[8] == field[5] && field[2] == '3' || field[6] == field[4] && field[2] == '3')
    {
      index = 2;
    }
    else if (field[3] == field[4] && field[5] == '6' || field[2] == field[8] && field[5] == '6')
    {
      index = 5;
    }
    else if (field[6] == field[7] && field[8] == '9' || field[2] == field[5] && field[8] == '9' || field[0] == field[4] && field[8] == '9')
    {
      index = 8;
    }
    else if (field[0] == field[3] && field[6] == '7' || field[8] == field[7] && field[6] == '7' || field[2] == field[4] && field[6] == '7')
    {
      index = 6;
    }
    else if (field[2] == field[1] && field[0] == '1' || field[6] == field[3] && field[0] == '1' || field[8] == field[4] && field[0] == '1')
    {
      index = 0;
    }
    else if (field[0] == field[6] && field[3] == '4' || field[5] == field[4] && field[3] == '4')
    {
      index = 3;
    }
    else if (field[0] == field[2] && field[1] == '2' || field[7] == field[4] && field[1] == '2')
    {
      index = 1;
    }
    else if (field[6] == field[8] && field[7] == '8' || field[1] == field[4] && field[7] == '8')
    {
      index = 7;
    }
    else if (field[3] == field[5] && field[4] == '5' || field[1] == field[7] && field[4] == '5' || field[0] == field[8] && field[4] == '5' || field[2] == field[6] && field[4] == '5')
    {
      index = 4;
    }
    else
    {
      bool action = false;
      do
      {
        index = rnd.Next(9);
        if (field[index] == 'X' || field[index] == 'O')
        {
          action = true;
        }
        else
        {
          action = false;
        }
      } while (action);
    }
    field[index] = 'O';
    turns++;
  }

  static bool checkVictory()
  {
    bool status = true;
    if ((field[0] == field[1]) && (field[1] == field[2]))
    {
      status = false;
      winStatus = field[0];
    }
    else if ((field[3] == field[4]) && (field[4] == field[5]))
    {
      status = false;
      winStatus = field[3];
    }
    else if ((field[6] == field[7]) && (field[7] == field[8]))
    {
      status = false;
      winStatus = field[6];
    }
    else if ((field[0] == field[3]) && (field[3] == field[6]))
    {
      status = false;
      winStatus = field[0];
    }
    else if ((field[1] == field[4]) && (field[4] == field[7]))
    {
      status = false;
      winStatus = field[1];
    }
    else if ((field[2] == field[5]) && (field[5] == field[8]))
    {
      status = false;
      winStatus = field[2];
    }
    else if ((field[0] == field[4]) && (field[4] == field[8]))
    {
      status = false;
      winStatus = field[0];
    }
    else if ((field[2] == field[4]) && (field[4] == field[6]))
    {
      status = false;
      winStatus = field[2];
    }
    return status;
  }
  static void Main(string[] args)
  {
    bool player = true, match = true;
    setField();
    do
    {
      if (player && match)
      {
        turnPlayer();
        player = false;
      }
      else if (!(player) && match)
      {
        cpuMove();
        player = true;
        Console.WriteLine("Menunggu Turn CPU!");
        Thread.Sleep(1500);
      }
      if (turns == 9)
      {
        match = false;
      }
      else
      {
        match = checkVictory();
      }
      setField();
    } while (match);

    if (winStatus == 'X')
    {
      Console.WriteLine("Player Win!");
    }
    else if (winStatus == 'O')
    {
      Console.WriteLine("CPU Win!");
    }
    else
    {
      Console.WriteLine("Match Draw!");
    }
  }
}