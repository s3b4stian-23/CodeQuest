using System;

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Check the dungeon";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-3) - (0) to exit: ";

        const string ErrorNotNumber = "Error: you must type a number, not text.";
        const string ErrorTooBig = "Error: that number is too big.";
        const string ErrorRange = "Error: the option must be between 0 and 3.";
        const string ErrorNoInput = "Error: no input received.";

        // Valor centinella: -1 NO és una opció vàlida.
        // El necessitem perquè el compilador no garanteix que 'option' s'assigni
        // dins del try (pot saltar una excepció abans d'arribar a l'assignació).
        int option = -1;
        bool isValid;

        do
        {
            isValid = false; // A cada volta suposem que l'entrada NO és vàlida

            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOptionExit);
            Console.Write(MenuPrompt);

            try
            {
                // int.Parse pot llançar: FormatException, OverflowException
                // o ArgumentNullException (si ReadLine retorna null amb Ctrl+Z / Ctrl+D)
                option = int.Parse(Console.ReadLine());

                // Validació de rang: si no es compleix, LLANÇEM nosaltres l'excepció
                if (option < 0 || option > 3)
                {
                    throw new ArgumentOutOfRangeException(nameof(option), ErrorRange);
                }
                // Si arribem aquí no ha saltat cap excepció: entrada vàlida
                isValid = true;
                Console.WriteLine($"You chose: {option}");

                if (option == 1)
                {
                    //Chapter 1

                    // Constants
                   
                    const string MSG_NAME = "Enter a name for your Wizard: ";
                    const string MSG_PUNTS = "your power is now"; 
                    const string MSG_LVLUP = "⭐ Congratulations! You have reached the level: ";
                    const string MSG_LORE = "today you have meditated";
                    const string MSG_JUNE = "You repeat in the 2nd call";
                    const string MSG_TI = "You still confuse the wand with a spoon";
                    const string MSG_TF = "You are a Magic Breeze Invoker";
                    const string MSG_F = "Wow! You can summon dragons 🐲 without burning the laboratory!";
                    const string MSG_HIGHLVL = "You have reached the rank of Arcane Master!";
                    const string MSG_RANK1 = "Raoden the Elantrí";
                    const string MSG_RANK2 = "Zyn the Foolish";
                    const string MSG_RANK3 = "Arka Nullpointer";
                    const string MSG_RANK4 = "Elarion of the Brases";
                    const string MSG_RANK5 = "ITB-Wizard the Gray";

                    // Variables
                    string name = "null";
                    int pp = 0;
                    int lvl = 1;

                    Console.WriteLine(MSG_NAME);
                    name = Console.ReadLine();
                    Console.WriteLine($"Ok, {name}, you will begin an arduous 5-day training regimen.");

                    var random = new Random();

                    for (int day = 1; day <= 5; day++)
                    {
                        Console.WriteLine("---------------------------------------------------------------------------");
                        Console.WriteLine();

                        int hours = random.Next(1, 25);

                        Console.Write($"⌛ Day {day} -> ");

                        if (hours <= 9 && hours >= 1)
                        {
                            int powerGained = random.Next(1, 4);
                            pp += powerGained;
                        }
                        else if (hours <= 16 && hours > 9)
                        {
                            int powerGained = random.Next(4, 7);
                            pp += powerGained;
                        }
                        else if (hours <= 24 && hours > 16)
                        {
                            int powerGained = random.Next(7, 11);
                            pp += powerGained;
                        }

                            Console.WriteLine($"{name}, {MSG_LORE} {hours} hours, and {MSG_PUNTS} {pp} points!");

                            int newLevel = 1 + (pp / 10);
                            if (newLevel > lvl)
                            {
                                lvl = newLevel;
                                Console.WriteLine($"{MSG_LVLUP}{lvl}");
                            }
                                Console.WriteLine();
                                Console.WriteLine("---------------------------------------------------------------------------");
                    }

                    if (pp < 20)
                    {
                    Console.WriteLine($"{name}, {MSG_JUNE}, you received the rank: {MSG_RANK1}");
                    }
                    else if (pp >= 20 && pp < 30)
                    {
                    Console.WriteLine($"{name}, {MSG_TI}, you received the rank: {MSG_RANK2}");
                    }
                    else if (pp >= 30 && pp < 35)
                    {
                    Console.WriteLine($"{name}, {MSG_TF}, you received the rank: {MSG_RANK3}");
                    }
                    else if (pp >= 35 && pp < 40)
                    {
                    Console.WriteLine($"{name}, {MSG_F}, you received the rank: {MSG_RANK4}");
                    }
                    else if (pp >= 40)
                    {
                    Console.WriteLine($"{name}, {MSG_HIGHLVL}, you received the rank: {MSG_RANK5}");
                    } 
                }
                else if (option == 2)
                {
                    // Chapter 2

                    // Constants
                    const string MSG_DOOR = "You are facing door number";
                    const string MSG_GUESS = "Enter the access code (1-5): ";
                    const string MSG_KICKED = "The dragon 🐲 has detected your presence and kicked you from the server!";
                    const string MSG_RESPECT = "The dragon 🐲 respects you. You have unlocked the next level!";
                    const string MSG_TREASURE = "You have unlocked the final level. You can keep the dragon's treasure 💎 🐲!";
                    const string MSG_INVALID = "Invalid input! Please enter a number.";
                    const string MSG_WRONG = "Wrong code!";

                    var randomDoor = new Random();
                    bool isAlive = true;

                    Console.WriteLine("\n--- WELCOME TO THE DUNGEON OF RAMÓN THE POWERFUL 🐉 ---");

                    for (int door = 1; door <= 3 && isAlive; door++)
                    {
                        Console.WriteLine($"\n--- {MSG_DOOR} {door} ---");

                        int secretCode = randomDoor.Next(1, 6);
                        bool doorUnlocked = false;

                        for (int attempt = 1; attempt <= 3 && !doorUnlocked; attempt++)
                        {
                            Console.Write($"Attempt {attempt}/3 - {MSG_GUESS}");

                            if (!int.TryParse(Console.ReadLine(), out int guess))
                            {
                                Console.WriteLine(MSG_INVALID);
                                attempt--;
                                continue;
                            }
                            if (guess == secretCode)
                            {
                                doorUnlocked = true;
                            }
                            else
                            {
                                Console.WriteLine(MSG_WRONG);
                            }
                        }
                        if (!doorUnlocked)
                        {
                            Console.WriteLine(MSG_KICKED);
                            isAlive = false;
                        }
                        else
                        {
                            if (door < 3)
                            {
                                Console.WriteLine(MSG_RESPECT);
                            }
                            else
                            {
                                Console.WriteLine(MSG_TREASURE);
                            }
                        }
                    }
                }
            }
            catch (FormatException)              // Text que no és un número: "abc", "3.5", ""
            {
                Console.WriteLine(ErrorNotNumber);
            }
            catch (OverflowException)            // Número que no cap en un int: "99999999999"
            {
                Console.WriteLine(ErrorTooBig);
            }
            catch (ArgumentNullException)        // ReadLine ha retornat null
            {
                Console.WriteLine(ErrorNoInput);
            }
            catch (ArgumentOutOfRangeException)  // La que hem llançat nosaltres pel rang
            {
                Console.WriteLine(ErrorRange);
            }
            finally
            {
                // S'executa SEMPRE: hi hagi error o no
                Console.WriteLine("----------------------------");
            }

            // Repetim si l'entrada ha estat invàlida O si no han demanat sortir.
            // Comprovem primer !isValid perquè, amb un error, 'option' pot
            // valer 0 d'una volta anterior.
        } while (!isValid || option != 0);
    }
}