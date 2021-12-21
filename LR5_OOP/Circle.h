#pragma once
#include "Point.h"

class Circle : public Point
{
protected:
	//Радиус круга
	float r;
public:
	//Конструктор  по умолчанию 
	Circle();

	//Конструктор  с параметрами
	Circle(float a, float b, float rad);

	//Конструктор копирования ( т.е. копирует х и у )
	Circle(Circle& point);

	float GetCh();

	//Вывод содержимого класса
	void Print();
	//возврат имени типа
	const string ClassName() override;

	//совпадает ли отправленное название с названием текущего класса
	bool isA(string className) override;

	//возврат имени типа
	const char* GetType() override;

	void Modify() override;

	//Деструктор
	~Circle() override;
};

