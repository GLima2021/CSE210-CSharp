using System;

class Program
{
    static void Main(string[] args)
    {
    // Tell the por%
    Console.WriteLine ("Enter your percentage grade:");
    int percentageGrade = Convert.ToInt32(Console.ReadLine());

    // Tell the note score
    string letterGrade;
    if (percentageGrade >= 90) {
      letterGrade = "A";
    } else if (percentageGrade >= 80) {
      letterGrade = "B";
    } else if (percentageGrade >= 70) {
      letterGrade = "C";
    } else if (percentageGrade >= 60) {
      letterGrade = "D";
    } else {
      letterGrade = "F";
    }

    // Tell if the user is approved
    bool passed = percentageGrade >= 70;

    // Tell the lyric note
    Console.Write("Your letter grade is: " + letterGrade);

    // Tell (+ ou -) if necessary
    int lastDigit = percentageGrade % 10;
    string sign = "";
    if ((lastDigit >= 7 && letterGrade != "F") || (lastDigit < 3 && letterGrade != "A")) {
      sign = "+";
    } else if (lastDigit < 7 && lastDigit >= 3 && letterGrade != "F") {
      sign = "-";
    }

    // Tell the last note
    if (letterGrade != "A" && letterGrade != "F") {
      Console.WriteLine(sign);
    } else {
      if (letterGrade == "A" && sign == "+") {
        Console.WriteLine("-");
      } else if (letterGrade == "F" && sign != "") {
        Console.WriteLine("");
      }
    }

    // Message appoved
    if (passed) {
      Console.WriteLine("Congratulations! You passed the course.");
    } else {
      Console.WriteLine("Better luck next time!");
    }

    }
}