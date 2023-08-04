using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Damage_counter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstCharacterHealth = 100; //Здоровье первого персонажа

            int secondCharacterHealth = 100; //Здоровье второго персонажа
            
           
           

            int inputFirstCharacterDamage = Program.readIntFromConsole("Введите урон первого персонажа","Паша, ты дурак?"); //Полученное значение для первого персонажа
            int firstCharacterArmor = Program.readIntFromConsole("Введите броню первого персонажа", "Давай по-новой, все фигня");
            

            int inputSecondCharacterDamage = Program.readIntFromConsole("Введите урон второго персонажа","Повторите ввод для второго персонажа");
            int secondCharacterArmor = Program.readIntFromConsole("Введите броню второго персонажа", "Давай по-новой, все фигня");
            
            Console.WriteLine($"Урон первого персонажа =  {inputFirstCharacterDamage}");
           
            Console.WriteLine($"Урон второго персонажа =  {inputSecondCharacterDamage}");
           
            Random rnd = new Random(); // Выбор кто атакует первым
                                       
            bool isFirst = rnd.Next(0, 2) == 0;
            

            do
            {
                Console.WriteLine(firstCharacterHealth > 0 && secondCharacterHealth > 0);
                Console.WriteLine($"Кто первый: true - первый, false - второй { isFirst}");
                

                if (isFirst)
                {
                    Console.WriteLine("Бьет первый персонаж");
                    secondCharacterHealth = Program.damageDeatl(secondCharacterHealth, inputFirstCharacterDamage, secondCharacterArmor,0);
                    Console.WriteLine("Здоровье второго персонажа");
                    Console.WriteLine(secondCharacterHealth);
                }
                else
                {
                    Console.WriteLine("Бьет второй персонаж");
                    firstCharacterHealth = Program.damageDeatl(firstCharacterHealth, inputSecondCharacterDamage, firstCharacterArmor, 0);
                    Console.WriteLine("Здоровье первого персонажа");
                    Console.WriteLine(firstCharacterHealth);
                }
                isFirst = !isFirst;
            }
            while (firstCharacterHealth > 0 && secondCharacterHealth > 0);
          
        }
        public static int readIntFromConsole(string startMessage, string exeptionMessage)
        {
            int number;
            bool isNumber;
            do
            {
                Console.WriteLine(startMessage);
                string input = Console.ReadLine();
                isNumber = int.TryParse(input, out number);
                if (!isNumber)
                {
                    Console.WriteLine(exeptionMessage);
                }
               
            } while (!isNumber);
            return number; 
           
        }
        public static int damageDeatl (int health, int damage, int armor, int berserk)
        {
            Random rnd2 = new Random();
            berserk = rnd2.Next(0, 11);
            
            int newDamage = damage;
            if (newDamage < (damage - armor))
            {
                newDamage = 3;
                armor = 0;
               
            }

            int newHealth = health - (newDamage - armor);
            if (newHealth < 0)
            {
                return 0;
            }
            else if (berserk < 3 | berserk > 7)
            {
                newDamage = newDamage * 2;
                Console.WriteLine($"Состояние берсерка {berserk}"); ;
            }
            return newHealth;
        }
                
    }
}


