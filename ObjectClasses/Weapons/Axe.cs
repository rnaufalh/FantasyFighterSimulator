namespace ObjectClasses.Weapons
{
    public class Axe : Weapon
    {
        const string DEFAULT_NAME = "Simple Axe";
        const int DEFAULT_DAMAGE = 90;

        private int damage;

        public override int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                if (value > 100)
                {
                    System.Console.WriteLine("Axe's Damage can't be more than 100");
                }
                else if (value < 80)
                {
                    System.Console.WriteLine("Axe's Damage can't be less than 80");
                }
                else
                {
                    damage = value;
                }
            }
        }

        public Axe()
            : this(DEFAULT_NAME, DEFAULT_DAMAGE)
        {

        }

        public Axe(string name, int damage)
        {
            base.Name = name;
            this.Damage = damage;
            
        }
    }
}