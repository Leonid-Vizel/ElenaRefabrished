namespace SchoolWeb.Attributes
{
    public class ResultAttribute : Attribute
    {
        public string Name { get; private set; }

        public ResultAttribute(string name)
        {
            Name = name;
        }
    }
}
