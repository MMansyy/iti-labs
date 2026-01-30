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

    void input()
    {
        cout << "Enter Student ID: ";
        cin >> id;

        cout << "Enter Student Name: ";
        cin >> name;

        cout << "Enter marks for 5 subjects:\n";
        for (int i = 0; i < 5; i++)
        {
            cout << "Subject " << (i + 1) << ": ";
            cin >> subject_marks[i];
        }
    }

    Student()
    {
        id = 0;
        strcpy(name, "Unknown");
        for (int i = 0; i < 5; i++)
        {
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

int main()
{
    Student s1;
    s1.input();
    cout << "\nStudent Information:\n";
    s1.displayInfo();

    // edit data 
    int new_id;
    cout << "\nEnter new Student ID to update: ";
    cin >> new_id;
    s1.setId(new_id);
    s1.displayInfo();

    char name[] = "Alice";
    double marks[5] = {85.5, 90.0, 78.5, 88.0, 92.0};
    Student s2(1001, name, marks);
    cout << "\nStudent Information (Parameterized Constructor):\n";
    s2.displayInfo();

    return 0;
};