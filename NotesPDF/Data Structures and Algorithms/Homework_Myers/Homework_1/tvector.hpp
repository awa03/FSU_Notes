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
    capacity = num + SPARECAPACITY;
    size = num;
    array = new T[capacity];
    for (int i = 0; i < num; ++i) {
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
    if (this != &v) { // self-assignment check
        size = v.size;
        capacity = v.capacity;
        delete [] array;
        array = new T[capacity];
        for(unsigned int i = 0; i < size; i++){
            array[i] = v.array[i];
        }
    }
    return *this;
}

// move constructor
template<typename T>
TVector<T>::TVector(TVector<T> && v){
    array = v.array;
    size = v.size;
    capacity = v.capacity;

    // Reset the source object
    v.array = nullptr;
    v.size = 0;
    v.capacity = 0;
}

// move assignment operator
template<typename T>
TVector<T>& TVector<T>::operator=(TVector<T> && v){
    if (this != &v) { 
        delete[] array;

        // Transfer ownership from the source object
        array = v.array;
        size = v.size;
        capacity = v.capacity;

        // Reset the source object
        v.array = nullptr;
        v.size = 0;
        v.capacity = 0;
    }
    return *this;
}

template<typename T>
bool TVector<T>::IsEmpty() const{
    // if the size is empty T else F
    return (size == 0) ? true : false; // t/f is unnessicary
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
        SetCapacity(capacity+SPARECAPACITY);
    }
    array[size] = d; // size is 1 greater than index, so add to the size
    size++; // iterate size
}
template<typename T>
void TVector<T>::RemoveBack(){
    size--; // remove element from being included in new arr
    SetCapacity(capacity);
}

template<typename T>
T& TVector<T>::GetFirst() const{
    // return first element if exists, or dummy
    return (size >= 0) ? array[0] : dummy;
}

template<typename T>
T& TVector<T>::GetLast() const{
    return(size >= 0)? array[size - 1] : dummy;
}

template<typename T>
TVectorIterator<T> TVector<T>::GetIterator() const{
    TVectorIterator<T> iterator;
    iterator.index = 0;
    iterator.ptr = &array[0];
    iterator.vsize = size;
    return iterator;
}

template<typename T>
TVectorIterator<T> TVector<T>::GetIteratorEnd() const{
    TVectorIterator<T> iterator;
    iterator.index = size - 1;
    iterator.ptr = &array[iterator.index];
    iterator.vsize = size;
    return iterator;
}

template<typename T>
void TVector<T>::SetCapacity(unsigned int c){
    T* temp = new T[c];
    int i = 0;
    while(i <= size-1 && i <= c-1){
        temp[i] = array[i];
        i++;
    }
    delete [] array;
    array = temp;
    capacity = c;
    // size shouldnt be modified
}

template <typename T>
TVector<T> operator+(const TVector<T>& t1, const TVector<T>& t2){
    TVector<T> temp;
    temp.SetCapacity(t1.GetSize() + t2.GetSize() + 10);

    TVectorIterator<T> iterator1 = t1.GetIterator();
    TVectorIterator<T> iterator2 = t2.GetIterator();

    while (iterator1.HasNext()) {
        temp.InsertBack(iterator1.GetData());
        iterator1.Next();
    }

    while (iterator2.HasNext()) {
        temp.InsertBack(iterator2.GetData());
        iterator2.Next();
    }

    return temp;
}

// insert data element d just before item at pos position
//  return iterator to the new data item
template<typename T>
TVectorIterator<T> TVector<T>::Insert(TVectorIterator<T> pos, const T& d){
    if (size + 1 >= capacity) {
        SetCapacity(capacity + SPARECAPACITY);
    }

    T* temp = new T[capacity + 10];
    int i = 0; 
    int j = 0;

    if(pos.index != 0){ 
        // Copy elements before the insertion point
        for (; i <= pos.index; i++, j++) {
            temp[j] = array[i];
        }
        temp[j++] = d;
    }
    else {
        temp[j] = d;
    }
    // Insert the new element at the specified position
    
    pos.ptr = array + j;
    pos.index = j;

    // Copy the remaining elements after the insertion point
    for (; i < size; i++, j++) {
        temp[j] = array[i];
    }

    delete[] array;
    array = temp;
    size++;
    capacity = capacity;

    return pos.Previous();
}

// remove data item at position pos. Return iterator to the item 
//  that comes after the one being deleted
template<typename T>
TVectorIterator<T> TVector<T>::Remove(TVectorIterator<T> pos){
   if (size == 0 || pos.index >= size) {
        return pos;
    }

    T* temp = new T[capacity];
    TVectorIterator<T> itr = GetIterator();
    int i = 0, j = 0;

    while (itr.HasNext()) {
        if (itr.ptr == pos.ptr) {
            // Skip the element at the specified position
            itr.Next();
            continue;
        }

        temp[j] = std::move(itr.GetData());
        itr.Next();
        j++;
    }

    size = j;
    for (i = 0; i < size; i++) {
        array[i] = std::move(temp[i]);
    }

    delete[] temp;

    if (itr.HasNext()) {
        return itr;
    } else {
        return GetIteratorEnd();
    }
}

// remove data item in range [pos1, pos2)
//  i.e. remove all items from pos1 up through but not including pos2
//  return iterator to the item that comes after the deleted items
template<typename T>
TVectorIterator<T> TVector<T>::Remove(TVectorIterator<T> pos1, TVectorIterator<T> pos2){
    while(pos1.ptr != pos2.ptr){
        Remove(pos1);
        pos1.Next();
    }
    return pos1.Next();
}

// print vector contents in order, separated by given delimiter
template<typename T>
void TVector<T>::Print(std::ostream& os, char delim) const{
    for(unsigned int i =0; i < size; i++){
        os << array[i] << delim;
    }
    
}

/*
unsigned int index;			// index of current item in vector
T* ptr;	                    // pointer to the data item
unsigned int vsize;
*/

template<typename T>
TVectorIterator<T>::TVectorIterator(){
    index = 0;
    ptr = nullptr;
    vsize = 0;
}
template<typename T>
bool TVectorIterator<T>::HasNext() const{
    return (index > vsize-1)? false : true;
}	
template<typename T>
bool TVectorIterator<T>::HasPrevious() const{
    return (index <= 1)? false : true;
}	

template<typename T>
TVectorIterator<T> TVectorIterator<T>::Next(){
    HasNext() ? (index++, ptr++) : 0;
    return *this;
}
template<typename T>
TVectorIterator<T> TVectorIterator<T>::Previous(){
    HasPrevious() ? (index--, ptr--) : 0;
    return *this;
}
template<typename T>
T& TVectorIterator<T>::GetData() const{
    return *ptr;
}


