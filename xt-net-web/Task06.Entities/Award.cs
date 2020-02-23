namespace Task06.Entities
{
    public class Award
    {
        public int Id
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public string ImageSource
        {
            get; set;
        } = null;

        public override string ToString()
        {
            return $"{Id}, {Title}";
        }
    }
}