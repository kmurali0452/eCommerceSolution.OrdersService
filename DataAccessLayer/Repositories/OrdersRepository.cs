using eCommerce.OrdersMicroservice.DataAccessLayer.Entities;
using eCommerce.OrdersMicroservice.DataAccessLayer.RepositoryContracts;
using MongoDB.Driver;


namespace eCommerce.OrdersMicroservice.DataAccessLayer.Repositories;


public class OrdersRepository : IOrdersRepository
{
  private readonly IMongoCollection<Order> _orders;
  private readonly string collectionName = "orders";
   
  public OrdersRepository(IMongoDatabase mongoDatabase)
  {
    _orders = mongoDatabase.GetCollection<Order>(collectionName);
  }

    List<Order> ordersData = new List<Order> {
 new Order {
      OrderID=  new Guid("4d9b6010-48e6-4a0e-bd4e-461c85c32c1d"),
      UserID= new Guid("c32f8b42-60e6-4c02-90a7-9143ab37189f"),
    TotalBill = 2799.98M,
      OrderDate=  Convert.ToDateTime("2050-10-20T08:00:00Z"),
    OrderItems = new List<OrderItem>{
    new  OrderItem {
        ProductID =new Guid( "1a9df78b-3f46-4c3d-9f2a-1b9f69292a77"),
        UnitPrice = 1299.99M,
        Quantity= 1,
        TotalPrice = 1299.99M
      },
     new  OrderItem  {
        ProductID =new Guid( "2c8e8e7c-97a3-4b11-9a1b-4dbe681cfe17"),
       UnitPrice = 1499.99M,
        Quantity= 1,
        TotalPrice = 1499.99M
      }
    }
  },
 new Order {
     OrderID= new Guid( "62c2fb9c-b36e-497e-b0b7-f07c6c3c22b2"),
     UserID= new Guid( "8ff22c7d-18c7-4ef0-a0ac-988ecb2ac7f5"),
    TotalBill = 969.95m,
    OrderDate= Convert.ToDateTime( "2050-10-21T09:00:00Z"),
    OrderItems = new List<OrderItem>{
   new OrderItem  {
        ProductID =new Guid( "3f3e8b3a-4a50-4cd0-8d8e-1e178ae2cfc1"),
       UnitPrice = 249.99m,
        Quantity= 1,
        TotalPrice = 249.99m
      },
  new OrderItem     {
        ProductID =new Guid( "4c9b6f71-6c5d-485f-8db2-58011a236b63"),
       UnitPrice = 179.99m,
        Quantity= 4,
        TotalPrice = 719.96m
      }
    }
  },
 new Order {
     OrderID= new Guid( "e3f6d6b7-bc84-48e3-8d22-961e1e084f0e"),
     UserID= new Guid( "8ff22c7d-18c7-4ef0-a0ac-988ecb2ac7f5"),
    TotalBill = 5499.88m,
    OrderDate= Convert.ToDateTime( "2050-10-22T10:00:00Z"),
    OrderItems = new List<OrderItem>{
     new OrderItem {
        ProductID =new Guid( "3f3e8b3a-4a50-4cd0-8d8e-1e178ae2cfc1"),
       UnitPrice = 249.99m,
        Quantity= 10,
        TotalPrice = 2499.9m
      },
     new OrderItem {
        ProductID =new Guid("2c8e8e7c-97a3-4b11-9a1b-4dbe681cfe17"),
       UnitPrice = 1499.99m,
        Quantity= 2,
        TotalPrice = 2999.98m
      }
    }
  },
 new Order {
    OrderID = new Guid("af168b29-b6c5-45ed-a4f1-19c04f368d1a"),
     UserID= new Guid( "8ff22c7d-18c7-4ef0-a0ac-988ecb2ac7f5"),
    TotalBill = 5039.94m,
    OrderDate= Convert.ToDateTime("2050-10-23T11:00:00Z"),
    OrderItems = new List<OrderItem>{
     new OrderItem {
            ProductID = new Guid("4c9b6f71-6c5d-485f-8db2-58011a236b63"),
           UnitPrice = 179.99m,
            Quantity = 3,
            TotalPrice = 539.97m
      },
     new OrderItem {
            ProductID = new Guid("2c8e8e7c-97a3-4b11-9a1b-4dbe681cfe17"),
           UnitPrice = 1499.99m,
            Quantity = 3,
            TotalPrice = 4499.97m
      }
    }
  },
 new Order {
    OrderID = new Guid("3a0e5c1a-446e-4e0c-90dc-b87e0576cf36"),
     UserID= new Guid( "8ff22c7d-18c7-4ef0-a0ac-988ecb2ac7f5"),
    TotalBill = 6679.94m,
    OrderDate= Convert.ToDateTime("2050-10-24T12:00:00Z"),
    OrderItems = new List<OrderItem>{
     new OrderItem {
        ProductID = new Guid("1a9df78b-3f46-4c3d-9f2a-1b9f69292a77"),
       UnitPrice = 1299.99m,
        Quantity = 5,
        TotalPrice = 6499.95m
      },
    new OrderItem  {
        ProductID = new Guid("4c9b6f71-6c5d-485f-8db2-58011a236b63"),
       UnitPrice = 179.99m,
        Quantity = 1,
        TotalPrice = 179.99m
      }
    }
  },
new Order
{
    OrderID = new Guid("a07e908e-57b1-49f0-b18e-4860b0948cf2"),
     UserID = new Guid("8ff22c7d-18c7-4ef0-a0ac-988ecb2ac7f5"),
    TotalBill = 859.96m,
    OrderDate = Convert.ToDateTime("2050-10-25T13:00:00Z"),
   OrderItems = new List<OrderItem>{
     new OrderItem   {
        ProductID = new Guid("3f3e8b3a-4a50-4cd0-8d8e-1e178ae2cfc1"),
       UnitPrice = 249.99m,
        Quantity = 2,
        TotalPrice = 499.98m
      },
     new OrderItem   {
        ProductID = new Guid("4c9b6f71-6c5d-485f-8db2-58011a236b63"),
       UnitPrice = 179.99m,
        Quantity = 2,
        TotalPrice = 359.98m
      }
   }
  },
new Order
{
    OrderID = new Guid("b8f3fbfc-5648-40f8-bb51-f158b32f77d9"),
     UserID = new Guid("c32f8b42-60e6-4c02-90a7-9143ab37189f"),
    TotalBill = 2849.97m,
    OrderDate = Convert.ToDateTime("2050-10-26T14:00:00Z"),
    OrderItems = new List<OrderItem>{
      new OrderItem  {
        ProductID = new Guid("1a9df78b-3f46-4c3d-9f2a-1b9f69292a77"),
       UnitPrice = 1299.99m,
        Quantity = 2,
        TotalPrice = 2599.98m
      },
      new OrderItem  {
        ProductID = new Guid("3f3e8b3a-4a50-4cd0-8d8e-1e178ae2cfc1"),
       UnitPrice = 249.99m,
        Quantity = 1,
        TotalPrice = 249.99m
      }
    }
  },
 new Order
 {
    OrderID = new Guid("c6a05e2e-81c0-4a43-80d1-8fd6936318e2"),
     UserID = new Guid("c32f8b42-60e6-4c02-90a7-9143ab37189f"),
    TotalBill = 9499.94m,
    OrderDate = Convert.ToDateTime("2050-10-27T15:00:00Z"),
   OrderItems = new List<OrderItem>{
    new OrderItem    {
        ProductID = new Guid("5d7e36bf-65c3-4a71-bf97-740d561d8b65"),
       UnitPrice = 1999.99m,
        Quantity = 1,
        TotalPrice = 1999.99m
      },
     new OrderItem   {
        ProductID = new Guid("2c8e8e7c-97a3-4b11-9a1b-4dbe681cfe17"),
       UnitPrice = 1499.99m,
        Quantity = 5,
        TotalPrice = 7499.95m
      }
   }
  },
     new Order
     {
        OrderID = new Guid("d66c9b87-0f4b-482d-b87b-fc5b96b59871"),
     UserID = new Guid("c32f8b42-60e6-4c02-90a7-9143ab37189f"),
    TotalBill = 2999.98m,
    OrderDate = Convert.ToDateTime("2050-10-28T16:00:00Z"),
    OrderItems = new List<OrderItem>{
      new OrderItem  {
        ProductID = new Guid("2c8e8e7c-97a3-4b11-9a1b-4dbe681cfe17"),
       UnitPrice = 1499.99m,
        Quantity = 1,
        TotalPrice = 1499.99m
      },
      new OrderItem  {
        ProductID = new Guid("5d7e36bf-65c3-4a71-bf97-740d561d8b65"),
       UnitPrice = 1499.99m,
        Quantity = 1,
        TotalPrice = 1499.99m
      }
    }
  },
     new Order
     {
        OrderID = new Guid("e2a3ff6b-ba0e-463e-bc07-aa4421317a53"),
     UserID = new Guid("c32f8b42-60e6-4c02-90a7-9143ab37189f"),
    TotalBill = 9679.26m,
    OrderDate = Convert.ToDateTime("2024-03-01T17:00:00Z"),
   OrderItems = new List<OrderItem>{
     new OrderItem   {
        ProductID = new Guid("5d7e36bf-65c3-4a71-bf97-740d561d8b65"),
       UnitPrice = 1999.99m,
        Quantity = 3,
        TotalPrice = 5999.97m
      },
      new OrderItem  {
        ProductID = new Guid("6a14f510-72c1-42c8-9a5a-8ef8f3f45a0d"),
       UnitPrice = 49.99m,
        Quantity = 7,
        TotalPrice = 3499.3m
      },
     new OrderItem  {
        ProductID = new Guid("4c9b6f71-6c5d-485f-8db2-58011a236b63"),
       UnitPrice = 179.99m,
        Quantity = 1,
        TotalPrice = 179.99m
      }
   }
  },

new Order
{
        OrderID = new Guid("4d9b6010-48e6-4a0e-bd4e-461c85c32c1d"),
        UserID = new Guid("c32f8b42-60e6-4c02-90a7-9143ab37189f"),
       TotalBill = 2799.98m,
       OrderDate = Convert.ToDateTime("2050-10-20T08:00:00Z"),
      OrderItems = new List<OrderItem>{
       new OrderItem {
        ProductID =new Guid("1a9df78b-3f46-4c3d-9f2a-1b9f69292a77"),
       UnitPrice = 1299.99m,
        Quantity = 1,
        TotalPrice = 1299.99m
      },
       new OrderItem {
    ProductID = new Guid("2c8e8e7c-97a3-4b11-9a1b-4dbe681cfe17"),
   UnitPrice = 1499.99m,
    Quantity = 1,
    TotalPrice = 1499.99m
      }
      }
  },
     new Order
     {
        OrderID = new Guid("62c2fb9c-b36e-497e-b0b7-f07c6c3c22b2"),
     UserID = new Guid("8ff22c7d-18c7-4ef0-a0ac-988ecb2ac7f5"),
    TotalBill = 969.95m,
    OrderDate = Convert.ToDateTime("2050-10-21T09:00:00Z"),
    OrderItems = new List<OrderItem>{
       new OrderItem {
        ProductID = new Guid("3f3e8b3a-4a50-4cd0-8d8e-1e178ae2cfc1"),
       UnitPrice = 249.99m,
        Quantity = 1,
        TotalPrice = 249.99m
      },
       new OrderItem {
        ProductID = new Guid("4c9b6f71-6c5d-485f-8db2-58011a236b63"),
       UnitPrice = 179.99m,
        Quantity = 4,
        TotalPrice = 719.96m
      }
    }
  },
     new Order
     {
        OrderID = new Guid("e3f6d6b7-bc84-48e3-8d22-961e1e084f0e"),
     UserID = new Guid("8ff22c7d-18c7-4ef0-a0ac-988ecb2ac7f5"),
    TotalBill = 5499.88m,
    OrderDate = Convert.ToDateTime("2050-10-22T10:00:00Z"),
   OrderItems = new List<OrderItem>{
       new OrderItem {
        ProductID = new Guid("3f3e8b3a-4a50-4cd0-8d8e-1e178ae2cfc1"),
       UnitPrice = 249.99m,
        Quantity = 10,
        TotalPrice = 2499.9m
      },
      new OrderItem  {
        ProductID = new Guid("2c8e8e7c-97a3-4b11-9a1b-4dbe681cfe17"),
       UnitPrice = 1499.99m,
        Quantity = 2,
        TotalPrice = 2999.98m
      }
   }
  },
     new Order
     {
        OrderID = new Guid("af168b29-b6c5-45ed-a4f1-19c04f368d1a"),
     UserID = new Guid("8ff22c7d-18c7-4ef0-a0ac-988ecb2ac7f5"),
    TotalBill = 5039.94m,
    OrderDate = Convert.ToDateTime("2050-10-23T11:00:00Z"),
   OrderItems = new List<OrderItem>{
      new OrderItem  {
        ProductID = new Guid("4c9b6f71-6c5d-485f-8db2-58011a236b63"),
       UnitPrice = 179.99m,
        Quantity = 3,
        TotalPrice = 539.97m
      },
       new OrderItem {
        ProductID = new Guid("2c8e8e7c-97a3-4b11-9a1b-4dbe681cfe17"),
       UnitPrice = 1499.99m,
        Quantity = 3,
        TotalPrice = 4499.97m
      }
   }
  },
     new Order
     {
        OrderID = new Guid("3a0e5c1a-446e-4e0c-90dc-b87e0576cf36"),
     UserID = new Guid("8ff22c7d-18c7-4ef0-a0ac-988ecb2ac7f5"),
    TotalBill = 6679.94m,
    OrderDate = Convert.ToDateTime("2050-10-24T12:00:00Z"),
   OrderItems = new List<OrderItem>{
    new OrderItem    {
        ProductID = new Guid("1a9df78b-3f46-4c3d-9f2a-1b9f69292a77"),
       UnitPrice = 1299.99m,
        Quantity = 5,
        TotalPrice = 6499.95m
      },
     new OrderItem   {
        ProductID = new Guid("4c9b6f71-6c5d-485f-8db2-58011a236b63"),
       UnitPrice = 179.99m,
        Quantity = 1,
        TotalPrice = 179.99m
      }
   }
  },
     new Order
     {
        OrderID = new Guid("a07e908e-57b1-49f0-b18e-4860b0948cf2"),
     UserID = new Guid("8ff22c7d-18c7-4ef0-a0ac-988ecb2ac7f5"),
    TotalBill = 859.96m,
    OrderDate = Convert.ToDateTime("2050-10-25T13:00:00Z"),
    OrderItems = new List<OrderItem>{
     new OrderItem   {
        ProductID = new Guid("3f3e8b3a-4a50-4cd0-8d8e-1e178ae2cfc1"),
       UnitPrice = 249.99m,
        Quantity = 2,
        TotalPrice = 499.98m
      },
   new OrderItem     {
        ProductID = new Guid("4c9b6f71-6c5d-485f-8db2-58011a236b63"),
       UnitPrice = 179.99m,
        Quantity = 2,
        TotalPrice = 359.98m
      }
    }
  },
     new Order
     {
        OrderID = new Guid("b8f3fbfc-5648-40f8-bb51-f158b32f77d9"),
     UserID = new Guid("c32f8b42-60e6-4c02-90a7-9143ab37189f"),
    TotalBill = 2849.97m,
    OrderDate = Convert.ToDateTime("2050-10-26T14:00:00Z"),
  OrderItems = new List<OrderItem>{
   new OrderItem     {
        ProductID = new Guid("1a9df78b-3f46-4c3d-9f2a-1b9f69292a77"),
       UnitPrice = 1299.99m,
        Quantity = 2,
        TotalPrice = 2599.98m
      },
     new OrderItem   {
        ProductID = new Guid("3f3e8b3a-4a50-4cd0-8d8e-1e178ae2cfc1"),
       UnitPrice = 249.99m,
        Quantity = 1,
        TotalPrice = 249.99m
      }
  }
  },
     new Order
     {
        OrderID = new Guid("c6a05e2e-81c0-4a43-80d1-8fd6936318e2"),
     UserID = new Guid("c32f8b42-60e6-4c02-90a7-9143ab37189f"),
    TotalBill = 9499.94m,
    OrderDate = Convert.ToDateTime("2050-10-27T15:00:00Z"),
   OrderItems = new List<OrderItem>{
     new OrderItem   {
        ProductID = new Guid("5d7e36bf-65c3-4a71-bf97-740d561d8b65"),
       UnitPrice = 1999.99m,
        Quantity = 1,
        TotalPrice = 1999.99m
      },
    new OrderItem    {
        ProductID = new Guid("2c8e8e7c-97a3-4b11-9a1b-4dbe681cfe17"),
       UnitPrice = 1499.99m,
        Quantity = 5,
        TotalPrice = 7499.95m
      }
   }
  },
     new Order
     {
        OrderID = new Guid("d66c9b87-0f4b-482d-b87b-fc5b96b59871"),
     UserID = new Guid("c32f8b42-60e6-4c02-90a7-9143ab37189f"),
    TotalBill = 2999.98m,
    OrderDate = Convert.ToDateTime("2050-10-28T16:00:00Z"),
    OrderItems = new List<OrderItem>{
     new OrderItem    {
        ProductID = new Guid("2c8e8e7c-97a3-4b11-9a1b-4dbe681cfe17"),
       UnitPrice = 1499.99m,
        Quantity = 1,
        TotalPrice = 1499.99m
      },
    new OrderItem     {
        ProductID = new Guid("5d7e36bf-65c3-4a71-bf97-740d561d8b65"),
       UnitPrice = 1499.99m,
        Quantity = 1,
        TotalPrice = 1499.99m
      }
    }
  },
     new Order
     {
        OrderID = new Guid("e2a3ff6b-ba0e-463e-bc07-aa4421317a53"),
     UserID = new Guid("c32f8b42-60e6-4c02-90a7-9143ab37189f"),
    TotalBill = 9679.26m,
    OrderDate = Convert.ToDateTime("2024-03-01T17:00:00Z"),
     OrderItems = new List<OrderItem>{
       new OrderItem  {
        ProductID = new Guid("5d7e36bf-65c3-4a71-bf97-740d561d8b65"),
       UnitPrice = 1999.99m,
        Quantity = 3,
        TotalPrice = 5999.97m
      },
     new OrderItem   {
        ProductID = new Guid("6a14f510-72c1-42c8-9a5a-8ef8f3f45a0d"),
       UnitPrice = 49.99m,
        Quantity = 7,
        TotalPrice = 3499.3m
      },
     new OrderItem   {
        ProductID = new Guid("4c9b6f71-6c5d-485f-8db2-58011a236b63"),
       UnitPrice = 179.99m,
        Quantity = 1,
        TotalPrice = 179.99m
      }
     }
  }
    };
    public async Task<Order?> AddOrder(Order order)
  {
    order.OrderID = Guid.NewGuid();
    order._id = order.OrderID;

    foreach (OrderItem orderItem in order.OrderItems)
    {
      orderItem._id = Guid.NewGuid();
    }

    await _orders.InsertOneAsync(order);
    return order;
  }


  public async Task<bool> DeleteOrder(Guid orderID)
  {
    FilterDefinition<Order> filter = Builders<Order>.Filter.Eq(temp => temp.OrderID, orderID);

    Order? existingOrder = (await _orders.FindAsync(filter)).FirstOrDefault();

    if (existingOrder == null) {
      return false;
    }

    DeleteResult deleteResult = await _orders.DeleteOneAsync(filter);

    return deleteResult.DeletedCount > 0;
  }


  public async Task<Order?> GetOrderByCondition(FilterDefinition<Order> filter)
  {
    return (await _orders.FindAsync(filter)).FirstOrDefault();
  }


  public async Task<IEnumerable<Order>> GetOrders()
  {
        if (ISConnectionEstablished())
        {
            //var v= (await _orders.FindAsync(Builders<Order>.Filter.Empty)).ToList();
            return (await _orders.FindAsync(Builders<Order>.Filter.Empty)).ToList();
        }
        else {
            return ordersData.ToList();
        }
  }


  public async Task<IEnumerable<Order?>> GetOrdersByCondition(FilterDefinition<Order> filter)
  {
    //return (await _orders.FindAsync(filter)).ToList();

        if (ISConnectionEstablished())
        {
            return (await _orders.FindAsync(Builders<Order>.Filter.Empty)).ToList();
        }
        else
        {
            return ordersData.ToList();
        }
    }


  public async Task<Order?> UpdateOrder(Order order)
  {
    FilterDefinition<Order> filter = Builders<Order>.Filter.Eq(temp => temp.OrderID, order.OrderID);

    Order? existingOrder = (await _orders.FindAsync(filter)).FirstOrDefault();

    if (existingOrder == null)
    {
      return null;
    }
    order._id = existingOrder._id;

    ReplaceOneResult replaceOneResult = await _orders.ReplaceOneAsync(filter, order);

    return order;
  }
    public bool ISConnectionEstablished()
    {
        if (Environment.GetEnvironmentVariable("MONGODB_HOST") != null && Environment.GetEnvironmentVariable("MONGODB_PORT") != null)
        {

            var state = _orders.Database.Client.Cluster.Description.State;
            //Cluster.Description.State;
            if (state == MongoDB.Driver.Core.Clusters.ClusterState.Connected)
                return true;
            else
                return false;
        }
        else
        {
            return false;

        }
    }
}

