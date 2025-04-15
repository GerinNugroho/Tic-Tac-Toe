namespace tictactoe;
class Program
{
  public static char[] field = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

  static char winStatus = 'D';

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
    bool match = true;
    int turns = 0;
    Player player = new Player();

    setField();
    do
    {
      if (player.Status && match)
      {
        player.Turn();
        turns++;
      }
      else if (!(player.Status) && match)
      {
        player.CPUTurn();
        turns++;
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