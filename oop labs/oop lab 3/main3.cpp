#include <iostream>
#include <cctype>
using namespace std;

int main()
{
    char c[100];
    cout << "Enter a string: ";
    cin.getline(c, 100);
    for (int i = 0; c[i] != '\0'; ++i)
    {
        if (isalpha(c[i]))
        {
            if (i % 2 == 0)
            {
                c[i] = toupper(c[i]);
            }
            else
            {
                c[i] = tolower(c[i]);
            }
        }
    }
    cout << "string: " << c << endl;
    return 0;
}