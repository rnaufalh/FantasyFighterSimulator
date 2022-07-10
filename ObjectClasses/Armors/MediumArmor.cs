namespace ObjectClasses.Armors
{
    public class MediumArmor : Armor
    {
        const string DEFAULT_NAME = "Simple Medium Armor";
        const int DEFAULT_ARMOR_POINTS = 4;
        private int armorPoints;

        public override int ArmorPoints
        {
            get
            {
                return armorPoints;
            }
            set
            {
                if (value > 4)
                {
                    System.Console.WriteLine("Medium Armor's AP can't be more than 4");
                }
                else if (value < 3)
                {
                    System.Console.WriteLine("Medium Armor's AP can't be less than 3");
                }
                else
                {
                    armorPoints = value;
                }
            }
        }

        public MediumArmor()
            : this(DEFAULT_NAME, DEFAULT_ARMOR_POINTS)
        {

        }

        public MediumArmor(string name, int armorPoints)
        {
            base.Name = name;
            this.ArmorPoints = armorPoints;
        }
    }
}