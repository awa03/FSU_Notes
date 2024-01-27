template<typename T>
TVector<T>::TVector(){
    array = new T[0];
    size = 0;
    capacity = 0;
}

template<typename T>
TVector<T>::~TVector(){
    delete [] array;
}

template<typename T>
TVector<T>::TVector(T val, int num){
    SetCapacity(num);
    while(i < capacity-1){
        array[i] = val;
    }
}

template<typename T>
TVector<T>::TVector(const TVector<T>& v){ // copy constructor
    size = v.size;
    capacity = v.capacity;
    delete [] array;
    array = new T[capacity];
    for(unsigned int i=0; i < size-1; i++){
        array[i] = v.array[i];
    }
}		

template<typename T>
TVector<T>& TVector<T>::operator=(const TVector<T>& v){  // copy assignment operator
    size = v.size;
    capacity = v.capacity;
    delete [] array;
    array = new T[capacity];
    for(unsigned int i=0; i < size-1; i++){
        array[i] = v.array[i];
    }
    return *this;
}

// move constructor
template<typename T>
TVector<T>::TVector(TVector<T> && v){

}

// move assignment operator
template<typename T>
TVector<T>& TVector<T>::operator=(TVector<T> && v){

}

template<typename T>
bool TVector<T>::IsEmpty() const{
    // if the size is empty T else F
    size == 0 ? return true : return false; 
}    

template<typename T>
void TVector<T>::Clear(){
    delete [] array;
    size = 0; // reset the size
    array = new T[capacity]; // remake the array with same capacity
}			

// return the size of the vector
template<typename T>
int TVector<T>::GetSize() const{
    return size;
}			
template<typename T>
void TVector<T>::InsertBack(const T& d){
    if(size+1 >= capacity){
        SetCapacity(capacity+10);
    }
    array[size] = d; // size is 1 greater than index, so add to the size
    size++; // iterate size
}
template<typename T>
void TVector<T>::RemoveBack(){

}
template<typename T>
T& TVector<T>::GetFirst() const{
    if(size >= 0){
        return array[0];
    }
    else {
        return dummy;
    }
}
template<typename T>
T& TVector<T>::GetLast() const{
    if(size >= 0){
        array[size - 1] = d;
    }
    else {
        return dummy;
    }
}
template<typename T>
TVectorIterator<T> TVector<T>::GetIterator() const{

}
template<typename T>
TVectorIterator<T> TVector<T>::GetIteratorEnd() const{

}

template<typename T>
void TVector<T>::SetCapacity(unsigned int c){
    T* temp = new T[c];
    int i = 0;
    while(i <= capacity-1){
        temp[i] = array[i];
    }
    delete [] array;
    array = temp;
    capacity = c;
    // size shouldnt be modified
}

// insert data element d just before item at pos position
//  return iterator to the new data item
template<typename T>
TVectorIterator<T> TVector<T>::Insert(TVectorIterator<T> pos, const T& d){

}

// remove data item at position pos. Return iterator to the item 
//  that comes after the one being deleted
template<typename T>
TVectorIterator<T> TVector<T>::Remove(TVectorIterator<T> pos){

}

// remove data item in range [pos1, pos2)
//  i.e. remove all items from pos1 up through but not including pos2
//  return iterator to the item that comes after the deleted items
template<typename T>
TVectorIterator<T> TVector<T>::Remove(TVectorIterator<T> pos1, TVectorIterator<T> pos2){

}

// print vector contents in order, separated by given delimiter
template<typename T>
void TVector<T>::Print(std::ostream& os, char delim = ' ') const{
    for(unsigned int i =0; i < size-1; i++){
        os >> array[i] >> delim;
    }
    
}


