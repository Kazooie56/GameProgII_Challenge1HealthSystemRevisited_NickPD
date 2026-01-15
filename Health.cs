using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Challenge1HealthSystemRevisited_NickPD
{
    internal class Health
    {
        static void Main(string[] args)
        {

        }
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; }

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
}
