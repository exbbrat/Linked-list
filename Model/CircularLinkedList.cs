using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_list.Model
{/// <summary>
/// Реализация Двусвязного кольцевого списка
/// </summary>
/// <typeparam name="T"></typeparam>
   public class CircularLinkedList<T>: IEnumerable
    {/// <summary>
     ///  Голова Списка
     /// </summary>
        public DuplexItem<T> Head { get; set; }
        /// <summary>
        /// Колличество элементов списка
        /// </summary>
        public int Count { get; set; }

        public CircularLinkedList() { }

        public CircularLinkedList (T data)
        {
            setHeadItem(data);
        }

        public void Add(T data)
        {
            if(Count == 0)
            {
                setHeadItem(data);
                return;
            }
            var item = new DuplexItem<T>(data);
            item.Next = Head;
            item.Previous = Head.Previous;
            Head.Previous.Next = item;
            Head.Previous = item;
            Count++;

        }

        public void Delete (T data)
        {
            if (Head.Data.Equals(data))
            {
                RemoveIthem(Head);
                Head = Head.Next;
                return;
            }

            var current = Head;

            for (int i = Count; i > 0; i--)
            {
                if (current != null && current.Data.Equals(data))
                {
                    RemoveIthem(current);
                }

                current = current.Next;
            }
        }
        /// <summary>
        /// Удаление элемента списка с переназначением связей
        /// </summary>
        /// <param name="current"></param>
        private void RemoveIthem(DuplexItem<T> current)
        {
            current.Next.Previous = current.Previous;
            current.Previous.Next = current.Next;
            Count--;
        }
        /// <summary>
        /// Установка связности кольцевого  списка 
        /// </summary>
        /// <param name="data"></param>
        private void setHeadItem(T data)
        {
            Head = new DuplexItem<T>(data);
            Head.Next = Head;
            Head.Previous = Head;
            Count = 1;
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            for ( int i = 0; i< Count; i++)
            {
                yield return current;
                current = current.Next;

            }
        }
    }
}
