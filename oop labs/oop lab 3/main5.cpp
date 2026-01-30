#include <iostream>
#include <string>
#include <conio.h>
#include <cctype>
using namespace std;

int main()
{
    int initial_size = 0;
    cout << "Enter the size you want for the line: ";
    cin >> initial_size;

    int capacity = initial_size;
    char *line = new char[capacity + 1];

    int length = 0;
    int cursor = 0;

    cout << "Enter a line of text : ";

    while (true)
    {
        char ch = _getch();

        if (ch == 13)
        { // Enter key
            line[length] = '\0';
            break;
        }
        else if (ch == 27)
        { // ESC key
            cout << "\nProgram terminated by ESC.\n";
            delete[] line;
            return 0;
        }
        else if (ch == 8)
        { // Backspace key
            if (cursor > 0)
            {
                // Shift characters to the left
                for (int i = cursor - 1; i < length - 1; i++)
                {
                    line[i] = line[i + 1];
                }
                cursor--;
                length--;
                cout << "\b \b";
            }
        }
        else if (ch == 0 || ch == 224)
        { // Special keys (arrows, Home, End)
            char ch2 = _getch();

            if (ch2 == 75)
            { // Left arrow
                if (cursor > 0)
                {
                    cursor--;
                    cout << "\b";
                }
            }
            else if (ch2 == 77)
            { // Right arrow
                if (cursor < length)
                {
                    cout << line[cursor];
                    cursor++;
                }
            }
            else if (ch2 == 71)
            { // Home key
                while (cursor > 0)
                {
                    cout << "\b";
                    cursor--;
                }
            }
            else if (ch2 == 79)
            { // End key
                while (cursor < length)
                {
                    cout << line[cursor];
                    cursor++;
                }
            }
        }
        else if (isprint(ch))
        {
            if (length < capacity)
            {
                if (cursor < length)
                {
                    for (int i = length; i > cursor; i--)
                    {
                        line[i] = line[i - 1];
                    }
                }

                line[cursor] = ch;
                cout << ch;
                cursor++;
                length++;
            }
        }
    }

    cout << "\nYou entered: " << line << endl;

    delete[] line;
    return 0;
}
