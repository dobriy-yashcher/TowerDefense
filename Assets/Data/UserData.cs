using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Data
{
    public class UserData
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int Crystals { get; set; }
        public int Stars { get; set; }

        public int Energy { get; set; }

        public const int MaxEnergy = 10;

        public UserData()
        {
            Crystals = 200;
            Stars = 0;
            Energy = MaxEnergy;
        }
    }
}
