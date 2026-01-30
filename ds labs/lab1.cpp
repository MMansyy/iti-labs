#include <iostream>
#include <cstring>
using namespace std;

struct student
{
    int id;
    char name[50];
};

struct node
{
    student data;
    node *next;
    node *prev;
};

class LinkedList
{
    node *head;
    node *tail;

public:
    LinkedList()
    {
        head = nullptr;
        tail = nullptr;
    }

    void addStudent(int id, const char *name)
    {
        node *newNode = new node;
        if (!newNode)
        {
            cout << "Memory allocation failed" << endl;
            return;
        }
        newNode->data.id = id;
        strcpy(newNode->data.name, name);
        if (head == nullptr)
        {
            head = newNode;
            tail = newNode;
            newNode->next = nullptr;
            newNode->prev = nullptr;
        }
        else
        {
            tail->next = newNode;
            newNode->prev = tail;
            newNode->next = nullptr;
            tail = newNode;
        }
    }

    void insertStudentAt(int position, int id, const char *name)
    {
        node *newNode = new node;
        if (!newNode)
        {
            cout << "Memory allocation failed" << endl;
            return;
        }
        newNode->data.id = id;
        strcpy(newNode->data.name, name);
        if (position == 0)
        {
            newNode->next = head;
            newNode->prev = nullptr;
            if (head != nullptr)
            {
                head->prev = newNode;
            }
            head = newNode;
            if (tail == nullptr)
            {
                tail = newNode;
            }
        }
        else
        {
            node *current = head;
            for (int i = 0; i < position - 1 && current != nullptr; i++)
            {
                current = current->next;
            }
            if (current == nullptr)
            {
                cout << "Position out of bounds" << endl;
                delete newNode;
                return;
            }
            newNode->next = current->next;
            newNode->prev = current;
            current->next->prev = newNode;
            current->next = newNode;
            if (newNode->next == nullptr)
            {
                tail = newNode;
            }
        }
    };

    void searchStudentById(int id)
    {
        node *current = head;
        while (current != nullptr)
        {
            if (current->data.id == id)
            {
                cout << "Student found: ID: " << current->data.id << ", Name: " << current->data.name << endl;
                return;
            }
            current = current->next;
        }
        cout << "Student with ID " << id << " not found." << endl;
    };

    void displayStudents()
    {
        node *current = head;
        while (current != nullptr)
        {
            cout << "ID: " << current->data.id << ", Name: " << current->data.name << endl;
            current = current->next;
        }
    };
};

int main()
{
    LinkedList list;
    list.addStudent(1, "Ahmed");
    list.addStudent(2, "Mohamed");
    list.addStudent(3, "Ali");
    cout << "All students:" << endl;
    list.displayStudents();
    cout << endl;

    list.insertStudentAt(1, 4, "Omar");
    cout << "After inserting at position 1:" << endl;
    list.displayStudents();
    cout << endl;
    
    list.searchStudentById(2);
    list.searchStudentById(10);
    return 0;
}
