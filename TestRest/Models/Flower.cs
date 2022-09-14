namespace TestRest.Models
{
    public class Flower
    {
        public int Id { get; set; }
        public string? Species { get; set; }
        public string? Color { get; set; }
        public int Height { get; set; }

        public void ValidateColor()
        {
            if (Color == null)
            {
                throw new ArgumentNullException("You need to type color");
            }
            else if (Color.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Color name is too long");
            }
            else if (Color.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Color name is too short");
            }
        }

        public void Validate()
        {
            ValidateColor();
        }
    }
}
