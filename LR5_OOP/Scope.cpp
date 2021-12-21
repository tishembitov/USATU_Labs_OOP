#include "pch.h"
#include "Scope.h"
#include <iostream>
using namespace std;

Scope::Scope()
{
	cout << "Вызван конструктор по умолчанию класса Scope : Scope()" << endl;
}

Scope::Scope(float a, float b, float ze, float rad) : Point(a, b), z(ze), r(rad)
{
	cout << "Вызван конструктор с параметрами класса Scope : Scope()" << endl;
}

Scope::Scope(Scope& scope) : Point(scope), z(scope.z)
{
	cout << "Вызван конструктор копирования класса Scope : Scope (Scope& scope)" << endl;
}

void Scope::Print()
{
	Point::Print();
	cout << " ||  значение r : " << r << " || значение z : " << z;

}

void Scope::Modify()
{
	Point::Modify();
	cout << "  Radius = ";
	cin >> r;
	cout << "  z = ";
	cin >> z;
}

const char* Scope::GetType()
{
	return "Scope";
}

float Scope::GetZ() {
	return z;
}

void Scope::SetZ(float ze) {
	z = ze;
}

float Scope::GetRadius() {
	return r;
}

const string Scope::ClassName()
{
	return "Scope";
}


//совпадает ли отправленное название с названием текущего класса
bool Scope::isA(string className)
{

	//сравнение с названием класса Circle
	if (className.compare("Scope") == 0)
		return true;

	return Point::isA(className);
}


void Scope::SetRadius(float rad) {
	r = rad;
}

Scope::~Scope()
{
	cout << "Вызван деструктор класса Scope" << endl;
}
