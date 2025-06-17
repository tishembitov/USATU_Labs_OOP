#ifndef CSTORAGE_H
#define CSTORAGE_H
#include <cassert>

template <class T> // ��� ������ ������ � T ������ ������������ (�������������) ���� ������
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
        printf("������ � �������� %d ��������\n", index);
        m_data[index] = object;
    }

    void Erase()
    {
        printf("�������  � ��������� �������\n");
        delete[] m_data;
        // ����������� �������� nullptr ��� m_data, ����� �� ������ �� �������� ������� ���������!
        m_data = nullptr;
        m_length = 0;
    }


    T& operator[](int index) 
    {
        assert(index >= 0 && index < m_length);
        return *m_data[index];
    }

    // ������� reallocate() �������� ������ �������. ��� ������������ �������� ������ ������� ����� ����������. ������� �������
    void reallocate(int newLength)
    {
        printf("�������� ������ ��������� � ��������� �������� � ��� �� %d\n", newLength);
        // ������� ��� ������������ �������� ������ �������
        Erase();

        // ���� ��� ������ ������ ���� ������, �� ��������� ������� �����
        if (newLength <= 0)
            return;

        // ������ ��� ����� �������� ����� ��������
        m_data = new T*[newLength];
        m_length = newLength;
    }

    // ������� resize() �������� ������ �������. ��� ������������ �������� �����������. ������� ���������
    void resize(int newLength)
    {
        printf("�������� ������ ��������� ��� �������� �������� � ��� �� %d\n", newLength);
        // ���� ������ ��� ������ �����, �� ��������� return
        if (newLength == m_length)
            return;

        // ���� ����� ������� ������ ������, �� ������ ��� � ����� ��������� return
        if (newLength <= 0)
        {
            Erase();
            return;
        }

        // ������ �����������, ��� newLength �������, �� ������� ����, �� ������ ��������. ����������� ��������� �������� ��������:
        // 1. �������� ����� ������.
        // 2. �������� �������� �� ������������� ������� � ��� ������ ��� ���������� ������.
        // 3. ���������� ������ ������ � ���� ������� m_data ��������� �� ����� ������.

        // �������� ����� ������
        T** data = new T*[newLength];

        // ����� ��� ����� ����������� � ����������� ���������� ��������� � ����� ������.
        // ��� ����� ����������� ������� ���������, ������� �� ���� � ������� �� ��������
        if (m_length > 0)
        {
            int elementsToCopy = (newLength > m_length) ? m_length : newLength;

            // ���������� �������� ��������
            for (int index = 0; index < elementsToCopy; ++index)
                data[index] = m_data[index];
        }

        // ������� ������ ������, ��� ��� �� ��� ��� �� �����
        delete[] m_data;

        // � ���������� ������ ������� ������� �����! �������� ��������, m_data ��������� �� ��� �� �����, �� ������� ��������� ��� ����� ����������� ���������� ������.
        // ��������� ������ ���� ����������� ��������, �� ��� �� ����� ����������, ����� ������ �� ������� ���������
        m_data = data;
        m_length = newLength;
    }

    void insertBefore(T* object, int index)
    {
        printf("������ � �������� %d ��������\n", index);
        // �������� ������������ ������������� �������
        assert(index >= 0 && index <= m_length);

        // ������� ����� ������ �� ���� ������� ������ ������� �������
        T** data = new T*[m_length + 1];

        // �������� ��� �������� �� �� index
        for (int before = 0; before < index; ++before)
            data[before] = m_data[before];

        // ��������� ��� ����� ������� � ��� ����� ������
        data[index] = object;

        // �������� ��� �������� ����� ������������ ��������
        for (int after = index; after < m_length; ++after)
            data[after + 1] = m_data[after];

        // ������� ������ ������ � ���������� ������ ���� ����� ������
        delete[] m_data;
        m_data = data;
        ++m_length;
    }

    void remove(int index)
    {
        printf("������ � �������� %d ������\n", index);
        // �������� �� ������������ ������������� �������
        assert(index >= 0 && index < m_length);

        // ���� ��� ��������� ������� �������, �� ������ ������ ������ � ��������� return
        if (m_length == 1)
        {
            Erase();
            return;
        }
       
        // C������ ����� ������ �� ���� ������� ������ ������ ������� �������
        T** data = new T*[m_length - 1];

        // �������� ��� �������� �� �� index
        for (int before = 0; before < index; ++before)
            data[before] = m_data[before];

        // �������� ��� �������� ����� ���������� ��������
        for (int after = index + 1; after < m_length; ++after)
            data[after - 1] = m_data[after];

        // ������� ������ ������ � ���������� ������ ���� ����� ������
        delete[] m_data;
        m_data = data;
        --m_length;
    }

    // ��������� �������������� ������� ������ ��� ��������
    void insertAtBeginning(T* object) { insertBefore(object, 0); }
    void insertAtEnd(T* object) { insertBefore(object, m_length); }

    int getLength() 
    {
        return m_length; 
    }
};

#endif
