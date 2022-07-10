using ObjectClasses.Armors;
using ObjectClasses.Weapons;

namespace ObjectClasses.Characters.MagicCharacters
{
    public class Mage : Character
    {
        private const string DEFAULT_NAME = "Mage";
        private readonly Robe DEFAULT_ARMOR = new Robe();
        private readonly Staff DEFAULT_WEAPON = new Staff();

        const int DEFAULT_HEALTH_POINTS = 100;
        const int DEFAULT_SPEED = 7;
        const int DEFAULT_MANA_POINTS = 100;

        private int healthPoints;
        private int speed;
        private int manaPoints;

        public override int HealthPoints
        {
            get => healthPoints;
            set
            {
                if (value > 125)
                {
                    System.Console.WriteLine("Mage's HP can't be more than 125");
                }
                else if (value < 0)
                {
                    healthPoints = 0;
                }
                else
                {
                    healthPoints = value;
                }
            }
        }
        public override int Speed
        {
            get => speed;
            set
            {
                if (value >= 6 && value <= 9)
                {
                    speed = value;
                }
                else
                {
                    System.Console.WriteLine("Mage's Speed needs to be between 1 and 4");
                }
            }
        }
        public override int AbilityPoints
        {
            get => manaPoints;
            set
            {
                if (value > 100)
                {
                    System.Console.WriteLine("Mage's MP can't be more than 100");
                }
                else if (value < 0)
                {
                    manaPoints = 0;
                }
                else
                {
                    manaPoints = value;
                }
            }
        }

        public Mage()
            : this(DEFAULT_NAME, DEFAULT_HEALTH_POINTS, DEFAULT_SPEED, DEFAULT_MANA_POINTS)
        {

        }

        public Mage(Robe robe, Staff staff)
            : this(DEFAULT_NAME, DEFAULT_HEALTH_POINTS, DEFAULT_SPEED, DEFAULT_MANA_POINTS)
        {
            base.BodyArmor = robe;
            base.CharWeapon = staff;
        }

        public Mage(string name, int healthPoints, int speed, int manaPoints)
            : base(name)
        {
            base.BodyArmor = DEFAULT_ARMOR;
            base.CharWeapon = DEFAULT_WEAPON;

            this.HealthPoints = healthPoints;
            this.Speed = speed;
            this.AbilityPoints = manaPoints;
        }

        public override string DefensiveSkill()
        {
            if (this.AbilityPoints >= 25)
            {
                base.NaturalArmor += 3;
                this.AbilityPoints -= 25;
                base.HasMoved = true;

                return this.Name + " used Skill Barrier, gains 3 Natural Armor\n";
            }
            else
            {
                return this.Name + " doesn't have enough AP to use skill\n";
            }
        }

        public override string SpecialSkill(Character opponent)
        {
            if (this.AbilityPoints >= 15)
            {
                int totalDamage = (base.CharWeapon.Damage * 7) / (opponent.BodyArmor.ArmorPoints + opponent.NaturalArmor);

                opponent.HealthPoints -= totalDamage;
                opponent.NaturalArmor = 0;

                this.AbilityPoints -= 15;
                base.HasMoved = true;

                return this.Name + " used Skill Lightning Bolt, deals " + totalDamage + " Damage\n";
            }
            else
            {
                return this.Name + " doesn't have enough AP to use skill\n";
            }
        }
    }
}