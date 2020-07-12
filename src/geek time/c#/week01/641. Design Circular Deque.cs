public class MyCircularDeque {
    private int _capacity;
    private int[] _data;
    private int _front;
    private int _rear;

    /** Initialize your data structure here. Set the size of the deque to be k. */
    public MyCircularDeque(int k) {
        // 加入一个空的位置保证可以判断队列是否为空
        this._capacity = k + 1;
        this._data = new int[this._capacity];
    }
    
    /** Adds an item at the front of Deque. Return true if the operation is successful. */
    public bool InsertFront(int value) {
        if (IsFull()) {
            return false;
        }
        // 注意：这里是 - 1 操作，因为在头加入元素就是要将头指针向前移动
        this._front = (this._front - 1 + this._capacity) % this._capacity;
        this._data[this._front] = value;
        return true;
    }
    
    /** Adds an item at the rear of Deque. Return true if the operation is successful. */
    public bool InsertLast(int value) {
        if (IsFull()) {
            return false;
        }
        this._data[this._rear] = value;
        this._rear = (this._rear + 1) % this._capacity;
        return true;
    }
    
    /** Deletes an item from the front of Deque. Return true if the operation is successful. */
    public bool DeleteFront() {
        if(IsEmpty()) {
            return false;
        }
        this._front = (this._front + 1) % this._capacity;
        return true;
    }
    
    /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
    public bool DeleteLast() {
        if (IsEmpty()) {
            return false;
        }
        this._rear = (this._rear - 1 + this._capacity) % this._capacity;
        return true;
    }
    
    /** Get the front item from the deque. */
    public int GetFront() {
        if (IsEmpty()) {
            return -1;
        }
        return this._data[this._front];
    }
    
    /** Get the last item from the deque. */
    public int GetRear() {
        if (IsEmpty()) {
            return -1;
        }
        // 这里的rear + capacity是为了保证数组不会越界
        return this._data[(this._rear + this._capacity - 1) % this._capacity];
    }
    
    /** Checks whether the circular deque is empty or not. */
    public bool IsEmpty() {
        return this._rear == this._front;
    }
    
    /** Checks whether the circular deque is full or not. */
    public bool IsFull() {
        return (this._rear + 1) % this._capacity == this._front;
    }
}