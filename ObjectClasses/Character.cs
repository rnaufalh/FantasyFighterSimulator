namespace ObjectClasses
{
    public abstract class Character
    {
        // Before creating specific class for each Job, create two namespaces for MagicCharacter and NormalCharacter
        // MagicCharacter will have ManaPoints for their abilities
        // NormalCharacter will have Stamina for their abilities

        private string name;
        private int naturalArmor;
        private Armor bodyArmor;
        private Weapon charWeapon;
        private bool hasMoved;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int NaturalArmor
        {
            get => naturalArmor;
            set
            {
                naturalArmor = value;
            }
        }

        public abstract int HealthPoints { get; set; }
        public abstract int Speed { get; set; }
        public abstract int AbilityPoints { get; set; }

        public Armor BodyArmor
        {
            get
            {
                return bodyArmor;
            }
            set
            {
                bodyArmor = value;
            }
        }

        public Weapon CharWeapon
        {
            get
            {
                return charWeapon;
            }
            set
            {
                charWeapon = value;
            }
        }

        // Property to indicate if the character has moved or not (e.g. using spells when MP is enough)
        public bool HasMoved {
            get
            {
                return hasMoved;
            }
            set
            {
                hasMoved = value;
            }
        }

        public Character(string name)
        {
            this.Name = name;
            this.NaturalArmor = 0;
            this.hasMoved = false;
        }

        public string NormalAttack(Character opponent)
        {
            int totalDamage = this.CharWeapon.Damage / (opponent.BodyArmor.ArmorPoints + opponent.NaturalArmor);

            opponent.HealthPoints -= totalDamage;
            opponent.NaturalArmor = 0;

            this.HasMoved = true;

            return this.Name + " Attacks " + opponent.Name + " with " + this.CharWeapon.Name + ", deals " + totalDamage + " Damage\n";
        }
        public abstract string SpecialSkill(Character opponent);
        public abstract string DefensiveSkill();

    }
}