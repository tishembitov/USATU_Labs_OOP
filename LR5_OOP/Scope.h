#pragma once
#include "Point.h"
class Scope : public Point
{
private:
	float r;
	float z;
public:
	Scope();

	Scope(float a, float b, float ze, float rad);

	Scope(Scope& scope);

	void Print();

	float GetZ();

	void SetZ(float ze);

	const char* GetType() override;

	float GetRadius();

	const string ClassName() override;

	//совпадает ли отправленное название с названием текущего класса
	bool isA(string className) override;

	void Modify() override;

	void SetRadius(float rad);

	~Scope();
};

