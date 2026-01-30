#include <iostream>
using namespace std;

struct Student
{
    long long int id;
    char name[50];
    double subject_marks[5];
};

double sum(Student s);
void display(Student s);
void input(Student &s);

int main()
{
    int choice;
    cout << "Student Management System\n";
    cout << "1. Input one student\n";
    cout << "2. Input 5 students\n";
    cout << "3. Input dynamic number of students\n";
    cout << "Enter your choice (1-3): ";
    cin >> choice;

    switch (choice)
    {
    case 1:
    {
        // only for single student
        Student s1;
        input(s1);
        display(s1);
        break;
    }
    case 2:
    {
        // for 5 students
        Student s2[5];
        for (int i = 0; i < 5; i++)
        {
            cout << "Enter details for student " << (i + 1) << ":\n";
            input(s2[i]);
        }
        cout << "\nStudent Details:\n";
        for (int i = 0; i < 5; i++)
        {
            display(s2[i]);
        }
        break;
    }
    case 3:
    {
        // for dynamic number of students
        int n;
        cout << "Enter number of students: ";
        cin >> n;
        Student *s3 = new Student[n];
        for (int i = 0; i < n; i++)
        {
            cout << "Enter details for student " << (i + 1) << ":\n";
            input(s3[i]);
        }
        cout << "\nStudent Details:\n";
        for (int i = 0; i < n; i++)
        {
            display(s3[i]);
        }
        delete[] s3;
        break;
    }
    default:
        cout << "Invalid choice!" << endl;
        break;
    }

    return 0;
}

double sum(Student s)
{
    double total = 0;
    for (int i = 0; i < 5; i++)
    {
        total += s.subject_marks[i];
    }
    return total;
};
void display(Student s)
{
    cout << "ID: " << s.id << ", Name: " << s.name << ", Total: " << sum(s) << endl;
};
void input(Student &s)
{
    cout << "Enter ID: ";
    cin >> s.id;
    cout << "Enter Name: ";
    cin >> s.name;
    cout << "Enter marks for 5 subjects:\n ";
    for (int i = 0; i < 5; i++)
    {
        cout << "Subject " << (i + 1) << ": ";
        cin >> s.subject_marks[i];
    }
};
