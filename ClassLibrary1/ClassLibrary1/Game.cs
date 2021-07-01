using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1
{
    public class Game : IValidatableObject
    {
        public int[,] Field { get; private set; }
        public int size { get; set; }
        public int Winner { get; private set; } = 0;
        public bool IsGameEnded { get; private set; } = false;
        private bool IsWinned = false;
        public Game(int size)
        {
            Field = new int[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    Field[i, j] = 0;
            IsGameEnded = false;
        }
        public bool MakeMove(int[,] array, Point point, PlayerTurn player)
        {
            if (!Check.PointCheck(array, point))
                return false;
            else
            {
                array[point.X, point.Y] = (int)player;

                if (Check.WinCheck(array, ref player, ref IsWinned))
                    if (IsWinned == true)
                    {
                        IsGameEnded = true;
                        Winner = (int)player;
                        ReturnWinner();
                    }
            }
            return true;
        }

        public string ReturnWinner()
        {
            if (Winner > 0)
                return $"Won {(PlayerTurn)Winner}!";
            else
                return $"Dead heat!";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> error = new List<ValidationResult>();
            if (this.size % 3 != 0)
                error.Add(new ValidationResult("Неверно указан размер!"));
            return error;
        }
    }
}