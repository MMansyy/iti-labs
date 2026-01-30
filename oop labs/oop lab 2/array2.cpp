#include <iostream>
using namespace std;

int main()
{
    int arr1[10], arr2[10];

    for (int i = 0; i < 10; i++)
        cin >> arr1[i];

    for (int i = 0; i < 10; i++)
        cin >> arr2[i];

    cout << "Common Unique Elements: ";

    for (int i = 0; i < 10; i++)
    {
        bool foundInArr2 = false;
        for (int j = 0; j < 10; j++)
        {
            if (arr1[i] == arr2[j])
            {
                foundInArr2 = true;
                break;
            }
        }

        if (foundInArr2)
        {
            bool isUnique = true;
            for (int k = 0; k < i; k++)
            {
                if (arr1[i] == arr1[k])
                {
                    isUnique = false;
                    break;
                }
            }

            if (isUnique)
                cout << arr1[i] << " ";
        }
    }

    return 0;
}
