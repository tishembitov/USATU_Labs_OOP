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
    Section *s = new Section();
    storage.insertAtEnd(s);
	// обращаемся поочередно ко всем
    for (int i = 0; i < storage.getLength(); i++)
    {
        printf("объект под номером %d:", i);
        storage.operator[](i).show();
    }
    printf("Количество объектов в хранилище до удаления:%d\n", storage.getLength());
    storage.remove(5);
    printf("\nКоличество объектов в хранилище после удаления:%d", storage.getLength());
	return 0;
}