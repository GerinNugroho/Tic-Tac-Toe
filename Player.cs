namespace tictactoe;

class Player : Program
{

 Random rnd = new Random();
 public bool Status = true;

 public void Turn()
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
  Status = false;
 }
 public void CPUTurn()
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
  Status = true;
 }
};