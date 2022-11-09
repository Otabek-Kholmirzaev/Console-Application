using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

public class Program
{
    public static void Main()
    {
        IList<Student> studentList1 = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
            new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Steve" , Age = 15 }
        };

        IList<Student> studentList2 = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
            new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Steve" , Age = 15 }
        };

        /*var studentWithLongName = studentList.Max(new StudentComparer());

        Console.WriteLine("Student ID: {0}, Student Name: {1}", studentWithLongName.StudentID, studentWithLongName.StudentName);
        */

        //Console.WriteLine(studentList.SingleOrDefault()?.StudentID);

        bool isTrue = studentList1.SequenceEqual(studentList2, new StudentEqualityComparer());

        Console.WriteLine(isTrue);
    }
}

public class StudentEqualityComparer : IEqualityComparer<Student>
{
    public bool Equals(Student? x, Student? y)
    {
        if (x.StudentID == y.StudentID && x.StudentName == y.StudentName && x.StandardID == y.StandardID)
            return true;

        return false;
    }

    public int GetHashCode([DisallowNull] Student obj)
    {
        return obj.GetHashCode();
    }
}


public class Student 
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
    public int StandardID { get; set; }
}

public class StudentComparer : IComparer<Student>
{
    public int Compare(Student? s1, Student? s2)
    {
        if (s1.StudentName.Length >= s2.StudentName.Length)
            return 1;

        return 0;
    }
}