namespace GradeBook {

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject {
        public string Name { get; set; }

        public NamedObject(string name) {
            Name = name;
        }
    }

    public interface IBook {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; set; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook {

        public Book(string name) : base(name) {}

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }

    public class InMemoryBook : Book {
        private List<double> grades;
        const string CATEGORY = "Science";
        public override event GradeAddedDelegate GradeAdded;

        public InMemoryBook(string name) : base(name) {
            this.grades = new List<double>();
        }

        public override void AddGrade(double grade) {
            if (grade <= 100 && grade >= 0) {
                this.grades.Add(grade);
                if (this.GradeAdded != null) {
                    GradeAdded(this, new EventArgs());
                }
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

        public override Statistics GetStatistics() {
            var result = new Statistics();
            
            foreach(double number in this.grades) {
                result.Add(number);
            }

            return result;
        }
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt")) {
                writer.WriteLine(grade);
                if (this.GradeAdded != null) {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt")) {
                var line = reader.ReadLine();
                while (line != null) {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
}