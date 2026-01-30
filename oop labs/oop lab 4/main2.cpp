#include <iostream>
#include <cstring>
using namespace std;

class Student
{
    long long int id;
    char name[50];
    double subject_marks[5];

public:
    void setId(long long int student_id)
    {
        id = student_id;
    }
    void setName(char *stdName)
    {
        strcpy(name, stdName);
    }
    void setMarks(double marks[])
    {
        for (int i = 0; i < 5 && i < 5; i++)
        {
            subject_marks[i] = marks[i];
        }
    }
    void displayInfo()
    {
        cout << "Student ID: " << id << endl;
        cout << "Student Name: " << name << endl;
        cout << "Subject Marks: ";
        for (int i = 0; i < 5; i++)
        {
            cout << subject_marks[i] << " ";
        }
        cout << endl;
    }

    Student () {
        id = 0;
        strcpy(name, "Unknown");
        for (int i = 0; i < 5; i++) {
            subject_marks[i] = 0.0;
        }
    };

    Student(long long int student_id, char *stdName, double marks[])
    {
        setId(student_id);
        setName(stdName);
        setMarks(marks);
    }
};