#pragma once
#include "Circle.h"
class Cylinder : public Circle
{
private:
	float h;
public:
	//конструктор по умолчанию для класса Cylinder
	Cylinder();

	//конструктор с параметрами для класса Cylinder
	Cylinder(float a, float b, float rad, float he);

	//Конструктор копирования ( т.е. копирует х и у )
	Cylinder(Cylinder& cylinder);

	//Вывод содержимого класса
	void Print();

	void Modify() override;
	// перекрываем метод Circle
	float GetСh();

	//возврат имени типа
	const string ClassName() override;

	//совпадает ли отправленное название с названием текущего класса
	bool isA(string className) override;

	//возврат имени типа
	const char* GetType() override;

	//Получение высоты 
	float GetH();

	//Установка высоты
	void SetH(float he);


	~Cylinder()override;
};


