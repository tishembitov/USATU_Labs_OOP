#include <stdio.h>
#include <iostream>
#pragma once
using namespace std;

template <class T>
class Node {

private:

	//предыдущий элемент
	Node* prev;

	//значение адреса
	T* value;

	//следующий элемент
	Node* next;

public:

	//конструктор по умолчанию
	Node();

	//конструктор с параметрами
	Node(Node* _prev, T* _value, Node* _next);

	//конструктор копирования
	Node(Node& node);

	Node* GetPrev();

	T* GetValue();

	Node* GetNext();

	void SetValue(T* _value);

	void SetNext(Node* _next);

	void SetPrev(Node* _prev);

	//деструктор
	~Node();
};

template <class T>
Node<T>::Node()
{
	value = NULL;
	next = NULL;
	prev = NULL;

	cout << "Вызван конструктор по умолчанию класса Node" << endl;
}

template <class T>
Node<T>::Node(Node<T>* _prev, T* _value, Node<T>* _next)
{
	prev = _prev;
	value = _value;
	next = _next;

	cout << "конструктор с параметрами класса Node";
}

template <class T>
Node<T>::Node(Node<T>& node)
{

	value = node.value;
	next = node.next;
	prev = node.prev;

	cout << "Вызван конструктор копирования класса Node" << endl;
}

template <class T>
void Node<T>::SetValue(T* _value)
{
	value = _value;
}

template <class T>
void Node<T>::SetNext(Node<T>* _next)
{
	next = _next;
}

template <class T>
void Node<T>::SetPrev(Node<T>* _prev)
{
	prev = _prev;
}

template <class T>
T* Node<T>::GetValue()
{
	return value;
}

template <class T>
Node<T>* Node<T>::GetPrev()
{
	return prev;
}

template <class T>
Node<T>* Node<T>::GetNext()
{
	return next;
}

template <class T>
Node<T>::~Node<T>()
{

	cout << "Вызван деструктор класса Node" << endl;;
}


