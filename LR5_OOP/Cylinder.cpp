#include "pch.h"
#include "Cylinder.h"
#include <iostream>
using namespace std;

Сylinder::Сylinder() : Circle(), h(0)
{
	cout << "Вызван конструктор по умолчанию класса Сylinder : Сylinder()" << endl;
}

Сylinder::Сylinder(float a, float b, float rad, float he) : Circle(a, b, rad), h(he)
{
	cout << "Вызван конструктор с параметрами класса Circle : Circle(" << x << ", " << y << "," << rad << "," << he << ")" << endl;
}

Сylinder::Сylinder(Сylinder& cylinder) : Circle(cylinder), h(cylinder.h)
{
	cout << "Вызван конструктор копирования класса Сylinder : Сylinder (Сylindert& cylinder)" << endl;
}

void Сylinder::Print()
{
	Circle::Print();
	cout << "|| значение h : " << h;
}

void Сylinder::Modify()
{
	Circle::Modify();
	cout << " ||  h = ";
	cin >> h;
}

//возврат имени типа
const string Сylinder::ClassName()
{
	return "Сylinder";
}

//совпадает ли отправленное название с названием текущего класса
bool Сylinder::isA(string className)
{


	//сравнение с названием класса Circle
	if (className.compare("Сylinder") == 0)
		return true;

	return Circle::isA(className);
}

float Сylinder::GetСh()
{
	cout << "Вызван метод GetСh класса Cylinder" << endl;
	return h * 3, 14 * r * r;
}

const char* Сylinder::GetType()
{
	return "Сylinder";
}

float Сylinder::GetH()
{
	return h;
}

void Сylinder::SetH(float he)
{
	h = he;
}

Сylinder::~Сylinder()
{
	cout << "Вызван деструктор класса Cyliner" << endl;
}