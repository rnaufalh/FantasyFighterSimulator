namespace ObjectClasses.Armors
{
    public class Robe : Armor
    {
        const string DEFAULT_NAME = "Simple Robe";
        const int DEFAULT_ARMOR_POINTS = 2;
        private int armorPoints;

        public override int ArmorPoints
        {
            get
            {
                return armorPoints;
            }
            set
            {
                if (value > 2)
                {
                    System.Console.WriteLine("Robe's AP can't be more than 2");
                }
                else if (value < 1)
                {
                    System.Console.WriteLine("Robe's AP can't be less than 1");
                }
                else
                {
                    armorPoints = value;
                }
            }
        }

        public Robe()
            : this(DEFAULT_NAME, DEFAULT_ARMOR_POINTS)
        {

        }

        public Robe(string name, int armorPoints)
        {
            base.Name = name;
            this.ArmorPoints = armorPoints;
        }
    }
}