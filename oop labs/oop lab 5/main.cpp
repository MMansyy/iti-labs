#include <iostream>
#include <cstring>
using namespace std;

class Student
{
    int size;
    char *name;
    long long int id;
    double *subject_marks;

public:
    static int student_count;
    
    // ====== Setters / Getters ======
    void setId(long long int student_id)
    {
        id = student_id;
    }

    long long int getId()
    {
        return id;
    }

    void setName(const char *student_name)
    {
        strcpy(name, student_name);
    }

    char *getName()
    {
        return name;
    }

    void setMarks(double marks[], int marks_size)
    {
        for (int i = 0; i < marks_size; i++)
        {
            subject_marks[i] = marks[i];
        }
    }

    double *getMarks()
    {
        return subject_marks;
    }

    double getTotalMarks()
    {
        double total = 0;
        for (int i = 0; i < size; i++)
        {
            total += subject_marks[i];
        }
        return total;
    }

    void display()
    {
        cout << "Student ID: " << id << endl;
        cout << "Student Name: " << name << endl;
        cout << "Subject Marks: ";
        for (int i = 0; i < size; i++)
        {
            cout << subject_marks[i] << " ";
        }
        cout << "\nTotal Marks: " << getTotalMarks() << endl;
    }

    void input()
    {
        cout << "Enter Student ID: ";
        cin >> id;

        cout << "Enter Student Name: ";
        cin >> name;

        cout << "Enter marks for " << size << " subjects:\n";
        for (int i = 0; i < size; i++)
        {
            cout << "Subject " << (i + 1) << ": ";
            cin >> subject_marks[i];
        }
    }

    // ====== Constructors ======

    Student()
    {
        size = 5;
        id = 0;
        name = new char[100]{0};
        subject_marks = new double[size]{0};
        student_count++;
    }

    Student(const char *student_name)
    {
        size = 5;
        id = 0;
        name = new char[100];
        strcpy(name, student_name);
        subject_marks = new double[size];
        student_count++;
    }

    Student(long long int student_id, const char *student_name)
    {
        size = 5;
        id = student_id;
        name = new char[100];
        setName(student_name);
        subject_marks = new double[size];
        student_count++;
    }

    Student(long long int student_id, const char *student_name, double marks[], int marks_size)
    {
        size = marks_size;
        id = student_id;
        name = new char[100];
        setName(student_name);

        subject_marks = new double[size];
        for (int i = 0; i < size; i++)
        {
            subject_marks[i] = marks[i];
        }
        student_count++;
    }

    Student(const Student &other)
    {
        size = other.size;
        id = other.id;
        name = new char[100];
        strcpy(name, other.name);
        subject_marks = new double[size];
        for (int i = 0; i < size; i++)
        {
            subject_marks[i] = other.subject_marks[i];
        }
        student_count++;
    }

    ~Student()
    {
        delete[] name;
        delete[] subject_marks;
        student_count--;
    }

    // ====== Operators ======

    Student &operator=(const Student &other)
    {
        size = other.size;
        id = other.id;
        delete[] name;
        name = new char[strlen(other.name) + 1];
        strcpy(name, other.name);
        delete[] subject_marks;
        subject_marks = new double[size];
        for (int i = 0; i < size; i++)
        {
            subject_marks[i] = other.subject_marks[i];
        }
        return *this;
    }

    Student operator++(int)
    {
        Student temp = *this;
        size++;
        double *new_marks = new double[size];
        for (int i = 0; i < size - 1; i++)
        {
            new_marks[i] = subject_marks[i];
        }
        new_marks[size - 1] = 0;
        delete[] subject_marks;
        subject_marks = new_marks;
        return temp;
    }

    Student operator++()
    {
        id++;
        return *this;
    }

    bool operator==(Student &other)
    {
        return id == other.id;
    }

    Student operator+(Student &other)
    {
        Student temp = *this;
        strcat(temp.name, " ");
        strcat(temp.name, other.name);
        return temp;
    }

    Student operator+(int n)
    {
        Student temp = *this;
        int newSize = size + n;
        double *new_marks = new double[newSize];
        for (int i = 0; i < size; i++)
        {
            new_marks[i] = subject_marks[i];
        }
        for (int i = size; i < newSize; i++)
        {
            new_marks[i] = 0;
        }
        delete[] temp.subject_marks;
        temp.subject_marks = new_marks;
        temp.size = newSize;
        return temp;
    }

    Student operator+(const char *namee)
    {
        Student temp = *this;
        strcat(temp.name, namee);
        return temp;
    }

    operator int()
    {
        return id;
    }

    operator char *()
    {
        return name;
    }

    friend ostream &operator<<(ostream &cout, Student &st);
    friend Student operator+(int value, Student &st);
    friend Student operator+(const char *namee, Student &st);
};

ostream &operator<<(ostream &cout, Student &st)
{
    cout << "Student ID: " << st.id << endl;
    cout << "Student Name: " << st.name << endl;
    cout << "Subject Marks: ";
    for (int i = 0; i < st.size; i++)
    {
        cout << st.subject_marks[i] << " ";
    }
    cout << "\nTotal Marks: " << st.getTotalMarks() << endl;
    return cout;
}

Student operator+(int value, Student &st)
{
    return st + value;
}

Student operator+(const char *namee, Student &st)
{
    return st + namee;
}

int Student::student_count = 0;

int main()
{
    cout << "===== Testing Constructors and Operators =====\n";
    Student s1;
    cout << s1;
    cout << "----------------------------\n";

    Student s2("Ahmed");
    cout << s2;
    cout << "----------------------------\n";

    Student s3(12345, "Ali");
    cout << s3;
    cout << "----------------------------\n";

    double arr[] = {10.5, 20.5, 30.5, 40.5, 50.5};
    Student s4(99999, "Mostafa", arr, 5);
    cout << s4;
    cout << "----------------------------\n";

    Student s5 = s4;
    cout << s5;
    cout << "----------------------------\n";

    Student s6;
    s6 = s4;
    cout << s6;
    cout << "----------------------------\n";

    ++s6;
    cout << s6;
    cout << "----------------------------\n";

    s6++;
    cout << s6;
    cout << "----------------------------\n";

    Student fullName = s2 + s3;
    fullName.display();
    cout << "----------------------------\n";

    Student s7 = s2 + 3;
    s7.display();
    cout << "----------------------------\n";

    Student s8 = 5 + s2;
    s8.display();
    cout << "----------------------------\n";

    Student s9 = s2 + " Mohamed";
    s9.display();
    cout << "----------------------------\n";

    Student s10 = "Mr. " + s2;
    s10.display();
    cout << "----------------------------\n";

    if (s2 == s3)
        cout << "s2 == s3\n";
    else
        cout << "s2 != s3\n";

    cout << "----------------------------\n";

    int idValue = (int)s3;
    cout << "ID from casting: " << idValue << endl;
    cout << "----------------------------\n";

    char *nameValue = (char *)s2;
    cout << "Name from casting: " << nameValue << endl;
    cout << "----------------------------\n";

    double newMarks[] = {100, 90, 80, 70, 60};
    s2.setMarks(newMarks, 5);
    cout << "Updated s2 marks: ";
    double *marks = s2.getMarks();
    for (int i = 0; i < 5; i++)
        cout << marks[i] << " ";
    cout << "\n----------------------------\n";

    cout << "Total Students Created: " << Student::student_count << endl;

    cout << "\n----------------------------\n";

    return 0;
}

// {
//     int choice;
//     cout << "Choose input method:\n";
//     cout << "1. Single Student\n";
//     cout << "2. Fixed Number of Students (5)\n";
//     cout << "3. Dynamic Number of Students\n";
//     cout << "Enter choice: ";
//     cin >> choice;

//     if (choice == 1)
//     {
//         cout << "\n--- Enter Single Student ---\n";
//         Student s;
//         s.input();
//         cout << "\n--- Student Data ---\n";
//         s.display();

//         // Demonstrating the copy constructor
//         cout << "\n--- Copying Student Data ---\n";
//         Student copiedStudent = s;
//         copiedStudent.display();
//     }
//     else if (choice == 2)
//     {
//         cout << "\n--- Enter 5 Students ---\n";
//         Student students[5];

//         for (int i = 0; i < 5; i++)
//         {
//             cout << "\nStudent " << i + 1 << ":\n";
//             students[i].input();
//         }

//         cout << "\n--- Displaying Students ---\n";
//         for (int i = 0; i < 5; i++)
//         {
//             cout << "\nStudent " << i + 1 << ":\n";
//             students[i].display();
//         }
//     }
//     else if (choice == 3)
//     {
//         int n;
//         cout << "\nEnter number of students: ";
//         cin >> n;

//         Student *students = new Student[n];

//         for (int i = 0; i < n; i++)
//         {
//             cout << "\nStudent " << i + 1 << ":\n";
//             students[i].input();
//         }

//         cout << "\n--- Displaying Students ---\n";
//         for (int i = 0; i < n; i++)
//         {
//             cout << "\nStudent " << i + 1 << ":\n";
//             students[i].display();
//         }

//         delete[] students;
//     }
//     else
//     {
//         cout << "Invalid choice!\n";
//     }

//     return 0;
// }
