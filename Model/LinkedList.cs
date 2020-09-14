using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_list.Model
{/// <summary>
/// Односвязный список 
/// </summary>

    public class LinkedList<T> : IEnumerable
    {/// <summary>
    ///  Первый элемент списка
    /// </summary>
        public Item<T> Head { get; private set; }
        /// <summary>
        /// Последний элемент списка
        /// </summary>
        public Item<T> Tail { get; private set; }
        /// <summary>
        /// Колличество элементов списка 
        /// </summary>
        public int Count { get; private set; }
        
        /// <summary>
        /// Создать пустой список 
        /// </summary>
        public LinkedList()
        {
            Clear();
        }
        /// <summary>
        /// Создать список с начальным элементом
        /// </summary>
        /// <param name="data"></param>
        public LinkedList(T data)
        {    
            SetHeadAndTail(data); 
        }
        /// <summary>
        /// Добавить данны в конец списка
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {

            if(Tail != null)
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(data); 
            }
        }
        /// <summary>
        /// Удалить первое вхождение данных в список
        /// </summary>
        /// <param name="data"></param>
        public void Delete( T data)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }

                var current = Head.Next;
                var previos = Head;

                while (current!= null)
                {
                    if (current.Data.Equals(data))
                    {
                        previos.Next = current.Next;
                        Count--;
                        return;
                    }

                    previos = current;
                    current = current.Next;
                }
            }
            else
            {
                SetHeadAndTail(data);
            }
        }


        /// <summary>
        /// Добавить данные в начало списка
        /// </summary>
        /// <param name="data"></param>
        public void AppendHead(T data)
        {
            var item = new Item<T>(data)
            {
                Next = Head
            };
            Head = item;
            Count++;
        }


        public void InsertAfther(T target, T data)
        {
            if (Head != null)
            {
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        var item = new Item<T>(data);

                        item.Next = current.Next;
                        current.Next = item;
                        Count++;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
               
            }
            else
            {
                /// Нужно решить либо если список пустой то либо не добавлять ничего либо  вставить  данные 
                //SetHeadAndTail(target);
                //Add(data);
            }

        }
        /// <summary>
        /// Очистить список
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        private void SetHeadAndTail(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }
        /// <summary>
        /// Получить перечисление всех элементов в списке 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public override string ToString()
        {
            return "lined list" + Count + "элементов";
        }
    }
}
