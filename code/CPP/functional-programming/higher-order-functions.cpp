namespace functional
{
  template <typename Type,> 
  class vector : public std::vector<Type>
  {
  public:
    virtual ~vector() = default;
    template<typename UnaryPredicate>
    functional::vector<Type> filter( UnaryPredicate predicate )
    {
      functional::vector<Type> v;
      std::copy_if( this->begin(),
		    this->end(),
		    std::back_inserter( v ),
		    predicate);
      return v;
    }
 
    template <typename Function,  typename ReturnType
	      = typename std::result_of<Function(Type)>::type>

    functional::vector<ReturnType> map( Function select_lambda )
    {
      functional::vector<ReturnType> v;
      std::transform( this->begin(),
		      this->end(),
		      std::back_inserter( v ),
		      select_lambda );
      return v;
    }

    template <typename InitialValueType>
    Type fold( InitialValueType initial_value)
    {
	return std::accumulate( this->begin(),
				this->end(),
				initial_value);
    }
      
    template <typename InitialValueType, typename BinaryOperation>
    Type fold( InitialValueType initial_value,
	       BinaryOperation op)
    {
	return std::accumulate( this->begin(),
				this->end(),
				initial_value,
				op );
    }

    template <typename InitialValueType>
    Type fold_back( InitialValueType initial_value)
    {
	return std::accumulate( this->rbegin(),
				this->rend(),
				initial_value);
    }
      
    template <typename InitialValueType, typename BinaryOperation>
    Type fold_back( InitialValueType initial_value,
		    BinaryOperation op)
    {
	return std::accumulate( this->rbegin(),
				this->rend(),
				initial_value,
				op );
    }

    template <typename Function>
    void for_each( Function func )
    {
      std::for_each(this->begin(), this->end(),
		    func);
    }
  };
}
