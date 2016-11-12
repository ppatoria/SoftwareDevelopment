// Copyright (c) 2012, 2013 Object Computing, Inc.
// All rights reserved.
// See the file license.txt for licensing information.
#include "assertiv/assertiv.h"
#include "ut_utils.h"
#include "changed_checker.h"
#include "book/order_book.h"
#include "impl/simple_order.h"

namespace liquibook {

using book::OrderBook;
using impl::SimpleOrder;

typedef SimpleOrder* OrderPtr;
typedef OrderBook<OrderPtr> TypedOrderBook;
typedef DepthOrderBook<OrderPtr> TypedDepthOrderBook;
typedef TypedDepthOrderBook::DepthTracker DepthTracker;

class TradeCbListener : public TradeListener<TypedOrderBook>
{
public:
  virtual void on_trade(const TypedOrderBook* order_book,
                        Quantity qty,
                        Cost cost)
  {
    quantities_.push_back(qty);
    costs_.push_back(cost);
  }

  void reset()
  {
    quantities_.erase(quantities_.begin(), quantities_.end());
    costs_.erase(costs_.begin(), costs_.end());
  }
  std::vector<Quantity> quantities_;
  std::vector<Cost> costs_;
};

class OrderCbListener : public OrderListener<OrderPtr>
{
public:
  virtual void on_accept(const OrderPtr& order)
  {
    accepts_.push_back(order);
  }
  virtual void on_reject(const OrderPtr& order, const char* )
  {
    rejects_.push_back(order);
  }
  virtual void on_fill(const OrderPtr& order, 
                       const OrderPtr& , // matched_order
                       Quantity ,        // fill_qty
                       Cost)             // fill_cost
  {
    fills_.push_back(order);
  }
  virtual void on_cancel(const OrderPtr& order)
  {
    cancels_.push_back(order);
  }
  virtual void on_cancel_reject(const OrderPtr& order, const char* )
  {
    cancel_rejects_.push_back(order);
  }
  virtual void on_replace(const OrderPtr& order,
                          const int32_t& , // size_delta
                          Price )          // new_price)
  {
    replaces_.push_back(order);
  }
  virtual void on_replace_reject(const OrderPtr& order, const char* )
  {
    replace_rejects_.push_back(order);
  }

  void reset()
  {
    accepts_.erase(accepts_.begin(), accepts_.end());
    rejects_.erase(rejects_.begin(), rejects_.end());
    fills_.erase(fills_.begin(), fills_.end());
    cancels_.erase(cancels_.begin(), cancels_.end());
    cancel_rejects_.erase(cancel_rejects_.begin(), cancel_rejects_.end());
    replaces_.erase(replaces_.begin(), replaces_.end());
    replace_rejects_.erase(replace_rejects_.begin(), replace_rejects_.end());
  }

  typedef std::vector<const SimpleOrder*> OrderVector;
  OrderVector accepts_;
  OrderVector rejects_;
  OrderVector fills_;
  OrderVector cancels_;
  OrderVector cancel_rejects_;
  OrderVector replaces_;
  OrderVector replace_rejects_;
};

TEST(TestOrderCallbacks)
{
  SimpleOrder order0(false, 3250, 100);
  SimpleOrder order1(true,  3250, 800);
  SimpleOrder order2(false, 3230, 0);
  SimpleOrder order3(false, 3240, 200);
  SimpleOrder order4(true,  3250, 600);

  OrderCbListener listener;
  TypedOrderBook order_book;
  order_book.set_order_listener(&listener);
  // Add order, should be accepted
  order_book.add(&order0);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.accepts_.size());
  listener.reset();
  // Add matching order, should be accepted, followed by a fill
  order_book.add(&order1);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.accepts_.size());
  ASSERT_EQ(1, listener.fills_.size());
  listener.reset();
  // Add invalid order, should be rejected
  order_book.add(&order2);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.rejects_.size());
  listener.reset();
  // Cancel only valid order, should be cancelled
  order_book.cancel(&order1);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.cancels_.size());
  listener.reset();
  // Cancel filled order, should be rejected
  order_book.cancel(&order0);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.cancel_rejects_.size());
  listener.reset();
  // Add a new order and replace it, should be replaced
  order_book.add(&order3);
  order_book.replace(&order3, 0, 3250);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.accepts_.size());
  ASSERT_EQ(1, listener.replaces_.size());
  listener.reset();
  // Add matching order, should be accepted, followed by a fill
  order_book.add(&order4);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.accepts_.size());
  ASSERT_EQ(1, listener.fills_.size());
  listener.reset();
  // Replace matched order, with too large of a size decrease, replace
  // should be rejected
  order_book.replace(&order3, -500);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.replaces_.size());
  ASSERT_EQ(1, listener.replace_rejects_.size());
}

class OrderBookCbListener : public OrderBookListener<TypedOrderBook>
{
public:

  virtual void on_order_book_change(const TypedOrderBook* book)
  {
    changes_.push_back(book);
  }

  void reset()
  {
    changes_.erase(changes_.begin(), changes_.end());
  }

  typedef std::vector<const TypedOrderBook*> OrderBookVector;
  OrderBookVector changes_;
};

TEST(TestOrderBookCallbacks)
{
  SimpleOrder order0(false, 3250, 100);
  SimpleOrder order1(true,  3250, 800);
  SimpleOrder order2(false, 3230, 0);
  SimpleOrder order3(false, 3240, 200);
  SimpleOrder order4(true,  3250, 600);

  OrderBookCbListener listener;
  OrderBook<OrderPtr> order_book;
  order_book.set_order_book_listener(&listener);
  // Add order, should be accepted
  order_book.add(&order0);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.changes_.size());
  listener.reset();
  // Add matching order, should be accepted, followed by a fill
  order_book.add(&order1);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.changes_.size());
  listener.reset();
  // Add invalid order, should be rejected
  order_book.add(&order2);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());  // NO CHANGE
  listener.reset();
  // Cancel only valid order, should be cancelled
  order_book.cancel(&order1);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.changes_.size());
  listener.reset();
  // Cancel filled order, should be rejected
  order_book.cancel(&order0);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());  // NO CHANGE
  listener.reset();
  // Add a new order and replace it, should be replaced
  order_book.add(&order3);
  order_book.replace(&order3, 0, 3250);
  order_book.perform_callbacks();
  ASSERT_EQ(2, listener.changes_.size());
  listener.reset();
  // Add matching order, should be accepted, followed by a fill
  order_book.add(&order4);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.changes_.size());
  listener.reset();
  // Replace matched order, with too large of a size decrease, replace
  // should be rejected
  order_book.replace(&order3, -500);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());  // NO CHANGE
}

class DepthCbListener 
      : public TypedDepthOrderBook::TypedDepthListener
{
public:
  virtual void on_depth_change(const TypedDepthOrderBook* book,
                               const DepthTracker* ) // depth
  {
    changes_.push_back(book);
  }

  void reset()
  {
    changes_.erase(changes_.begin(), changes_.end());
  }
  typedef std::vector<const TypedDepthOrderBook*> OrderBooks;
  OrderBooks changes_;
};

TEST(TestDepthCallbacks)
{
  SimpleOrder buy0(true, 3250, 100);
  SimpleOrder buy1(true, 3249, 800);
  SimpleOrder buy2(true, 3248, 300);
  SimpleOrder buy3(true, 3247, 200);
  SimpleOrder buy4(true, 3246, 600);
  SimpleOrder buy5(true, 3245, 300);
  SimpleOrder buy6(true, 3244, 100);
  SimpleOrder sell0(false, 3250, 300);
  SimpleOrder sell1(false, 3251, 200);
  SimpleOrder sell2(false, 3252, 200);
  SimpleOrder sell3(false, 3253, 400);
  SimpleOrder sell4(false, 3254, 300);
  SimpleOrder sell5(false, 3255, 100);
  SimpleOrder sell6(false, 3255, 100);

  DepthCbListener listener;
  TypedDepthOrderBook order_book;
  order_book.set_depth_listener(&listener);
  // Add buy orders, should be accepted
  order_book.add(&buy0);
  order_book.add(&buy1);
  order_book.add(&buy2);
  order_book.add(&buy3);
  order_book.add(&buy4);
  order_book.perform_callbacks();
  ASSERT_EQ(5, listener.changes_.size());
  listener.reset();

  // Add buy orders past end, should be accepted, but not affect depth
  order_book.add(&buy5);
  order_book.add(&buy6);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());
  listener.reset();

  // Add sell orders, should be accepted and affect depth
  order_book.add(&sell5);
  order_book.perform_callbacks();
  order_book.add(&sell4);
  order_book.perform_callbacks();
  order_book.add(&sell3);
  order_book.perform_callbacks();
  order_book.add(&sell2);
  order_book.perform_callbacks();
  order_book.add(&sell1);
  order_book.perform_callbacks();
  order_book.add(&sell0);
  order_book.perform_callbacks();
  ASSERT_EQ(6, listener.changes_.size());
  listener.reset();

  // Add sell order past end, should be accepted, but not affect depth
  order_book.add(&sell6);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());
  listener.reset();
}

class BboCbListener 
      : public TypedDepthOrderBook::TypedBboListener
{
  public:
  virtual void on_bbo_change(const TypedDepthOrderBook* book,
                             const DepthTracker* ) // depth
  {
    changes_.push_back(book);
  }

  void reset()
  {
    changes_.erase(changes_.begin(), changes_.end());
  }

  typedef std::vector<const TypedDepthOrderBook*> OrderBooks;
  OrderBooks changes_;
};

TEST(TestBboCallbacks)
{
  SimpleOrder buy0(true, 3250, 100);
  SimpleOrder buy1(true, 3249, 800);
  SimpleOrder buy2(true, 3248, 300);
  SimpleOrder buy3(true, 3247, 200);
  SimpleOrder buy4(true, 3246, 600);
  SimpleOrder buy5(true, 3245, 300);
  SimpleOrder buy6(true, 3244, 100);
  SimpleOrder sell0(false, 3250, 300);
  SimpleOrder sell1(false, 3251, 200);
  SimpleOrder sell2(false, 3252, 200);
  SimpleOrder sell3(false, 3253, 400);
  SimpleOrder sell4(false, 3254, 300);
  SimpleOrder sell5(false, 3255, 100);
  SimpleOrder sell6(false, 3255, 100);

  BboCbListener listener;
  TypedDepthOrderBook order_book;
  order_book.set_bbo_listener(&listener);
  // Add buy orders, should be accepted
  order_book.add(&buy0);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.changes_.size());
  listener.reset();
  order_book.add(&buy1);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());
  listener.reset();
  order_book.add(&buy2);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());
  listener.reset();
  order_book.add(&buy3);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());
  listener.reset();
  order_book.add(&buy4);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());
  listener.reset();
  order_book.perform_callbacks();

  // Add buy orders past end, should be accepted, but not affect depth
  order_book.add(&buy5);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());
  listener.reset();
  order_book.add(&buy6);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());
  listener.reset();

  // Add sell orders, should be accepted and affect bbo
  order_book.add(&sell2);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.changes_.size());
  listener.reset();
  order_book.add(&sell1);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.changes_.size());
  listener.reset();
  order_book.add(&sell0);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.changes_.size());
  listener.reset();
  // Add sell orders worse than best bid, should not effect bbo
  order_book.add(&sell5);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());
  listener.reset();
  order_book.add(&sell4);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());
  listener.reset();
  order_book.add(&sell3);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());
  listener.reset();

  // Add sell order past end, should be accepted, but not affect depth
  order_book.add(&sell6);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.changes_.size());
  listener.reset();
}

TEST(TestTradeCallbacks) 
{
  SimpleOrder order0(false, 3250, 100);
  SimpleOrder order1(true,  3250, 800);
  SimpleOrder order2(false, 3230, 0);
  SimpleOrder order3(false, 3240, 200);
  SimpleOrder order4(true,  3250, 600);

  TradeCbListener listener;
  TypedOrderBook order_book;
  order_book.set_trade_listener(&listener);
  // Add order, should be accepted
  order_book.add(&order0);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.quantities_.size());
  listener.reset();
  // Add matching order, should result in a trade
  order_book.add(&order1);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.quantities_.size());
  ASSERT_EQ(1, listener.costs_.size());
  ASSERT_EQ(100, listener.quantities_[0]);
  ASSERT_EQ(100 * 3250, listener.costs_[0]);
  listener.reset();
  // Add invalid order, should be rejected
  order_book.add(&order2);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.quantities_.size());
  listener.reset();
  // Cancel only valid order, should be cancelled
  order_book.cancel(&order1);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.quantities_.size());
  listener.reset();
  // Cancel filled order, should be rejected
  order_book.cancel(&order0);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.quantities_.size());
  listener.reset();
  // Add a new order and replace it, should be replaced
  order_book.add(&order3);
  order_book.replace(&order3, 0, 3250);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.quantities_.size());
  listener.reset();
  // Add matching order, should be accepted, followed by a fill
  order_book.add(&order4);
  order_book.perform_callbacks();
  ASSERT_EQ(1, listener.quantities_.size());
  ASSERT_EQ(1, listener.costs_.size());
  listener.reset();
  // Replace matched order, with too large of a size decrease, replace
  // should be rejected
  order_book.replace(&order3, -500);
  order_book.perform_callbacks();
  ASSERT_EQ(0, listener.quantities_.size());
}

} // namespace liquibook
