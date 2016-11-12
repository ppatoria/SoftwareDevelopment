#include<vector>
/***********************************************************************/
/* Problem: 							       */
/* Find the balance point in an array. (The index where the sum of the */
/* elements to the left it is the same as the sum of the elements to   */
/* the right of it.)  						       */
/***********************************************************************/


/* bool try_find_equilibrium( std::vector<int>& list_of_numbers , int& el_at_equilibrium) */
/* { */
/*     auto sum = functional<std::vector<int>>(list_of_numbers) */
/* 	.fold_left(0, std::plus<int>());  */
/*     auto left = 0; */
/*     auto righr = sum; */
/*     for(const auto& el:list_of_numbers) */
/*     { */
/* 	right = sum - el; */
/* 	if(left == right) */
/* 	{ */
/* 	    el_at_equilibrium = el; */
/* 	    return true; */
/* 	} */
/* 	left = left + el; */
/*     } */
/*     return false; */
/* } */

/* class find_equilibrium : public ::testing::Test */
/* { */
/* public: */
/*     find_equilibrium() */
/* 	: valid_list_of_numbers(std::move(std::vector<int>{1,0,1})) */
/* 	, invalid_list_of_numbers(std::move(std::vector<int>{1,2,1})) */
/* 	{} */
    
/*     std::vector<int> valid_list_of_numbers; */
/*     std::vector<int> invalid_list_of_numbers; */
/* }; */

/* TEST_F(find_equilibrium, test_valid_list) */
/* { */
/*     int element; */
/*     auto result = try_find_equilibrium(valid_list_numbers, element); */
/*     ASSERT_TRUE(result); */
/*     ASSERT_EQ(0, element); */
/* } */
