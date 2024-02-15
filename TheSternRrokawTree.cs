using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace Hypergaph
{

    // Класс для реализации деревьев Стерна-Броко для рациональных приближений, (чисел с плавающей запятой (double)).
    public class TheSternRrokawTree
    {
        TheSternRrokawNode root;
        public TheSternRrokawTree()
        {
            Reset();
        }

        // Инициализируем корневой узел и его дочерние элементы
        public void Reset()  // инициализируем корень дерева (1/1)
        {
            root = new TheSternRrokawNode(null);

            root._p = root._q = 1;  
            Grow(root);  
        }
        /// Добавление левого и правого дочерних элементов к корню.
        /// <param name="node"> Узел, к которому будут добавлены дочерние элементы.
        /// </param>
        private void Grow(TheSternRrokawNode node)
        {
            // Добавление левого дочернего элемента к корню.

            TheSternRrokawNode left = new TheSternRrokawNode(node);

            node.left = left;
            if (node._p == 1) // Узел на левой границе дерева == 1 / (n + 1).
            {
                left._p = 1;
                left._q = node._q + 1;
            }
            else // Узел является медиантом родительского и предыдущего узлов.
            {
                TheSternRrokawNode previous = Previous(node);

                left._p = node._p + previous._p;
                left._q = node._q + previous._q;
            }

            // Добавление правого дочернего элемента к корню.

            TheSternRrokawNode right = new TheSternRrokawNode(node);

            node.right = right;
            if (node._q == 1) // Узел на правой границе дерева == (n + 1) / 1.
            {
                right._q = 1;
                right._p = node._p + 1;
            }
            else // Узел является медиантом родительского и следующего узлов.
            {
                TheSternRrokawNode next = Next(node);

                right._p = node._p + next._p;
                right._q = node._q + next._q;
            }
        }// Grow
        /// <summary>Возвращает узел влево.
        /// </summary>
        /// <param name="node">An TheSternRrokawNode.
        /// </param>
        /// <returns> узел вправо.
        /// </returns>
        private TheSternRrokawNode Previous(TheSternRrokawNode node)
        {
            Debug.Assert(node.parent != null);

            while (node.parent.right != null && node.parent.right != node)
            {
                node = node.parent;
            }
            return node.parent;
        }// Previous

        /// <summary>Возвращает узел вправо.
        /// </summary>
        /// <param name="node">An TheSternRrokawNode.
        /// </param>
        /// <returns>узел влево.
        /// </returns>
        private TheSternRrokawNode Next(TheSternRrokawNode node)
        {
            Debug.Assert(node.parent != null);

            while (node.parent.left != null && node.parent.left != node)
            {
                node = node.parent;
            }
            return node.parent;
        }
        // Следующая функция должна возвращать числитель и  знаменатель рациональной аппроксимации. 

        /// <summary>Аппроксимировать число с заданной точностью.
        /// </summary>
        /// <param name="x">Число для аппроксимации.</param>
        /// <param name="n">Точность в количестве знаков после запятой.
        /// </param>
        /// <returns>Экземпляр {Results}.
        /// </returns>
        /// 
        public Results Approximate(double x, int n)
        {
            if (NotPositive(x))
            {
                Console.WriteLine(
                   String.Format("Дерево Шторма Брокана.Приблизительно: аргумент 'x' (== {0}) должен быть положительным.",
                                  x));

                return new Results(0, 1, x, 0.0, new List<Tuple<int, int, double>>());
            }
            else
            {
                double epsilon = Math.Pow((double)10.0, (double)(-n));
                double approx = (double)1.0;
                List<Tuple<int, int, double>> sequence = new List<Tuple<int, int, double>>();

                // Вызываем {Reset}, если эта функция будет использоваться повторно.

                TheSternRrokawNode current = root; // Отправной точкой является корень дерева.

                do
                {
                    // Записываем текущее приближение.
                    sequence.Add(new Tuple<int, int, double>(current._p, current._q, approx));

                    // Двигаемся влево или вправо.
                    if (x > approx)
                    {
                        current = current.right;
                    }
                    else
                    {
                        current = current.left;
                    }
                    //Создаем (добавляем) дочерние элементы {текущего} узла.
                    Grow(current);

                    // Обновляем приближение.
                    approx = (double)current._p / (double)current._q;

                } while (Math.Abs(x - approx) > epsilon);

                return new Results(current._p, current._q, x, approx, sequence);
            }
        }// Ищем приблизительное значение
        private bool NotPositive(double x)
        {
            string str = x.ToString();

            return str.StartsWith("-") || str.Equals("0");
        }// Нет положительного
    }// TheSternRrokawTree (class)
}// Hypergaph (namespace)
