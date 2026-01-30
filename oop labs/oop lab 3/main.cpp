#include <iostream>
using namespace std;

int main()
{
    const int row = 5;
    const int col = 6;
    double matrix[row][col] = {0};
    int salesperson, product;
    double value;
    while (true)
    {
        cout << "Enter salesperson number (1-4) or -1 to end." << endl;
        cin >> salesperson;
        if (salesperson == -1)
        {
            break;
        }
        cout << "Enter product number (1-5)." << endl;
        cin >> product;
        cout << "Enter total value." << endl;
        cin >> value;
        if (salesperson < 1 || salesperson > 4 || product < 1 || product > 5 || value < 0)
        {
            cout << "Invalid input. Please try again." << endl;
            continue;
        }
        matrix[salesperson - 1][product - 1] = value;
    }
    // Calculate totals for each salesperson
    for (int i = 0; i < row - 1; ++i)
    {
        for (int j = 0; j < col - 1; ++j)
        {
            matrix[i][col-1] += matrix[i][j];
        }
    }
    // Calculate totals for each product
    for (int j = 0; j < col - 1; ++j)
    {
        for (int i = 0; i < row - 1; ++i)
        {
            matrix[row-1][j] += matrix[i][j];
        }
    }
    // Calculate total
    for (int i = 0; i < row - 1; ++i)
    {
        matrix[row-1][col-1] += matrix[i][col-1];
    }

    // Display the output
    cout << "\tProduct 1\tProduct 2\tProduct 3\tProduct 4\tProduct 5\tTotal" << endl;
    for (int i = 0; i < row; ++i)
    {
        if (i < row - 1)
        {
            cout << "Person " << (i + 1) << "\t";
        }
        else
        {
            cout << "Total\t\t";
        }
        for (int j = 0; j < col; ++j)
        {
            cout << matrix[i][j] << "\t\t";
        }
        cout << endl;
    }
    return 0;

}