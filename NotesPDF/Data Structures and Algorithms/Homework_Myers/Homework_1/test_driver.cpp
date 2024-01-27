#include <iostream>
#include "tvector.h"
using namespace std;

int main(){
    TVector<int> s;
    s.InsertBack(10);
    s.InsertBack(20);
    s.Clear();
    s.SetCapacity(100);
}