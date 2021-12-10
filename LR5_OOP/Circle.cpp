#include "pch.h"
#include "Circle.h"
#include <iostream>
using namespace std;

Circle::Circle() : Point(), r(0)
{
	cout << "Вызван конструктор по умолчанию класса Circle : Circle()" << endl;
}

Circle::Circle(float a, float b, float rad) : Point(a, b), r(rad)
{
	cout << "Вызван конструктор с параметрами класса Circle : Circle(" << x << ", " << y << "," << rad << ")" << endl;
}

Circle::Circle(Circle& circle) : Point(circle), r(circle.r)
{
	cout << "Вызван конструктор копирования класса Circle : Circle (Circle& circle)" << endl;
}

float Circle::GetСh()
{
	cout << "Вызван метод GetСh класса Circle" << endl;
	return 3, 14 * r * r;
}

void Circle::Modify()
{
	Point::Modify();
	cout << "  Radius = ";
	cin >> r;
}

const string Circle::ClassName()
{
	return "Circle";
}


//совпадает ли отправленное название с названием текущего класса
bool Circle::isA(string className)
{

	//сравнение с названием класса Circle
	if (className.compare("Circle") == 0)
		return true;

	return Point::isA(className);
}



void Circle::Print()
{
	Point::Print();
	cout << " || значение r : " << r;
}

const char* Circle::GetType()
{
	return "Circle";
}


Circle::~Circle()
{
	cout << "Вызван деструктор класса Circle" << endl;
}
