#include <iostream>
#include <cstring>
using namespace std;

struct node
{
    int data;
    node *next;
};

class Stack
{
    node *top;

public:
    Stack()
    {
        top = nullptr;
    }
    void push(int x)
    {
        node *newNode = new node();
        if (!newNode)
        {
            cout << "Stack Overflow" << endl;
            return;
        }
        newNode->data = x;
        newNode->next = top;
        top = newNode;
    }

    node *pop()
    {
        if (top == nullptr)
        {
            cout << "Stack Underflow" << endl;
            return nullptr;
        }
        node *ptr = top;
        top = ptr->next;
        ptr->next = nullptr;
        return ptr;
    };
};

class Queue
{
    int front, rear;
    int arr[10] = {0};

public:
    Queue()
    {
        front = -1;
        rear = -1;
    }
    int enqueue(int x)
    {
        if (rear >= 9)
        {
            cout << "Queue Overflow" << endl;
            return -1;
        }
        else
        {
            if (front == -1)
            {
                front++;
            }
            arr[++rear] = x;
            return 0;
        }
    };

    int dequeue()
    {
        if (front == -1 || front > rear)
        {
            cout << "Queue Underflow" << endl;
            return -1;
        }
        else
        {
            return arr[front++];
        }
    };

    void display()
    {
        if (front == -1 || front > rear)
        {
            cout << "Queue is empty" << endl;
            return;
        }
        for (int i = front; i <= rear; i++)
        {
            cout << arr[i] << " ";
        }
    };
};

int main()
{
    Stack s;
    Queue q;

    s.push(10);
    s.push(20);
    s.push(30);
    cout << "Stack contents: ";
    s.display();
    cout << endl;

    cout << "Popped from stack: " << s.pop() << endl;
    cout << "Stack contents after pop: ";
    s.display();
    cout << endl;

    q.enqueue(100);
    q.enqueue(200);
    q.enqueue(300);
    cout << "Queue contents: ";
    q.display();
    cout << endl;

    cout << "Dequeued from queue: " << q.dequeue() << endl;
    cout << "Queue contents after dequeue: ";
    q.display();
    cout << endl;

    return 0;
}