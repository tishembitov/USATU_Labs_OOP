#include "pch.h"
#include "Point.h"
#include <iostream>
using namespace std;
// конструктор для point по умолчанию
Point::Point()
{
	x = 0;
	y = 0;
	cout << "Вызван конструктор по умолчанию класса Point : Point()" << endl;
}

Point::Point(float a, float b)
{
	x = a;
	y = b;
	cout << "Вызван конструктор с параметрами класса Point :  Point(" << x << ", " << y << ")" << endl;
}

Point::Point(Point& point)
{
	x = point.x;
	y = point.y;
	cout << "Вызван конструктор копирования класса Point :   Point (Point& point)" << endl;
}

void Point::Move(float dx, float dy)
{
	x = x + dx;
	y = y + dy;
	cout << "Вызван метод Move класса Point" << endl;
}

void Point::Print()
{
	cout << "Значение х : " << x << " || значение у : " << y;
}


//изменить значения 
void Point::Modify()
{
	cout << "  x = ";
	cin >> x;
	cout << "  y = ";
	cin >> y;
}


void Point::SetXY(float a, float b)
{
	x = a;
	y = b;
	cout << "Вызван виртуальный метод SetXY(" << a << "," << b << ") класса Point" << endl;
}


float Point::GetX() {
	return x;
}

//возврат имени типа
const char* Point::GetType()
{
	return "Point";
}

//возврат имени типа
const string Point::ClassName()
{
	return "Point";
}

void Point::SetX(float a)
{
	x = a;
}

void Point::SetY(float b)
{
	x = b;
}

void Point::funcc(const Point* const point)
{
	cout << "point->x = " << point->x << endl;
	cout << "point->y = " << point->y << endl;
}

//совпадает ли отправленное название с названием текущего класса
bool Point::isA(string className)
{

	if (className.compare("Point") == 0)
		return true;

	return false;
}

float Point::GetY()
{
	return y;
}


Point::~Point()
{
	cout << "Вызван деструктор класса Point" << endl;
}

