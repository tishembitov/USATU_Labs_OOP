#pragma once
#include <string>

using std::string;
class Point {

protected:
	//координаты точки
	float x, y;

public:
	//Конструктор  по умолчанию 
	Point();

	//Конструктор  с параметрами
	Point(float a, float b);

	//Конструктор копирования класса Point ( т.е. копирует х и у )
	Point(Point& point);

	//Переместить точку
	void Move(float dx, float dy);

	//Возврат типа (какой объект добавляем)
	virtual const char* GetType();

	//изменить значения полей
	virtual void Modify();

	//возврат имени типа
	virtual const string  ClassName();
	//совпадает ли отправленное название с названием текущего класса

	virtual bool isA(string className);

	//Вывод содержимого класса
	virtual void Print();

	//Задать новые координаты с помощью виртуального метода
	virtual void SetXY(float a, float b);

	void SetX(float a);

	static void funcc(const Point* const point);

	void SetY(float b);

	//Получить значение х 
	float GetX();

	//Получить значение у
	float GetY();

	//Деструктор
	virtual ~Point();
};

