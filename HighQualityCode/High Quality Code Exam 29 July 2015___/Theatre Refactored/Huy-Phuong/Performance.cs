namespace TheatreManager
{
    using System;
    using System.Text;

    public class Performance
    {
        public Performance(string name, string theater, DateTime date, TimeSpan duration, decimal price)
        {
            this.Name = name;
            this.Theater = theater;
            this.Date = date;
            this.Duration = duration;
            this.Price = price;
        }

        public string Name { get; private set; }

        public string Theater { get; private set; }

        public DateTime Date { get; private set; }

        public TimeSpan Duration { get; private set; }

        public decimal Price { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("({0}, {1})", this.Name, this.Date.ToString("dd.MM.yyyy HH:mm"));

            return result.ToString();
        }
    }
}
