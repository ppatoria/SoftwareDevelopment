/*
 A B-tree is a tree with root root[T] with the following properties:

    Every node has the following fields:
        n[x], the number of keys currently in node x. For example, n[|40|50|] in the above example B-tree is 2. n[|70|80|90|] is 3.
        The n[x] keys themselves, stored in nondecreasing order: key1[x] <= key2[x] <= ... <= keyn[x][x] For example, the keys in |70|80|90| are ordered.
        leaf[x], a boolean value that is True if x is a leaf and False if x is an internal node. 
    If x is an internal node, it contains n[x]+1 pointers c1, c2, ... , cn[x], cn[x]+1 to its children. For example, in the above B-tree, the root node has two keys, thus three children. Leaf nodes have no children so their ci fields are undefined.
    The keys keyi[x] separate the ranges of keys stored in each subtree: if ki is any key stored in the subtree with root ci[x], then

        k1 <= key1[x] <= k2 <= key2[x] <= ... <= keyn[x][x] <= kn[x]+1. 

    For example, everything in the far left subtree of the root is numbered less than 30. Everything in the middle subtree is between 30 and 60, while everything in the far right subtree is greater than 60. The same property can be seen at each level for all keys in non-leaf nodes.
    Every leaf has the same depth, which is the tree's height h. In the above example, h=2.
    There are lower and upper bounds on the number of keys a node can contain. These bounds can be expressed in terms of a fixed integer t >= 2 called the minimum degree of the B-tree:
        Every node other than the root must have at least t-1 keys. Every internal node other than the root thus has at least t children. If the tree is nonempty, the root must have at least one key.
        Every node can contain at most 2t-1 keys. Therefore, an internal node can have at most 2t children. We say that a node is full if it contains exactly 2t-1 keys. 
*/
