#include <iostream>
#include "tvector.h"
using namespace std;

template <typename T> 
void PrintList(const TVector<T>& v, string label)
{
   cout << label << " size is: " << v.GetSize() << "\n"
        << label << " = "; 
   v.Print(cout);
   cout << "\n\n";
}

int main()
{
   TVector<int> test;
   TVector<int> test2;
   for(int i = 0; i <= 5; i++){
      test.InsertBack(i);
      test2.InsertBack(i);
   }

   test.Print(cout);
   cout << test.GetLast();

   TVectorIterator<int> itr = test.GetIterator();
   cout << "\n";
   while(itr.HasNext()){
      cout << itr.GetData() << " ";  // Add a space or any other separator here
      test2.InsertBack(itr.GetData());
      itr.Next();  // Don't forget to move to the next element in the iterator
   }

   test2.Print(cout);

   TVector<int> test3;
   test3.SetCapacity(test.GetSize() + test2.GetSize() + 10);

   TVectorIterator<int> iterator1 = test.GetIterator();
   TVectorIterator<int> iterator2 = test2.GetIterator();


   while (iterator1.HasNext()) {
        test3.InsertBack(iterator1.GetData());
        iterator1 = iterator1.Next();
   }

   while (iterator2.HasNext()) {
        test3.InsertBack(iterator2.GetData());
        iterator2 = iterator2.Next();
   }


   cout << "\nTesting Assignment";
   cout << endl;
   test.Print(cout);

   TVector<int> test4;
   test4 = test;

   cout << endl;
   test4.Print(cout);

   cout << "\nt2, and t3";

   cout << endl << "t2: ";
   test2.Print(cout);

   cout << endl << "t3: ";
   test3.Print(cout);

   cout << "\nAdding them together" << endl;
   TVector<int> test5;
   test5 = test2 + test3;
   test5.Print(cout);
   TVector<int> v1;		// integer list

   for (int i = 0; i < 10; i++)
	v1.InsertBack(i*3);

   PrintList(v1, "v1");

   for (int i = 0; i < 8; i++)
        v1.Insert( v1.GetIterator(), (i+1) * 50 );

   PrintList(v1, "v1");

   v1.RemoveBack();
   PrintList(v1, "v1");

   v1.RemoveBack();
   PrintList(v1, "v1");

   v1.Remove(v1.GetIterator());
   PrintList(v1, "v1");

   v1.Remove(v1.GetIterator());
   PrintList(v1, "v1");

   // try an iterator, and some middle inserts/deletes
   cout << "Testing some inserts with an iterator\n\n";

   TVectorIterator<int> itr = v1.GetIterator();
   itr = v1.Insert(itr, 999);
   itr.Next();
   itr.Next();				// advance two spots
   itr = v1.Insert(itr, 888);
   itr.Next();				
   itr.Next();				
   itr.Next();				// advance three spots
   itr = v1.Insert(itr, 777);

   PrintList(v1, "v1");

   cout << "Testing some removes (with iterator)\n\n";

   itr.Next();   
   itr.Next();   			// advance two spots
   itr = v1.Remove(itr);		// delete current item
   PrintList(v1, "v1");

   for (int i = 0; i < 5; i++)
      itr.Previous();			// back 5 spots

   itr = v1.Remove(itr);		// delete current item
   PrintList(v1, "v1");
   
   // building another list

   cout << "Building a new list\n";
   TVector<int> v2;
   for (int i = 0; i < 10; i++)
      v2.InsertBack(i * 3 + 1);

   PrintList(v2, "v2");

   // Testing + overload:
   cout << "Testing operator+ overload\n";
   TVector<int> v3 = v1 + TVector<int>(100, 7);

   TVector<int> v4;
   v4 = v2 + v1;

   PrintList(v3, "v3");
   PrintList(v4, "v4");

   cout << "Testing a call to the 2-param delete\n";
   TVectorIterator<int> itr1 = v4.GetIterator();
   TVectorIterator<int> itr2 = v4.GetIterator();

   itr1.Next();
   itr1.Next();
   cout << "itr1 is attached to: " << itr1.GetData() << '\n';
   for (int i = 0; i < 8; i++)
      itr2.Next();
   cout << "itr2 is attached to: " << itr2.GetData() << '\n';
   
   cout << "Calling:  v4.Remove(itr1, itr2);\n";
   v4.Remove(itr1, itr2);   
   PrintList(v4, "v4");
}