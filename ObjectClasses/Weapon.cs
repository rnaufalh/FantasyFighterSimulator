namespace ObjectClasses
{
    public abstract class Weapon
    {
        private string name;

        public string Name
        {
            get =>name;
            set
            {
                name = value;
            }
        }
        public abstract int Damage { get; set; }

        public Weapon() { }
    }
}