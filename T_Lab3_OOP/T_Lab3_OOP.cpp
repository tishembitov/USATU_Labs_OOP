#include <iostream>
#include "Storage.h"
using namespace std;

class Shape
{
public:
    Shape() { };
    virtual void show() 
    {
        cout << "Фигура " << endl;
    }
    ~Shape() 
    {
        cout << "Фигура удалилась" << endl;
    }
};
class Point :public Shape 
{
private:
    int x, y;
public:
    Point() 
    {
        x = 0;
        y = 0;
    }
    virtual void show()  override
    {
        cout << "Точка" << endl;
    }
    ~Point() 
    {
        cout << "Точка удалилась" << endl;
    }
};
class Section :public Shape 
{
private:
    Point* p1, * p2;
    int x1, x2, y1, y2;
public:
    Section() 
    {
        p1 = new Point();
        p2 = new Point();
        x1 = x2 = y1 = y2 = 0;
    }
    ~Section() 
    {
        cout << "Отрезок удалился" << endl;
        delete p1;
        delete p2;
    }
    virtual void show()  override
    {
        cout << "Отрезок" << endl;
    }
};
int main()
{
    setlocale(LC_ALL, "Rus");
    Storage <Shape> storage(10);
    // добавляем в него объекты
    for (int i = 0; i < storage.getLength(); i++)
        storage.setObject(new Point(), i);
    Section* s = new Section();
    storage.insertAtEnd(s);
    // обращаемся поочередно ко всем
    for (int i = 0; i < storage.getLength(); i++)
    {
        printf("объект с номером %d:", i);
        storage.operator[](i).show();
    }
    printf("Количество объектов в хранилище до удаления:%d\n", storage.getLength());
    storage.remove(5);
    printf("Количество объектов в хранилище после удаления:%d\n", storage.getLength());
    srand(time(NULL));
    printf("\nвызов случайных методов хранилища\n\n");
    for (int i = 0; i < 10; i++)
    {
        int control = rand() % 8 + 1;
        switch (control)
        {
        case 1:
            if (storage.getLength() > 0)
            storage.setObject(new Point(), storage.getLength()-1);
            break;
        case 2:
            printf("Количество объектов в хранилище:%d\n", storage.getLength());
            break;
        case 3:
            storage.reallocate(20);
            break;
        case 4:
            storage.resize(storage.getLength() + 5);
            break;
        case 5:
            if (storage.getLength() > 0)
            storage.insertBefore(new Point(), storage.getLength()-1);
            break;
        case 6:
            if (storage.getLength() > 0)
            storage.remove(storage.getLength()-1);
            break;
        case 7:
            if (storage.getLength() > 0)
            storage.insertAtBeginning(new Point());
                break;
        case 8:
            if (storage.getLength() > 0)
            storage.insertAtEnd(new Point());
            break;
        }
    }
    return 0;
}