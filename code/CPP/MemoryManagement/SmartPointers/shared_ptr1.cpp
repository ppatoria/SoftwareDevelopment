namespace boost {
    template<typename T> class shared_ptr {
    public:
        template <class Y> explicit shared_ptr(Y* p);
        template <class Y,class D> shared_ptr(Y* p,D d);
        ~shared_ptr();
        shared_ptr(const shared_ptr & r);
        template <class Y> explicit
        shared_ptr(const weak_ptr<Y>& r);
        template <class Y> explicit shared_ptr(std::auto_ptr<Y>& r);
        shared_ptr& operator=(const shared_ptr& r);
        void reset();
        T& operator*() const;
        T* operator->() const;
        T* get() const;
        bool unique() const;
        long use_count() const;
        operator unspecified-bool-type() const;
        void swap(shared_ptr<T>& b);
    };
    template <class T,class U>
    shared_ptr<T> static_pointer_cast(const shared_ptr<U>& r);
}
