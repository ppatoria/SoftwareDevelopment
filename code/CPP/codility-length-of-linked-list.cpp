#include <iostream>
#include <memory>

class MyLinkedList;

class MyLinkedList
{
public:
  int data;
  std::shared_ptr<MyLinkedList> next;
};

std::shared_ptr<MyLinkedList> CreateList( int length )
{
  std::shared_ptr<MyLinkedList> head = nullptr;
  for( auto i=0; i< length ; i++ )
    {
      auto current_node = std::make_shared<MyLinkedList>();
      current_node->data = i;
      current_node->next = head;
      head = current_node;
    }
  return head;
}

int solution( std::shared_ptr<const MyLinkedList> head )
{
  int counter = 0;
  while( head )
    {
      counter = counter + 1;
      head = head->next;
    }
  return counter;
}

int main()
{
  auto list = CreateList( 4 );
  std::cout << "Result: " << solution( list ) << std::endl;
  return 0;
}
