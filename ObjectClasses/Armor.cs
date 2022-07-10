namespace ObjectClasses
{
    public abstract class Armor
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        public abstract int ArmorPoints { get; set; }

        public Armor() { }
    }
}