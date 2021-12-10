#include "pch.h"
#include <iostream>
#include "Point.h"
#include "Circle.h"
#include "pch.h"
#include <iostream>
#include <stdio.h>
#include <conio.h>
#include <windows.h>
#include "Point.h"
#include "Cylinder.h"
#include "Scope.h"
#include "LinkedList.h"
#include <time.h>

using namespace std;

void func1(Point obj)
{
	cout << "вызвана func1(Point obj)" << endl;
	cout << "Адрес объекта в func1 :" << &obj << endl;
	cout << "Вызов obj.SetX(100)" << endl;
	obj.SetX(100);

}

void func2(const Point& obj)
{
	cout << "вызвана func2(const Point & obj)" << endl;
	cout << "Адрес объекта в func2 : " << &obj << endl;
	cout << "Вызов obj.SetX() невозможен" << endl;
	Point::funcc(&obj);
	//obj.SetX(100);

}

void func3(Point* obj)
{
	cout << "вызвана func3(Point * obj)" << endl;
	cout << "Адрес объекта в func3:" << obj << endl;
	cout << "Вызов obj.SetX(300)" << endl;
	obj->SetX(300);
}

void line()
{
	cout << endl << "-------------------------------------------------------------------------------------" << endl << endl;
}

int main()
{
	srand(time(NULL));
	setlocale(LC_ALL, "Russian");
	LinkedList<Point> linkedList;
	int z;
	for (int i = 0; i < 10; i++)
	{
		z = rand() % 100;
		if (z % 4 == 0)
			linkedList.AddAfter(new Point());
		else if (i % 4 == 1)
			linkedList.AddAfter(new Circle());
		else if (i % 4 == 2)
			linkedList.AddAfter(new Scope());

		else linkedList.AddAfter(new Cylinder());
	}

	linkedList.MoveFirst();
	cout << endl << endl;
	for (int i = 0; i < linkedList.GetLength(); i++) {

		cout << i << ") " << linkedList.GetValue()->ClassName().c_str() << "\tisA(Point)";;
		if (linkedList.GetValue()->isA("Point") == true) cout << "  true";
		else cout << "  false";

		cout << "||" << linkedList.GetValue()->ClassName().c_str() << " \tisA(Circle)";
		if (linkedList.GetValue()->isA("Circle") == true) cout << "  true ";
		else cout << "  false";

		cout << " ||" << linkedList.GetValue()->ClassName().c_str() << " \tisA(Cylinder)";
		if (linkedList.GetValue()->isA("Cylinder") == true) cout << "  true";
		else cout << "  false";

		cout << "\t||" << linkedList.GetValue()->ClassName().c_str() << " \tisA(Scope)";
		if (linkedList.GetValue()->isA("Scope") == true) cout << " true";
		else cout << " false";

		cout << endl << endl;
		linkedList.MoveNext();
	}

	line();
	cout << "Проверка передачи параметров в функцию :" << endl << endl;
	cout << "Создание объекта класса Point" << endl << endl;
	Point point;

	point.Print();
	cout << endl << "Адрес объекта в main :" << &point << endl << endl;

	func1(point);
	cout << endl << "После вызова func1 : " << endl;
	point.Print();
	cout << endl << endl;

	func2(point);
	cout << endl << endl << "После вызова func2 : " << endl;
	point.Print();
	cout << endl << endl;

	func3(&point);
	cout << endl << "После вызова func3 : " << endl;
	point.Print();
	cout << endl << endl;

	cout << "Создание объекта класса Circle, наследника Point" << endl << endl;

	Circle cir;
	cout << endl << endl;
	func1(cir);
	cout << endl << "После вызова func1 : " << endl;
	cir.Print();
	cout << endl << endl;

	func2(cir);
	cout << endl << endl << "После вызова func2 : " << endl;
	cir.Print();
	cout << endl << endl;

	func3(&cir);
	cout << endl << "После вызова func3 : " << endl;
	cir.Print();
	cout << endl;


	line();
	cout << "Перекрытие методов :" << endl << endl;

	Circle* circle = new Circle(2, 2, 2);
	Cylinder* cylinder = new Cylinder(4, 4, 4, 4);
	cout << endl;

	cout << "Вызов метода GetСh у объекта circle (площадь circle) : " << circle->GetСh() << endl << endl;
	cout << "Вызов метода GetСh у объекта cylinder (объем cylinder) : " << cylinder->GetСh() << endl << endl;

	line();
	cout << "Вызов наследуемого метода :" << endl << endl;

	cout << "Текущее значение circle :" << endl;
	circle->Print();
	cout << endl << endl;;
	cout << "Вызов метода Move(20,30), который наследуется от класса родителя Point :" << endl;
	circle->Move(20, 30);
	cout << endl;
	cout << "Измененные значение circle :" << endl;
	circle->Print();

	line();
	cout << "Безопасное приведение типов :" << endl << endl;

	cout << "С помощью dynamic_cast :" << endl << endl;
	linkedList.MoveFirst();
	for (int i = 0; i < linkedList.GetLength(); i++)
	{
		Cylinder* cylinder = dynamic_cast <Cylinder*>(linkedList.GetValue());

		if (cylinder != NULL) {
			cout << i << ") ";
			cylinder->Print();
			cout << endl;
			cout << "cylinder->SetH(23)" << endl;
			cylinder->SetH(23);
			cylinder->Print();
			cout << endl << endl;
		}

		linkedList.MoveNext();
	}
	cout << endl << endl;
	cout << "Безопасное приведение типов вручную :" << endl << endl;

	linkedList.MoveFirst();

	for (int i = 0; i < linkedList.GetLength(); i++)
	{
		if (linkedList.GetValue()->isA("Cylinder"))
		{
			cout << i << ") ";
			Cylinder* cylinder = (Cylinder*)(linkedList.GetValue());
			cylinder->Print();
			cout << endl << "cylinder->SetX(46);" << endl;
			cylinder->SetX(46);
			cout << endl;
			cylinder->Print();
			cout << endl << endl;
		}
		linkedList.MoveNext();
	}
	line();
	delete cylinder;
	delete circle;


}
