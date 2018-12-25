namespace _10._The_Heigan_Dance
{
    using System;

    public class HeiganDance
    {
        public static void Main()
        {
            var playerDamage = double.Parse(Console.ReadLine());
            var field = new string[15][];
            var playerHealth = 18500;
            double heidanHealth = 3000000;
            var playerPositions = new int[] {7, 7};
            bool iscloud = false;
            var spell = "";
            GetField(field);
            while (true)
            {
                if (playerHealth <= 0 || heidanHealth <= 0)
                {
                    break;
                }
                heidanHealth -= playerDamage;
                if (iscloud)
                {
                    playerHealth -= 3500;
                    iscloud = false;
                    spell = "Plague Cloud";
                }
                if (playerHealth <= 0 || heidanHealth <= 0)
                {
                    break;
                }
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.None);
                var spellName = input[0];
                var spellRow = int.Parse(input[1]);
                var spellCol = int.Parse(input[2]);
                
                bool isHit = SpellCast(field, spellName, spellRow, spellCol,playerPositions);
                if (isHit)
                {
                    string moveDirection = Moving(field, playerPositions);
                    if (moveDirection=="NoWay")
                    {
                        playerHealth=TakeDamage(playerHealth, spellName);
                        if (spellName=="Cloud")
                        {
                            iscloud = true;
                            spell = "Plague Cloud";
                        }
                        else
                        {
                            spell = "Eruption";
                        }
                    }
                    else
                    {
                        playerPositions=MovePlayer(moveDirection, playerPositions);
                    }
                }

                DefaultField(field);
            }

            if (heidanHealth<=0)
            {
                Console.WriteLine($"Heigan: Defeated!");
                
            }
            else
            {
                Console.WriteLine($"Heigan: {heidanHealth:F2}");
            }

            if (playerHealth<=0)
            {
                Console.WriteLine($"Player: Killed by {spell}");
            }
            else
            {
                Console.WriteLine($"Player: {playerHealth}");
            }
            Console.WriteLine($"Final position: {playerPositions[0]}, {playerPositions[1]}");
        }

        private static void DefaultField(string[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col]!="" || field[row][col]!="")
                    {
                        field[row][col] ="";
                    }
                }
            }
        }

        private static int[] MovePlayer(string moveDirection, int[] playerPositions)
        {
            if (moveDirection=="Up")
            {
                playerPositions[0] -= 1;
            }
            else if (moveDirection=="Down")
            {
                playerPositions[0] += 1;
            }
            else if (moveDirection == "Left")
            {
                playerPositions[1] -= 1;
            }
            else if (moveDirection == "Right")
            {
                playerPositions[1] += 1;
            }

            return playerPositions;
        }

        private static int TakeDamage(int playerHealth, string spellName)
        {
            if (spellName=="Cloud")
            {
                playerHealth -= 3500;
            }
            else
            {
                playerHealth -= 6000;
            }

            return playerHealth;
        }

        private static string Moving(string[][] field, int[] playerPositions)
        {
            var row = playerPositions[0];
            var col = playerPositions[1];
            string moveDirection = "NoWay";
            if (InSide(field,row-1,col)&& field[row - 1][col] == "")
            {
                    moveDirection = "Up";
            }
            else if (InSide(field, row, col+1) && field[row][col + 1] == "")
            {

                moveDirection = "Right";
            }
            else if (InSide(field, row+1, col) && field[row+1][col] == "")
            {

                moveDirection = "Down";
            }
            else if (InSide(field, row, col - 1) && field[row][col - 1] == "")
            {
                moveDirection = "Left";
            }
            return moveDirection;
        }

        private static bool SpellCast(string[][] field, string spellName, int spellRow, int spellCol,int[] playerPosition)
        {
            var playerRow = playerPosition[0];
            var playerCol = playerPosition[1];
            bool isHit = false;
            var spell = "S";
            for (int row = spellRow-1; row <= spellRow+1; row++)
            {
                for (int col = spellCol-1; col <= spellCol+1; col++)
                {
                    if (InSide(field,row,col))
                    {
                        field[row][col] = spell;
                    }

                    if (row == playerRow&& col==playerCol)
                    {
                        isHit = true;
                    }
                    
                }
            }

            return isHit;
        }

        private static bool InSide(string[][] field, int row, int col)
        {
            return row >= 0 && row < field.Length && col >= 0 && col < field[row].Length;
        }
        
        private static void GetField(string[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                field[row]= new string[15];
                for (int col = 0; col < field[row].Length; col++)
                {
                    field[row][col] = "";
                }
            }
        }
    }
}
