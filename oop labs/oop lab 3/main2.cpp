#include <iostream>
using namespace std;

int main()
{
    const int students = 3;
    const int subjects = 4;
    double marks[students][subjects] = {0};
    int studentID, subjectID;
    double score;
    while (true)
    {
        cout << "Enter student ID (1-3) or -1 to end." << endl;
        cin >> studentID;
        if (studentID == -1)
        {
            break;
        }
        cout << "Enter subject ID (1-4)." << endl;
        cin >> subjectID;
        cout << "Enter score." << endl;
        cin >> score;
        if (studentID < 1 || studentID > 3 || subjectID < 1 || subjectID > 4 || score < 0)
        {
            cout << "Invalid input. Please try again." << endl;
            continue;
        }
        marks[studentID - 1][subjectID - 1] = score;
    }

    double HighestStudent[2] = {0};
    for (int i = 0; i < students; ++i)
    {
        double total = 0;
        cout << "Student " << (i + 1) << " scores: ";
        for (int j = 0; j < subjects; ++j)
        {
            cout << marks[i][j] << "\t";
            total += marks[i][j];
        }
        cout << "Total: " << total;
        if (total > HighestStudent[0])
        {
            HighestStudent[0] = total;
            HighestStudent[1] = i + 1;
        }
        cout << endl;
    }
    for (int j = 0; j < subjects; ++j)
    {
        double SubjectAvg = 0;
        for (int i = 0; i < students; ++i)
        {
            SubjectAvg += marks[i][j];
        }
        cout << "Avg score for Subject " << (j + 1) << ": " << SubjectAvg / 3 << endl;
    }
    cout << "Highest scoring student is Student " << HighestStudent[1] << " with a total score of " << HighestStudent[0] << "." << endl;

    return 0;
}