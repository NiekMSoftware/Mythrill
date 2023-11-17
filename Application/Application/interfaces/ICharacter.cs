namespace Application.interfaces
{
    public class ICharacter
    {
        protected string name { get; set; }
        public string Name { get { return name; } set { name = value; } }
    }
}