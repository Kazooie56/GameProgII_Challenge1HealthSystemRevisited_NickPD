using System;


namespace GameProgII_Challenge1HealthSystemRevisited_NickPD
{
    class Program
    {
        static string chosenName;
        static bool gameRunning = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your character's name:");

            chosenName = Console.ReadLine();
            Player player = new Player(name: chosenName, maxHealth: 100, maxShield: 50);

            while (gameRunning == true)
            {
                Random random = new Random();
                int randomNumber = random.Next(21);

                ShowHUD(player);

                Console.WriteLine("Press D key to take damage or H key to heal");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.D)
                {
                    player.TakeDamage(randomNumber);
                    Console.Clear();
                }

                if (keyInfo.Key == ConsoleKey.H)
                {

                    if (randomNumber > player.Health.MaxHealth - player.Health.CurrentHealth)
                    {
                        player.Health.Restore();
                        Console.Clear();
                    }
                    else
                    {
                        player.Health.Heal(randomNumber);

                        Console.Clear();
                        
                    }
                }
                Console.Clear();

                if (player.Health.CurrentHealth <= 0)
                {
                    gameRunning = false;
                    Console.WriteLine("You died! Press any key...");
                    Console.ReadKey(true);
                }
            }
        }

        

        static void ShowHUD(Player player)
        {
            Console.WriteLine($"Name: {player._name} Health: {player.Health.CurrentHealth} Shield: {player.Shield.CurrentHealth} Status: {player.GetStatusString()}");
        }
        internal class Health
        {
            public int _maxHealth;
            public int _currentHealth;


            public int CurrentHealth
            {
                get { return _currentHealth; }
                private set { _currentHealth = value; }
            }
            public int MaxHealth
            {
                get { return _maxHealth; }
                private set { _maxHealth = value; }
            }
            public void TakeDamage(int damage)
            {
                if (damage < 0)
                {
                    Console.WriteLine("Damage cannot be negative.");
                    return;
                }
                if (damage > CurrentHealth)
                {
                    damage = CurrentHealth;
                }

                CurrentHealth -= damage;
            }

            public void Restore()
            {
                CurrentHealth = MaxHealth;
            }

            public void Heal(int healing)
            {
                if (healing < 0)
                {
                    Console.WriteLine("Healing cannot be negative.");
                    return;
                }
                if (CurrentHealth + healing > MaxHealth)
                {
                    CurrentHealth = MaxHealth;
                }

                CurrentHealth += healing;
            }

            public Health(int maxHealth)
            {
                MaxHealth = maxHealth;
                CurrentHealth = maxHealth;
            }
        }
        internal class Player
        {
            int _currentHealth;
            int _maxHealth;
            int _maxShield;
            public string _name;

            public string chosenName;


            public Health _health = new Health(100);
            public Health _shield = new Health(50);

            // don't need to write public get; public set; because the string is public.
            public string Name { get; set; }

            // These two are classes btw
            public Health Health
            {
                get { return _health; }
                private set { _health = value; }
            }

            public Health Shield
            {
                get { return _shield; }
                private set { _shield = value; }
            }

            public Player(string name, int maxHealth, int maxShield)
            {
                _name = name;
                _maxHealth = maxHealth;
                _maxShield = maxShield;
            }

            public void TakeDamage(int damage)
            {
                int spilloverDamage;
                // if damage is negative, print error message and return

                if (damage < 0)
                {
                    Console.WriteLine("Damage cannot be negative.");
                    return;
                }
                // first apply damage to shield
                
                if (damage < Shield.CurrentHealth)
                {
                    Shield._currentHealth -= damage;

                }
                else if (damage >= Shield.CurrentHealth)
                {
                    spilloverDamage = damage - Shield.CurrentHealth;
                    Shield._currentHealth = 0;
                    Health.TakeDamage(spilloverDamage);
                }
                else if (Shield.CurrentHealth <= 0)
                {
                    Health._currentHealth -= damage;

                }
                


            }
            public string GetStatusString()
            {
                string status;

                if (Health.CurrentHealth > 80)
                    status = "Healthy";
                else if (Health.CurrentHealth > 60)
                    status = "Injured";
                else if (Health.CurrentHealth > 0)
                    status = "Critical";
                else
                    status = "Dead";

                return status;
            }
        }
    }
}