#include "Node.h"
#include "iostream"
#pragma once

using namespace std;

template <class T>
class LinkedList {

private:

	//текущий обозреваемый элемент списка
	Node<T>* current;


	//длина контейнера
	int length;

	//указатель на первый элемент списка
	Node<T>* first;

	//установить значение длины контейнера
	void SetLength(int _length);

	//получить ссылку на последний элемент списка
	Node<T>* GetLast();



public:

	//конструктор по умолчанию
	LinkedList();

	//поменять значение текущего просматриваемого элемента
	void Set();

	//добавить после текущего просматриваемого
	void AddAfter(T* value);

	//добавить перед текущим просматриваемым
	void AddBefore(T* value);

	//удалить текущий элемент из списка
	void Delete();

	//преити к следующему в контейнере объекту
	void MoveNext();

	//преити к предыдущему в контейнере объекту
	void MovePrev();

	//перейти к первому элементу списка
	void MoveFirst();

	//перебор дошел до конца списка
	bool GetEOL();

	//длина списка
	int GetLength();

	//получить значение текущего обозреваемого
	T* GetValue();

	//получить ссылку на текущий обозреваемый
	Node<T>* GetCurrent();

	//установить значение текущего элемента
	void SetCurrent(Node<T>* current);

	//деструктор
	~LinkedList();
};

template <class T>
//конструктор по умолчанию
LinkedList<T>::LinkedList() {

	length = 0;

	//установим значение указателя равным 0
	current = NULL;

	cout << "Вызван конструктор по умолчанию класса LinkedList" << endl;
}

template <class T>
//безопасная установка значения счетчика длины списка
void LinkedList<T>::SetLength(int _length)
{

	//Защита ( т.к. у нас может быть только >0 )
	if (_length >= 0) {
		length = _length;
	}
	else {
		//отладочный вывод
		cout << "Попытка установки отрицательного значение длины LinkedList " << endl;
		length = 0;
	}
}

template <class T>
//получить адрес последнего в списке
Node<T>* LinkedList<T>::GetLast() {

	return first->GetPrev();
}

template <class T>
//перебор дошел до конца списка
bool LinkedList<T>::GetEOL() {

	if (length == 0)
		return true;

	//если индекс просматриваемого элемента равен длине списка, то вернет true
	return current->GetNext() == first;
}

template <class T>
//добавить значение после текущего просматриваемого элемента
void LinkedList<T>::AddAfter(T* obj) {

	// в случае, если список пуст
	//меняем значение current
	if (length == 0) {

		//создаем новый узел
		current = new Node<T>();

		//текущий элемент одновременно первый таком случае
		first = current;

		//направим next на самого себя, чтобы обеспечить универсальность алгоритма
		current->SetNext(current);

		//направим prev на самого себя, чтобы обеспечить универсальность алгоритма
		current->SetPrev(current);

		//записываем в current значение
		current->SetValue(obj);

		//Длина увеличится в любом случае 
		SetLength(length + 1);

		return;
	}

	//сохраним адрес элемента, стоящего за текущим в списке списка
	Node<T>* oldNext = current->GetNext();

	//добавляемый нод
	Node<T>* addedNode = new Node<T>(current, obj, oldNext);

	//запишем адрес нового добавленного нода в поле next текущего обозреваемого узла
	current->SetNext(addedNode);

	//запишем адрес нового добавленного нода в поле prev стоявшего на месте addedNode узла
	oldNext->SetPrev(addedNode);

	//Длина увеличится 
	SetLength(length + 1);

	//добавленный объект становится текущим
	current = addedNode;
}

template <class T>
void LinkedList<T>::AddBefore(T* obj) {
	// если он первый то добавляем его в начало
	if (length == 0) {
		AddAfter(obj);
		return;
	}

	//сохраним адрес элемента, стоящего за текущим в списке 
	Node<T>* oldPrev = current->GetPrev();

	//добавляемый узел
	Node<T>* addedNode = new Node<T>(oldPrev, obj, current);

	//запишем адрес нового добавленного узла в поле next текущего обозреваемого узла
	current->SetPrev(addedNode);

	//запишем адрес нового добавленного узла в поле prev стоявшего на месте addedNode узла
	oldPrev->SetNext(addedNode);

	//Длина увеличится 
	SetLength(length + 1);

	if (current == first)
		first = addedNode;

	//Добавленный объект становится текущим
	current = addedNode;
}

template <class T>
//удалить текущий
void LinkedList<T>::Delete() {

	int k = 0;
	//если удалять нечего, то ничего не делаем (список пуст)
	if (length == 0)
		return;

	Node<T>* prev = current->GetPrev();

	Node<T>* newNext = current->GetNext();

	prev->SetNext(newNext);

	newNext->SetPrev(prev);

	if (first == current)
	{
		first = current->GetNext();
		k = 1;

	}

	delete current;

	if (k == 1)  current = first;
	else  current = prev;

	// длина уменьшается
	SetLength(length - 1);
}

template <class T>
//перейти к первому (для цикла)
void LinkedList<T>::MoveFirst() {
	current = first;
}

template <class T>
//перейти к следующему в контейнере объекту
void LinkedList<T>::MoveNext() {

	//если список пуст
	if (length == 0)
		return;

	//переход к следующему элементу списка
	current = current->GetNext();
}

template <class T>
//преити к предыдущему в контейнере объекту
void LinkedList<T>::MovePrev() {

	//если список пуст
	if (length == 0)
		return;

	//переход к предыдущему элементу списка
	current = current->GetPrev();
}

template <class T>
//получить значение текущего просматриваемого элемента
T* LinkedList<T>::GetValue() {

	return current->GetValue();
}

template <class T>
Node<T>* LinkedList<T>::GetCurrent() {
	return current;
}

template <class T>
void LinkedList<T>::SetCurrent(Node<T>* _current) {
	current = _current;
}

template <class T>
int LinkedList<T>::GetLength() {
	return length;
}

template <class T>
void LinkedList<T>::Set() {

	if (length == 0)
		return;

	current->GetValue()->Modify();
}

//деструктор
template <class T>
LinkedList<T>::~LinkedList() {

	//отладочный вывод
	cout << "Вызван деструктор класса LinkedList" << endl;

	//если список пуст, то нечего удалять
	if (length == 0)
		return;

	//сохраним значение length в tmp, т.к. при удалении значение length будет меняться
	int tmp = length;

	//удалим из списка length элементов
	for (int i = 0; i < tmp; i++)
		Delete();
}
