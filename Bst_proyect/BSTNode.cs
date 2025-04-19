using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bst_proyect;

public class BSTNode
{
    public int Value;
    public BSTNode? Left, Right;

    public BSTNode(int value)
    {
        Value = value;
        Left = Right = null;
    }
}
