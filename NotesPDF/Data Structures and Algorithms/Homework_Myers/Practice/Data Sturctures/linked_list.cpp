#include <iostream>
using namespace std;

template<typename T>
struct Node{
    Node* Next;
    T Data;
    public:
        Node(int Value) : Next(nullptr), Data(Value){}
};

template<typename T>
class List{
private:
    Node<T>* Head;
    Node<T>* Tail;

public:
    List() : Head(nullptr), Tail(nullptr) {}
    
    void Add_Node(Node<T>* Val){
        if(Head == nullptr){
            Head = Val;
            Tail = Val;
        }
        else{
            Node<T>* c = Head;
            Val->Next = Head;
            Head = Val;
        }
    }

    T Pop_Front(){
        if(Head == nullptr){
            return nullptr;
        }
        else{
            Node<T>* Curr = Head;
            Head = Head->Next; 
            T data = Curr->Data;
            delete Curr;
            return data;
        }
    }
     
    void PrintList(std::ostream& os = cout, char&& delim = ' '){
        Node<T>* curr = Head;
        while(curr != nullptr){
            os << curr->Data << delim; 
            curr = curr->Next;
        }
    }
};

int main(){
    List<int> j;
    Node<int> insert_node(10);

    for(int i=0; i < 10; i++)
        j.Add_Node(&insert_node);
    j.PrintList(cout, ' ');

    return 0;
}
