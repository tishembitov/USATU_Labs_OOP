#ifndef CSTORAGE_H
#define CSTORAGE_H
#include <cassert>

template <class T> // это шаблон класса с T вместо фактического (передаваемого) типа данных
class Storage 
{
private:
    int m_length;
    T** m_data;

public:
    Storage()
    {
        m_length = 0;
        m_data = nullptr;
    }

    Storage(int length)
    {
        m_data = new T*[length];
        m_length = length;
    }

    ~Storage()
    {
        delete[] m_data;
    }

    void setObject(T* object, int index) {
        printf("Объект с индексом %d добавлен\n", index);
        m_data[index] = object;
    }

    void Erase()
    {
        printf("объекты  в хранилище удалены\n");
        delete[] m_data;
        // Присваиваем значение nullptr для m_data, чтобы на выходе не получить висячий указатель!
        m_data = nullptr;
        m_length = 0;
    }


    T& operator[](int index) 
    {
        assert(index >= 0 && index < m_length);
        return *m_data[index];
    }

    // Функция reallocate() изменяет размер массива. Все существующие элементы внутри массива будут уничтожены. Процесс быстрый
    void reallocate(int newLength)
    {
        printf("изменяем размер хранилища с удалением объектов в нем на %d\n", newLength);
        // Удаляем все существующие элементы внутри массива
        Erase();

        // Если наш массив должен быть пустым, то выполняем возврат здесь
        if (newLength <= 0)
            return;

        // Дальше нам нужно выделить новые элементы
        m_data = new T*[newLength];
        m_length = newLength;
    }

    // Функция resize() изменяет размер массива. Все существующие элементы сохраняются. Процесс медленный
    void resize(int newLength)
    {
        printf("изменяем размер хранилища без удаления объектов в нем на %d\n", newLength);
        // Если массив уже нужной длины, то выполняем return
        if (newLength == m_length)
            return;

        // Если нужно сделать массив пустым, то делаем это и затем выполняем return
        if (newLength <= 0)
        {
            Erase();
            return;
        }

        // Теперь предположим, что newLength состоит, по крайней мере, из одного элемента. Выполняется следующий алгоритм действий:
        // 1. Выделяем новый массив.
        // 2. Копируем элементы из существующего массива в наш только что выделенный массив.
        // 3. Уничтожаем старый массив и даем команду m_data указывать на новый массив.

        // Выделяем новый массив
        T** data = new T*[newLength];

        // Затем нам нужно разобраться с количеством копируемых элементов в новый массив.
        // Нам нужно скопировать столько элементов, сколько их есть в меньшем из массивов
        if (m_length > 0)
        {
            int elementsToCopy = (newLength > m_length) ? m_length : newLength;

            // Поочередно копируем элементы
            for (int index = 0; index < elementsToCopy; ++index)
                data[index] = m_data[index];
        }

        // Удаляем старый массив, так как он нам уже не нужен
        delete[] m_data;

        // И используем вместо старого массива новый! Обратите внимание, m_data указывает на тот же адрес, на который указывает наш новый динамически выделенный массив.
        // Поскольку данные были динамически выделены, то они не будут уничтожены, когда выйдут из области видимости
        m_data = data;
        m_length = newLength;
    }

    void insertBefore(T* object, int index)
    {
        printf("Объект с индексом %d добавлен\n", index);
        // Проверка корректности передаваемого индекса
        assert(index >= 0 && index <= m_length);

        // Создаем новый массив на один элемент больше старого массива
        T** data = new T*[m_length + 1];

        // Копируем все элементы аж до index
        for (int before = 0; before < index; ++before)
            data[before] = m_data[before];

        // Вставляем наш новый элемент в наш новый массив
        data[index] = object;

        // Копируем все значения после вставляемого элемента
        for (int after = index; after < m_length; ++after)
            data[after + 1] = m_data[after];

        // Удаляем старый массив и используем вместо него новый массив
        delete[] m_data;
        m_data = data;
        ++m_length;
    }

    void remove(int index)
    {
        printf("Объект с индексом %d удален\n", index);
        // Проверка на корректность передаваемого индекса
        assert(index >= 0 && index < m_length);

        // Если это последний элемент массива, то делаем массив пустым и выполняем return
        if (m_length == 1)
        {
            Erase();
            return;
        }
       
        // Cоздаем новый массив на один элемент меньше нашего старого массива
        T** data = new T*[m_length - 1];

        // Копируем все элементы аж до index
        for (int before = 0; before < index; ++before)
            data[before] = m_data[before];

        // Копируем все значения после удаляемого элемента
        for (int after = index + 1; after < m_length; ++after)
            data[after - 1] = m_data[after];

        // Удаляем старый массив и используем вместо него новый массив
        delete[] m_data;
        m_data = data;
        --m_length;
    }

    // Несколько дополнительных функций просто для удобства
    void insertAtBeginning(T* object) { insertBefore(object, 0); }
    void insertAtEnd(T* object) { insertBefore(object, m_length); }

    int getLength() 
    {
        return m_length; 
    }
};

#endif
