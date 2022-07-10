using ObjectClasses.Armors;
using ObjectClasses.Weapons;
using System.Web.UI.WebControls;

namespace ObjectClasses.Characters.NormalCharacters
{
    public class Warrior : Character
    {
        private const string DEFAULT_NAME = "Warrior";
        private readonly MediumArmor DEFAULT_ARMOR = new MediumArmor();
        private readonly Axe DEFAULT_WEAPON = new Axe();

        const int DEFAULT_HEALTH_POINTS = 200;
        const int DEFAULT_SPEED = 6;
        const int DEFAULT_STAMINA_POINTS = 50;

        private int healthPoints;
        private int speed;
        private int staminaPoints;

        public override int HealthPoints
        {
            get
            {
                return healthPoints;
            }
            set
            {
                if (value > 200)
                {
                    System.Console.WriteLine("Warrior's HP can't be more than 200");
                }
                else if (value < 0)     // To indicate that the health points have been depleted
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
            get
            {
                return speed;
            }
            set
            {
                if (value >= 5 && value <= 7)
                {
                    speed = value;
                }
                else
                {
                    System.Console.WriteLine("Warrior's Speed needs to be between 5 and 7");
                }
            }
        }

        public override int AbilityPoints
        {
            get
            {
                return staminaPoints;
            }
            set
            {
                if (value > 50)
                {
                    System.Console.WriteLine("Warrior's SP can't be more than 50");
                }
                else if (value < 0)     // To indicate that the stamina/mana points have been depleted
                {
                    staminaPoints = 0;
                }
                else
                {
                    staminaPoints = value;
                }
            }
        }

        public Warrior()
            : this(DEFAULT_NAME, DEFAULT_HEALTH_POINTS, DEFAULT_SPEED, DEFAULT_STAMINA_POINTS)
        {

        }

        public Warrior(MediumArmor mediumArmor, Axe axe)
            : this(DEFAULT_NAME, DEFAULT_HEALTH_POINTS, DEFAULT_SPEED, DEFAULT_STAMINA_POINTS)
        {
            base.BodyArmor = mediumArmor;
            base.CharWeapon = axe;
        }

        public Warrior(string name, int healthPoints, int speed, int staminaPoints)
            : base(name)
        {
            base.BodyArmor = DEFAULT_ARMOR;
            base.CharWeapon = DEFAULT_WEAPON;

            this.HealthPoints = healthPoints;
            this.Speed = speed;
            this.AbilityPoints = staminaPoints;
        }

        public override string SpecialSkill(Character opponent)
        {
            if (this.AbilityPoints >= 10)
            {
                int totalDamage = (base.CharWeapon.Damage * 2) / (opponent.BodyArmor.ArmorPoints + opponent.NaturalArmor);

                opponent.HealthPoints -= totalDamage;
                opponent.NaturalArmor = 0;

                this.AbilityPoints -= 10;
                base.HasMoved = true;

                return this.Name + " used Skill Mighty Blow, deals " + totalDamage + " Damage\n";
            }
            else
            {
                return this.Name + " doesn't have enough AP to use skill\n";
            }
        }

        public override string DefensiveSkill()
        {
            if (this.AbilityPoints >= 10)
            {
                base.NaturalArmor += 1;
                this.AbilityPoints -= 10;
                base.HasMoved = true;

                return this.Name + " used Skill Guard, gains 1 Natural Armor\n";
            }
            else
            {
                return this.Name + " doesn't have enough AP to use skill\n";
            }
        }
    }
}