using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_list.Model
{/// <summary>
/// Ячейка списка
/// </summary>

     public class Item<T> 
    {
        private T data = default(T);

        private Item<T> next = null;
        /// <summary>
        ///  Данные хранимые в ячейке спписка 
        /// </summary>
        public T Data
        {
            get { return data; }

            set
            {


                if (value != null)
                    data = value;
                else
                    throw new ArgumentNullException(nameof(value));
            }
        }
        /// <summary>
        /// Следующая ячейка списка
        /// </summary>
        public Item<T> Next { get; set; }

        public Item(T data)
        {
            Data = data;
        }

    }
}
