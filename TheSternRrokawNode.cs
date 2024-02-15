using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypergaph
{
    public class TheSternRrokawNode
    {
        public int _p, _q;  // два целых числа _p и _q , соответствующие числителю и знаменателю рационального числа
        public TheSternRrokawNode left, right, parent;  // ссылки на элемент который находится слева и справа от текущего и на родителя его

        public TheSternRrokawNode(TheSternRrokawNode _parent) 
        {
            _p = _q = 0;
            left = right = null;
            parent = _parent;
        } // TheSternRrokawNode (constructor)
    } // TheSternRrokawNode (class)
} // Hypergaph (namespace)