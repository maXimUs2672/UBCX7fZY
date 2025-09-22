// 代码生成时间: 2025-09-22 23:57:32
using System;

public class OrderProcessing
{
    // 订单类
    public class Order
    {
        public int OrderId;
        public decimal Amount;
        public string Status = "Pending";

        public Order(int orderId, decimal amount)
        {
            OrderId = orderId;
            Amount = amount;
        }
    }

    // 订单处理器类
    public class OrderProcessor
    {
        public Order CreateOrder(int orderId, decimal amount)
        {
            try
            {
                // 验证订单金额
                if (amount <= 0)
                {
                    throw new ArgumentException("订单金额必须大于0", nameof(amount));
                }

                // 创建订单
                Order order = new Order(orderId, amount);
                Console.WriteLine($"订单{orderId}已创建，金额：{amount}元");
                return order;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"创建订单失败：{ex.Message}");
                return null;
            }
        }

        public bool ProcessPayment(Order order)
        {
            try
            {
                // 模拟支付过程
                Console.WriteLine($"订单{order.OrderId}支付中...");
                Random random = new Random();
                if (random.Next(0, 100) > 80)
                {
                    order.Status = "Paid";
                    Console.WriteLine($"订单{order.OrderId}支付成功");
                    return true;
                }
                else
                {
                    order.Status = "PaymentFailed";
                    Console.WriteLine($"订单{order.OrderId}支付失败");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"支付处理失败：{ex.Message}");
                return false;
            }
        }

        public bool ProcessShipping(Order order)
        {
            try
            {
                // 模拟发货过程
                if (order.Status != "Paid")
                {
                    throw new InvalidOperationException("订单未支付，无法发货");
                }

                Console.WriteLine($"订单{order.OrderId}发货中...");
                Random random = new Random();
                if (random.Next(0, 100) > 70)
                {
                    order.Status = "Shipped";
                    Console.WriteLine($"订单{order.OrderId}发货成功");
                    return true;
                }
                else
                {
                    order.Status = "ShippingFailed";
                    Console.WriteLine($"订单{order.OrderId}发货失败");
                    return false;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"发货处理失败：{ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发货处理失败：{ex.Message}");
                return false;
            }
        }
    }

    // 程序入口
    public static void Main()
    {
        OrderProcessor processor = new OrderProcessor();
        Order order = processor.CreateOrder(1, 100.0m);

        if (order != null)
        {
            bool paymentResult = processor.ProcessPayment(order);
            if (paymentResult)
            {
                bool shippingResult = processor.ProcessShipping(order);
            }
        }
    }
}
