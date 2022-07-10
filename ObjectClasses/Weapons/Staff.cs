namespace ObjectClasses.Weapons
{
    public class Staff : Weapon
    {
        const string DEFAULT_NAME = "Simple Staff";
        const int DEFAULT_DAMAGE = 40;
        private int damage;

        public override int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                if (value > 50)
                {
                    System.Console.WriteLine("Staff's Damage can't be more than 50");
                }
                else if (value < 30)
                {
                    System.Console.WriteLine("Staff's Damage can't be less than 30");
                }
                else
                {
                    damage = value;
                }
            }
        }

        public Staff()
            : this(DEFAULT_NAME, DEFAULT_DAMAGE)
        {

        }

        public Staff(string name, int damage)
        {
            base.Name = name;
            this.Damage = damage;
        }
    }
}