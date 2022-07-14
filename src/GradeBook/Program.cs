namespace GradeBook {
    class Program {
        static void Main(string[] args) {
            var book = new Book("Ricardo's GradeBook");
            
            while (true) {
                Console.WriteLine("Please enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q") {
                    break;
                }

                try {
                    var grade = double.Parse(input);
                    book.AddGrade(double.Parse(input));
                } catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}:");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
