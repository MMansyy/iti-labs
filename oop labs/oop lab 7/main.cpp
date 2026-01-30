#include <iostream>
#include <cstring>
using namespace std;

class Person
{
protected:
    int id;
    char name[50];

public:
    // Constructor
    Person(int pid, const char *pname) : id(pid)
    {
        strcpy(name, pname);
    }

    // getters & setters
    int getId() const
    {
        return id;
    }
    void setId(int pid)
    {
        id = pid;
    }
    const char *getName() const
    {
        return name;
    }
    void setName(const char *pname)
    {
        strcpy(name, pname);
    }

    // methods
    void display()
    {
        cout << "ID: " << id << ", Name: " << name << endl;
    }
};

class Employee : public Person
{
private:
    double salary;

public:
    // Constructor
    Employee(int pid, const char *pname, double psalary)
        : Person(pid, pname)
    {
        salary = psalary;
    }

    // getters & setters
    double getSalary() const
    {
        return salary;
    }
    void setSalary(double psalary)
    {
        salary = psalary;
    }

    // methods
    void display()
    {
        Person::display();
        cout << "Salary: " << salary << endl;
    }
};

class Customer : public Person
{
private:
    int productsPurchased;

public:
    // Constructor
    Customer(int pid, const char *pname, int pproductsPurchased)
        : Person(pid, pname)
    {
        productsPurchased = pproductsPurchased;
    }

    // getters & setters
    int getProductsPurchased() const
    {
        return productsPurchased;
    }
    void setProductsPurchased(int pproductsPurchased)
    {
        productsPurchased = pproductsPurchased;
    }
    // methods
    void display()
    {
        Person::display();
        cout << "Products Purchased: " << productsPurchased << endl;
    }
};


int main()
{
    Employee emp(1, "Alice", 50000);
    Customer cust(2, "Bob", 5);

    cout << "Employee Details:" << endl;
    emp.display();

    cout << "\nCustomer Details:" << endl;
    cust.display();

    return 0;
}