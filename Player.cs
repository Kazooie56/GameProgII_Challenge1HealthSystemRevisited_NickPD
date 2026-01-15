using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Challenge1HealthSystemRevisited_NickPD
{
    internal class Player
    {
        // don't need to write public get; public set; because the string is public.
        public string Name { get; set; }
        public Health Health { get; private set; }
        public Health Shield { get; private set; }

        public void TakeDamage(int damage)
        {
            Shield -= damage;
            // _shield?
        }
    }
}
