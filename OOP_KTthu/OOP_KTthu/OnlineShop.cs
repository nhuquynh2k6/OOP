using ConsoleApplication3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OOP_KTthu
{
    internal class OnlineShop
    {
        List<Product> Products = new List<Product>();
        List<Order> Orders= new List<Order>();
        public void AddProduct(Product p)
        {
            foreach (var item in Products)
            {
                if (item.ProductId == p.ProductId)
                    return;
                Products.Add(p);
            }
        }
        public bool PlaceOrder(Order order)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].ProductId==order.OrderId)
                    return true;
            }
            return false;
        }
        public Order FindOrderById(string id)
        {
            foreach (var item in Orders)
            {
                if (item.OrderId == id)
                    return item;
            }
            return null;
        }
        public double CalculateRevenue(DateTime from, DateTime to)
        {
            double total = 0;
            foreach (var item in Orders)
            {
                if(item.OrderDate>=from && item.OrderDate<=to)
                total += item.CalculateTotal();
            }
            return total;
        }
        public List<Product> GetBestSellingProducts(int topCount)
        {
                List<OrderItem> soldProducts = new List<OrderItem>();

                foreach (var o in Orders)
                    foreach (var item in o.Items)
                        if (soldProducts.Count == 0)
                            soldProducts.Add(item);
                        else
                        {
                            for (int i = 0; i < soldProducts.Count; i++)
                                if (soldProducts[i].Item.ProductId.ToUpper() == item.Item.ProductId.ToUpper())
                                    soldProducts[i].Quantity += item.Quantity;
                                else
                                    soldProducts.Add(item);
                        }
                for (int i = 0; i < soldProducts.Count - 1; i++)
                    for (int j = i + 1; j < soldProducts.Count; j++)
                        if (soldProducts[i].Quantity < soldProducts[j].Quantity)
                        {
                            OrderItem tmp;
                            tmp = soldProducts[i];
                            soldProducts[i] = soldProducts[j];
                            soldProducts[j] = tmp;
                        }

                List<Product> bestSellingProducts = new List<Product>();
                int numProduct = Math.Min(topCount, soldProducts.Count);
                for (int i = 0; i < numProduct; i++)
                    bestSellingProducts.Add(soldProducts[i].Item);

                return bestSellingProducts;

            }
            //var total = new Dictionary<string, int>();
            //foreach (var od in Orders)
            //{
            //    foreach (var item in od.Items)
            //    {
            //        if (total.ContainsKey(item.Item.ProductId))
            //            total[item.Item.ProductId] += item.Quantity;
            //        else
            //            total.Add(item.Item.ProductId, item.Quantity);
            //    }
            //}
            //Product tmp;
            //for (int i = 0; i < Orders.Count - 1; i++)
            //    for (int j = i + 1; j < Orders.Count; j++)
            //        if (Orders[j].CalculateTotal() > Orders[i].CalculateTotal())
            //        {
            //            tmp = Products[j];
            //            Orders[j] = Orders[i];
            //            Products[i] = tmp;
            //        }
            //return new List<Product>();

            //int[] soldQuantities = new int[Products.Count];// mang co so phan tu bang voi so san pham ban ra

            //    for (int i = 0; i < Orders.Count; i++)
            //    {
            //        Order order = Orders[i];// don hang dang xet
            //        for (int j = 0; j < order.Items.Count; j++)
            //        {
            //            OrderItem item = order.Items[j]; // san pham trong don hang dang xet
            //            string id = item.Item.ProductId; // ma san pham dang xet

            //            //tim vi tri cua san pham dang xet bang id trong ban Products
            //            for (int k = 0; k < Products.Count; k++)
            //            {
            //                if (Products[k].ProductId == id)
            //                {
                            //    soldQuantities[k] += item.Quantity;
                            //    break;
                            //}
                //        }
                //    }
                //}

                //for (int i = 0; i < Products.Count - 1; i++)
                //{
                //    for (int j = i + 1; j < Products.Count; j++)
                //    {
                //        if (soldQuantities[i] < soldQuantities[j])
                //        {
                //            // doi cho so luong
                //            int tempQty = soldQuantities[i];
                //            soldQuantities[i] = soldQuantities[j];
                //            soldQuantities[j] = tempQty;

                //            // doi cho san pham tuong ung voi so luong
                //            Product tempProd = Products[i];
                //            Products[i] = Products[j];
                //            Products[j] = tempProd;
                //        }
                //    }
                //}

            //    List<Product> result = new List<Product>();
            //    for (int i = 0; i < topCount && i < Products.Count; i++)
            //    {
            //        result.Add(Products[i]);
            //    }

            //    return result;
            //}
        public Dictionary<string, double> RevenueByCategory()
        {
            Dictionary<string, double> output = new Dictionary<string, double>()
            {
                { "Laptop", 0}, { "Smartphone", 0}
            };
            foreach (var order in Orders)
            {
                foreach (var item in order.Items)
                {
                    double SubTotal = item.GetSubTotal();
                    if (item.Item is Laptop)
                        output["Laptop"] += SubTotal;
                    else if (item.Item is Smartphone)
                        output["Smartphone"] += SubTotal;
                }
            }
            return output;
        }
        public List<Order> GetOrdersByCustomerName(string name)
        {
                List<Order> result = new List<Order>();

                foreach (var order in Orders)
                {
                    if (order.CustomerName.ToUpper()==name.ToUpper())
                    {
                        result.Add(order);
                    }
                }
                return result;
        }
        public List<Product> CheckStock()
        {
            List<Product> products = new List<Product>();
            foreach (var item in Products)
            {
                if(item.StockQuantity<3)
                    products.Add(item);
            }
            return products;
        }
    }
}

