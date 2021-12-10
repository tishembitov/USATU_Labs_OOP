#pragma once
#include "Circle.h"
class Сylinder : public Circle
{
private:
	float h;
public:
	//конструктор по умолчанию для класса Сylinder
	Сylinder();

	//конструктор с параметрами для класса Сylinder
	Сylinder(float a, float b, float rad, float he);

	//Конструктор копирования ( т.е. копирует х и у )
	Сylinder(Сylinder& cylinder);

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


	~Сylinder()override;
};


