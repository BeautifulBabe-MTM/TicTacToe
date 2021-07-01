namespace ClassLibrary1
{
    class Check
    {
        private static int counter = 0;
        public static bool PointCheck(int[,] array, Point point)
        {
            if (point.X < default(int) || point.Y < default(int))
                throw new System.Exception("Введённые координаты слишком малы и выходят за пределы поля.");
            else if (point.X > System.Math.Sqrt(array.Length) || point.Y > System.Math.Sqrt(array.Length))
                throw new System.Exception("Введённые координаты слишком большие и выходят за пределы поля.");
            else if (array[point.X, point.Y] != default(int))
                throw new System.Exception("Ячейка по введённым координатам уже занята.");
            return true;
        }
        public static bool WinCheck(int[,] array, ref PlayerTurn winner, ref bool isWinned)
        {
            for (int i = 0; i < System.Math.Sqrt(array.Length); i++)
            {
                for (int j = 0; j < System.Math.Sqrt(array.Length) - 1; j++)
                    if (array[i, j] == array[i, j + 1] && array[i, j + 1] != 0)
                        if (++counter == 2)
                        {
                            isWinned = true;
                            winner = (PlayerTurn)array[i, j];
                            return true;
                        }
                counter = 0;
            }

            for (int i = 0; i < System.Math.Sqrt(array.Length); i++)
            {
                for (int j = 0; j < System.Math.Sqrt(array.Length) - 1; j++)
                    if (array[j, i] == array[j + 1, i] && array[j + 1, i] != 0)
                        if (++counter == 2)
                        {
                            isWinned = true;
                            winner = (PlayerTurn)array[j, i];
                            return true;
                        }
                counter = 0;
            }

            if (array[0, 0] == array[1, 1] && array[1, 1] == array[2, 2] && array[0, 0] != 0)
            {
                isWinned = true;
                winner = (PlayerTurn)array[0, 0];
                return true;
            }
            if (array[0, 2] == array[1, 1] && array[1, 1] == array[2, 0] && array[0, 2] != 0)
            {
                isWinned = true;
                winner = (PlayerTurn)array[0, 2];
                return true;
            }

            isWinned = false;
            return false;
        }
    }
}
