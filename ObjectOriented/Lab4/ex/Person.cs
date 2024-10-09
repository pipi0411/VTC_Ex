using System;

namespace QuanLyTruongHoc
{
    // Lớp trừu tượng Person
    public abstract class Person
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        protected Person(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        // Phương thức trừu tượng
        public abstract void Display();
    }
}
    