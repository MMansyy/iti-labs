#include <iostream>
#include <vector>
using namespace std;

int *bubbleSort(int arr[], int n)
{
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
    int *ptr = arr;
    return ptr;
};

void merge(int arr[], int start, int mid, int end)
{
    int n1 = mid - start + 1;
    int n2 = end - mid;
    int *left = new int[n1];
    int *right = new int[n2];

    for (int i = 0; i < n1; i++)
    {
        left[i] = arr[start + i];
    }

    for (int j = 0; j < n2; j++)
    {
        right[j] = arr[mid + 1 + j];
    }

    int i = 0, j = 0, k = start;
    while (i < n1 && j < n2)
    {
        if (left[i] <= right[j])
        {
            arr[k] = left[i];
            i++;
        }
        else
        {
            arr[k] = right[j];
            j++;
        }
        k++;
    }
    while (i < n1)
    {
        arr[k] = left[i];
        i++;
        k++;
    }
    while (j < n2)
    {
        arr[k] = right[j];
        j++;
        k++;
    }
    delete[] left;
    delete[] right;
}

void mergeSort(int arr[], int start, int end)
{
    if (start >= end)
    {
        return;
    }
    int mid = (start + end) / 2;
    mergeSort(arr, start, mid);
    mergeSort(arr, mid + 1, end);
    merge(arr, start, mid, end);
};

void swap(int &a, int &b)
{
    int temp = a;
    a = b;
    b = temp;
}

void quickSort(int arr[], int low, int high)
{
    if (low < high)
    {
        int pivot = arr[high];
        int i = (low - 1);
        for (int j = low; j <= high - 1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                swap(arr[i], arr[j]);
            }
        }
        swap(arr[i + 1], arr[high]);
        int pi = i + 1;

        quickSort(arr, low, pi - 1);
        quickSort(arr, pi + 1, high);
    }
}

void quickSort2(int arr[], int low, int high)
{
    if (low < high)
    {
        int pivot = arr[high];
        vector<int> less, greater;
        for (int i = low; i < high; i++)
        {
            if (arr[i] < pivot)
            {
                less.push_back(arr[i]);
            }
            else
            {
                greater.push_back(arr[i]);
            }
        }
        int index = low;
        for (int num : less)
        {
            arr[index++] = num;
        }
        arr[index++] = pivot;
        for (int num : greater)
        {
            arr[index++] = num;
        }
        quickSort2(arr, low, low + less.size() - 1);
        quickSort2(arr, low + less.size() + 1, high);
    }
}

int main()
{
    int arr1[] = {64, 34, 25, 12, 22, 11, 90};
    int n1 = sizeof(arr1) / sizeof(arr1[0]);
    int *sortedArr1 = bubbleSort(arr1, n1);
    cout << "Sorted array using Bubble Sort: ";
    for (int i = 0; i < n1; i++)
    {
        cout << sortedArr1[i] << " ";
    }
    cout << endl;

    int arr2[] = {38, 27, 43, 3, 9, 82, 10};
    int n2 = sizeof(arr2) / sizeof(arr2[0]);
    mergeSort(arr2, 0, n2 - 1);
    cout << "Sorted array using Merge Sort: ";
    for (int i = 0; i < n2; i++)
    {
        cout << arr2[i] << " ";
    }
    cout << endl;

    int arr3[] = {10, 7, 8, 9, 1, 5};
    int n3 = sizeof(arr3) / sizeof(arr3[0]);
    quickSort(arr3, 0, n3 - 1);
    cout << "Sorted array using Quick Sort: ";
    for (int i = 0; i < n3; i++)
    {
        cout << arr3[i] << " ";
    }
    cout << endl;

    return 0;
}