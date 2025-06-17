#include <iostream>

class Point
{
public:
	int x, y; 
public:
	
	Point() //конструктор по умолчанию
	{
		printf("Point()\n");
		x = 0;
		y = 0;
	}
	Point(int x, int y) //конструктор с параметрами
	{
		printf("Point(int x, int y)\n");
		this->x = x;
		this->y = y;
	}
	Point(const Point &p) //конструктор копирования
	{
		printf("Point(const Point &p)\n");
		x = p.x;
		y = p.y;
	}
	 virtual ~Point() //виртуальный деструктор (позволяет удалять объект класса потомка через переменную-указатель на базовый класс)
	{ 
		printf("%d, %d\n", x, y);
		printf("~Point()\n");
	}
	void move(int dx, int dy) //методы класса
	{
		x = x + dx;
		y = y + dy;
	}
	void reset();
};

void Point::reset()
{
	x = 0;
	y = 0;
}


class ColoredPoint: public Point //класс, наследуемый от класса Point
{
protected:
	int color;
public:

	ColoredPoint(): Point()
	{
		printf("ColoredPoint()\n");
		color = 0;
	}
	ColoredPoint(int x, int y, int color): Point(x, y)
	{
		printf("ColoredPoint(int x, int y, int color)\n");
		this->color = color;
	}
	ColoredPoint(const ColoredPoint& p)
	{
		printf("ColoredPoint(const ColoredPoint &p)\n");
		color = p.color;
		x = p.x;
		y = p.y;
	}
	 ~ColoredPoint()
	{
		printf("%d, %d color = %d\n", x, y, color);
		printf("~ColoredPoint()\n");
	}
	void change_color(int new_color)
	{
		color = new_color;
	}
};



class Section
{
protected:
	Point* p1;
	Point* p2;
public:
	Section()
	{
		printf("Section()\n");
		p1 = new Point;
		p2 = new Point;
	}

	Section(int x1, int y1, int x2, int y2)
	{
		printf("Section(int x1, int y1, int x2, int y2)\n");
		p1 = new Point(x1, y1);
		p2 = new Point(x2, y2);
	}

	Section(const Section &s) //глубокое копирование
	{
		printf("Section(const Section &p)\n");
		p1 = new Point(*(s.p1));
		p2 = new Point(*(s.p2));
	}

	/*
	Section(const Section& s) //поверхностное копирование
	{
		printf("Section(const Section &p)\n");
		p1 = s.p1;
		p2 = s.p2;
	}
	*/

    ~Section()
	{
		delete p1;
		delete p2;
		printf("~Section()\n");
	}
};

int main()
{
	setlocale(LC_ALL, "rus");
	{
		printf("создание статических объектов\n\n");
		Point p1; //создание статических объектов
		Point p2(3, 7);
		Point p3(p2);
	} 

	printf("_________________________________________\n");

	{
		printf("создание динамических объектов\n\n");
		Point* p1 = new Point; // создание динамических объектов
		Point* p2 = new Point(5, 10);
		Point* p3 = new Point(*p2);
		delete p1; // удаление динамических объектов
		delete p2;
		delete p3;
		printf("_________________________________________\n");
	}
	
	{
		printf("спецификаторы доступа\n\n");
		Point* p = new Point;
		p->x = 100;
		p->y = 100;
		delete p;
		printf("_________________________________________\n");
	}

	{
		printf("вызов методов класса\n\n");
		Point* p = new Point(1, 2);
		p->reset();// вызов метода reset
		p->move(10, 10); 
		delete p;
		printf("_________________________________________\n");
	}
	
	{
		printf("работа с классами потомка\n\n");
		ColoredPoint* p = new ColoredPoint();
		delete p;
		printf("_________________________________________\n");
	}

	{
		printf("помещение объектов в переменные различных типов\n\n");
		Point* p1 = new ColoredPoint(1, 2, 42); //создание объекта класса потомка через переменную указатель базового класса
		ColoredPoint* p2 = new ColoredPoint(1, 2, 42); // создание объекта класса через переменную-указатель собственного класса
		delete p1;
		delete p2;
		printf("_________________________________________\n");
	}

	{
		printf("создании композиции\n\n");
		Section* s1 = new Section;
		Section* s2 = new Section(*s1); //создание нового объекта через конструктор копирования
		delete s1;
		delete s2;
		printf("_________________________________________\n");
	}
		return 0;
}