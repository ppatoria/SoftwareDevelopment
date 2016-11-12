public class Node {

    public int Data;
		   public Node Left;
				   public Node Right;

						    public void DisplayNode() {
							Console.Write(Data + " ");
						    }
}
  
  public class BinarySearchTree {

    public Node root;

		    public BinarySearchTree() {
			root = null;
		    }

    public void Insert(int i) {
	Node newNode = new Node();
	newNode.Data = i;
	if (root == null)
	    root = newNode;
	else {
	    Node current = root;
	    Node parent;
	    while (true) {
		parent = current;
		if (i < current.Data) {
		    current = current.Left;
		    if (current == null) {
			parent.Left = newNode;
			break;
		    }
		    else {
			current = current.Right;
			if (current == null) {
			    parent.Right = newNode;
			    break;
			}
		    }
		}
	    }
	}


	Insert(int i , Node parent, Node current)
	{
	    if(current == null){
		Node newNode = new Node(i);
	        parent.next = newNode;
	    }else if(i < current.Data){
		parent = current;
		current = current.next;
		insert(i, parent, current);
	    }else if(i > current.Data){
		parent = current;
		current = current.next;
		insert(i,parent,current);
	    }else
		Console.WriteLine("{0} already exists", i);	
	    
	}

