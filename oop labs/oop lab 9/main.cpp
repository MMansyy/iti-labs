#include <iostream>
#include <fstream>
#include <string>
using namespace std;


int txtFile();
int binaryFile();

int main()
{
    int choice;
    cout << "Choose file type to work with:\n1. Text File\n2. Binary File\nEnter choice (1 or 2): ";
    cin >> choice;
    if (choice == 1)
    {
        txtFile();
    }
    else if (choice == 2)
    {
        binaryFile();
    }
    else
    {
        cout << "Invalid choice!" << endl;
    }
    return 0;
}

int txtFile()
{
    // Create and write to a text file
    fstream obj;
    obj.open("text.txt", ios::out);
    if (!obj)
    {
        cout << "Error creating file!" << endl;
        return 1;
    }
    obj << "Hello, World!" << endl;
    obj.close();

    // Read from the text file
    obj.open("text.txt", ios::in);
    if (!obj)
    {
        cout << "Error opening file!" << endl;
        return 1;
    }
    string line;
    while (getline(obj, line))
    {
        cout << line << endl;
    }
    obj.close();
    return 0;
};

int binaryFile()
{
    // Create and write to a binary file
    fstream obj;
    obj.open("binary.bin", ios::out | ios::binary);
    if (!obj)
    {
        cout << "Error creating binary file!" << endl;
        return 1;
    }
    int number = 42;
    obj.write((char*)(&number), sizeof(number));
    obj.close();    

    // Read from the binary file
    obj.open("binary.bin", ios::in | ios::binary);
    if (!obj)
    {
        cout << "Error opening binary file!" << endl;
        return 1;
    }
    int readNumber;
    obj.read((char*)(&readNumber), sizeof(readNumber));
    cout << "Read number: " << readNumber << endl;
    obj.close();
    return 0;
}