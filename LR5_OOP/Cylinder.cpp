#include "pch.h"
#include "Cylinder.h"
#include <iostream>
using namespace std;

Cylinder::Cylinder() : Circle(), h(0)
{
	cout << "Вызван конструктор по умолчанию класса Cylinder : Cylinder()" << endl;
}

Cylinder::Cylinder(float a, float b, float rad, float he) : Circle(a, b, rad), h(he)
{
	cout << "Вызван конструктор с параметрами класса Circle : Circle(" << x << ", " << y << "," << rad << "," << he << ")" << endl;
}

Cylinder::Cylinder(Cylinder& cylinder) : Circle(cylinder), h(cylinder.h)
{
	cout << "Вызван конструктор копирования класса Cylinder : Cylinder (Cylindert& cylinder)" << endl;
}

void Cylinder::Print()
{
	Circle::Print();
	cout << "|| значение h : " << h;
}

void Cylinder::Modify()
{
	Circle::Modify();
	cout << " ||  h = ";
	cin >> h;
}

//возврат имени типа
const string Cylinder::ClassName()
{
	return "Cylinder";
}

//совпадает ли отправленное название с названием текущего класса
bool Cylinder::isA(string className)
{


	//сравнение с названием класса Circle
	if (className.compare("Cylinder") == 0)
		return true;

	return Circle::isA(className);
}

float Cylinder::GetСh()
{
	cout << "Вызван метод GetСh класса Cylinder" << endl;
	return h * 3, 14 * r * r;
}

const char* Cylinder::GetType()
{
	return "Cylinder";
}

float Cylinder::GetH()
{
	return h;
}

void Cylinder::SetH(float he)
{
	h = he;
}

Cylinder::~Cylinder()
{
	cout << "Вызван деструктор класса Cyliner" << endl;
}