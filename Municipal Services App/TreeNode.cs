using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7321_POE
{
    public class TreeNode<T> where T:IComparable<T>
    {
        public T data { get; set; }
        public TreeNode<T> left { get; set; }
        public TreeNode<T> right { get; set; }
        public int height { get; set; }

        public TreeNode(T data)
        {
            this.data = data;
            height = 1;
        }

    }
}
