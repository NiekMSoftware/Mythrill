namespace Application.interfaces
{
    public class ICharacter
    {
        private string name { get; set; }
        public string Name { get { return name; } set { name = value; } }
    }
}