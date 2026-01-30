#include <iostream>
using namespace std;

void calculateCharges(int carNumber, int hoursParked);

int main()
{
    int carNumber, hoursParked;

    while (true)
    {
        cout << "Enter car number (enter -1 to stop): ";
        cin >> carNumber;

        if (carNumber == -1)
            break;

        cout << "Enter hours parked: ";
        cin >> hoursParked;

        calculateCharges(carNumber, hoursParked);
    }

    return 0;
}

void calculateCharges(int carNumber, int hoursParked)
{
    cout << "===================================" << endl;
    double charges, tax;
    if (hoursParked <= 8)
    {
        charges = 25;
    }
    else if (hoursParked >= 24)
    {
        charges = (hoursParked / 24) * 50 + (hoursParked % 24) * 5;
    }
    else if (hoursParked > 72)
    {
        cout << "Error: Maximum parking time exceeded." << endl;
        return;
    }
    else
    {
        charges = 25 + (hoursParked - 8) * 5;
    }
    tax = hoursParked * 0.50;
    charges += tax;
    cout << "Car Number: "
         << carNumber << "\nHours Parked: " << hoursParked << " "
         << "\nCharges: $" << charges << endl;
};
