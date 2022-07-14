namespace GradeBook {
    public class Book {
        private List<double> grades;
        public string Name { get; set; }
        const string CATEGORY = "Science";

        public Book(string name) {
            this.Name = name;
            this.grades = new List<double>();
        }

        public void AddGrade(double grade) {
            if (grade <= 100 && grade >= 0) {
                this.grades.Add(grade);
            }
            else {
                throw new ArgumentException("Invalid grade");
            }
        }

        public void AddGrade(char letter) {
            switch(letter) {
                case 'A':
                    this.AddGrade(90);
                    break;
                case 'B':
                    this.AddGrade(80);
                    break;
                case 'C':
                    this.AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public Statistics GetStatistics() {
            var result = new Statistics();
            var sum = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            foreach(double number in this.grades) {
                sum += number;
                result.High = Math.Max(number, result.High);
                result.Low = Math.Min(number, result.Low);
            }
            result.Average = sum / grades.Count;

            switch(result.Average) {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }
            return result;
        }
    }
}