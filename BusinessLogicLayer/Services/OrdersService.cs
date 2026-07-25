using AutoMapper;
using eCommerce.OrdersMicroservice.BusinessLogicLayer.DTO;
using eCommerce.OrdersMicroservice.BusinessLogicLayer.HttpClients;
using eCommerce.OrdersMicroservice.BusinessLogicLayer.ServiceContracts;
using eCommerce.OrdersMicroservice.DataAccessLayer.Entities;
using eCommerce.OrdersMicroservice.DataAccessLayer.RepositoryContracts;
using FluentValidation;
using FluentValidation.Results;
using MongoDB.Driver;

namespace eCommerce.ordersMicroservice.BusinessLogicLayer.Services;

public class OrdersService : IOrdersService
{
  private readonly IValidator<OrderAddRequest> _orderAddRequestValidator;
  private readonly IValidator<OrderItemAddRequest> _orderItemAddRequestValidator;
  private readonly IValidator<OrderUpdateRequest> _orderUpdateRequestValidator;
  private readonly IValidator<OrderItemUpdateRequest> _orderItemUpdateRequestValidator;
  private readonly IMapper _mapper;
  private IOrdersRepository _ordersRepository;
  private UsersMicroserviceClient _usersMicroserviceClient;
  private ProductsMicroserviceClient _productsMicroserviceClient;
    List<Order> orderdata = new List<Order> {
 new Order {
      OrderID=  new Guid("4d9b6010-48e6-4a0e-bd4e-461c85c32c1d"),
      UserID= new Guid("34ee5c28-1d69-4517-9a7e-712027aa3bf9"),
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

    public OrdersService(IOrdersRepository ordersRepository, IMapper mapper, IValidator<OrderAddRequest> orderAddRequestValidator, IValidator<OrderItemAddRequest> orderItemAddRequestValidator, IValidator<OrderUpdateRequest> orderUpdateRequestValidator, IValidator<OrderItemUpdateRequest> orderItemUpdateRequestValidator, UsersMicroserviceClient usersMicroserviceClient,ProductsMicroserviceClient productsMicroserviceClient)
  {
    _orderAddRequestValidator = orderAddRequestValidator;
    _orderItemAddRequestValidator = orderItemAddRequestValidator;
    _orderUpdateRequestValidator = orderUpdateRequestValidator;
    _orderItemUpdateRequestValidator = orderItemUpdateRequestValidator;
    _mapper = mapper;
    _ordersRepository = ordersRepository;
    _usersMicroserviceClient = usersMicroserviceClient;
	  _productsMicroserviceClient = productsMicroserviceClient;
  }


  public async Task<OrderResponse?> AddOrder(OrderAddRequest orderAddRequest)
  {
    //Check for null parameter
    if (orderAddRequest == null)
    {
      throw new ArgumentNullException(nameof(orderAddRequest));
    }


    //Validate OrderAddRequest using Fluent Validations
    ValidationResult orderAddRequestValidationResult = await _orderAddRequestValidator.ValidateAsync(orderAddRequest);
    if (!orderAddRequestValidationResult.IsValid)
    {
      string errors = string.Join(", ", orderAddRequestValidationResult.Errors.Select(temp => temp.ErrorMessage));
      throw new ArgumentException(errors);
    }

    List<ProductDTO?> products = new List<ProductDTO?>();

    //Validate order items using Fluent Validation
    foreach (OrderItemAddRequest orderItemAddRequest in orderAddRequest.OrderItems)
    {
      ValidationResult orderItemAddRequestValidationResult = await _orderItemAddRequestValidator.ValidateAsync(orderItemAddRequest);

      if (!orderItemAddRequestValidationResult.IsValid)
      {
        string errors = string.Join(", ", orderItemAddRequestValidationResult.Errors.Select(temp => temp.ErrorMessage));
        throw new ArgumentException(errors);
      }


      //TO DO: Add logic for checking if ProductID exists in Products microservice
      ProductDTO? product = await _productsMicroserviceClient.GetProductByProductID(orderItemAddRequest.ProductID);
      if (product == null)
      {
        throw new ArgumentException("Invalid Product ID");
      }

      products.Add(product);
    }

    //TO DO: Add logic for checking if UserID exists in Users microservice
    UserDTO? user = await _usersMicroserviceClient.GetUserByUserID(orderAddRequest.UserID);
    if (user == null)
    {
      throw new ArgumentException("Invalid User ID");
    }


    //Convert data from OrderAddRequest to Order
    Order orderInput = _mapper.Map<Order>(orderAddRequest); //Map OrderAddRequest to 'Order' type (it invokes OrderAddRequestToOrderMappingProfile class)

    //Generate values
    foreach (OrderItem orderItem in orderInput.OrderItems)
    {
      orderItem.TotalPrice = orderItem.Quantity * orderItem.UnitPrice;
    }
    orderInput.TotalBill = orderInput.OrderItems.Sum(temp => temp.TotalPrice);


    //Invoke repository
    Order? addedOrder = await _ordersRepository.AddOrder(orderInput);

    if (addedOrder == null)
    {
      return null;
    }

    OrderResponse addedOrderResponse = _mapper.Map<OrderResponse>(addedOrder); //Map addedOrder ('Order' type) into 'OrderResponse' type (it invokes OrderToOrderResponseMappingProfile).

    //TO DO: Load ProductName and Category in OrderItem
    if (addedOrderResponse != null)
    {
      foreach (OrderItemResponse orderItemResponse in addedOrderResponse.OrderItems)
      {
        ProductDTO? productDTO = products.Where(temp => temp.ProductID == orderItemResponse.ProductID).FirstOrDefault();

        if (productDTO == null)
          continue;

        _mapper.Map<ProductDTO, OrderItemResponse>(productDTO, orderItemResponse);
      }
    }



    //TO DO: Load UserPersonName and Email from Users Microservice
    if (addedOrderResponse != null)
    {
      if (user != null)
      {
        _mapper.Map<UserDTO, OrderResponse>(user, addedOrderResponse);
      }
    }

    return addedOrderResponse;
  }


    public async Task<OrderResponse?> UpdateOrder(OrderUpdateRequest orderUpdateRequest)
  {
    //Check for null parameter
    if (orderUpdateRequest == null)
    {
      throw new ArgumentNullException(nameof(orderUpdateRequest));
    }


    //Validate OrderAddRequest using Fluent Validations
    ValidationResult orderUpdateRequestValidationResult = await _orderUpdateRequestValidator.ValidateAsync(orderUpdateRequest);
    if (!orderUpdateRequestValidationResult.IsValid)
    {
      string errors = string.Join(", ", orderUpdateRequestValidationResult.Errors.Select(temp => temp.ErrorMessage));
      throw new ArgumentException(errors);
    }

    List<ProductDTO> products = new List<ProductDTO>();

    //Validate order items using Fluent Validation
    foreach (OrderItemUpdateRequest orderItemUpdateRequest in orderUpdateRequest.OrderItems)
    {
      ValidationResult orderItemUpdateRequestValidationResult = await _orderItemUpdateRequestValidator.ValidateAsync(orderItemUpdateRequest);

      if (!orderItemUpdateRequestValidationResult.IsValid)
      {
        string errors = string.Join(", ", orderItemUpdateRequestValidationResult.Errors.Select(temp => temp.ErrorMessage));
        throw new ArgumentException(errors);
      }


      //TO DO: Add logic for checking if ProductID exists in Products microservice
      ProductDTO? product = await _productsMicroserviceClient.GetProductByProductID(orderItemUpdateRequest.ProductID);
      if (product == null)
      {
        throw new ArgumentException("Invalid Product ID");
      }

      products.Add(product);
    }

    //TO DO: Add logic for checking if UserID exists in Users microservice
    UserDTO? user = await _usersMicroserviceClient.GetUserByUserID(orderUpdateRequest.UserID);
    if (user == null)
    {
      throw new ArgumentException("Invalid User ID");
    }


    //Convert data from OrderUpdateRequest to Order
    Order orderInput = _mapper.Map<Order>(orderUpdateRequest); //Map OrderUpdateRequest to 'Order' type (it invokes OrderUpdateRequestToOrderMappingProfile class)

    //Generate values
    foreach (OrderItem orderItem in orderInput.OrderItems)
    {
      orderItem.TotalPrice = orderItem.Quantity * orderItem.UnitPrice;
    }
    orderInput.TotalBill = orderInput.OrderItems.Sum(temp => temp.TotalPrice);


    //Invoke repository
    Order? updatedOrder = await _ordersRepository.UpdateOrder(orderInput);

    if (updatedOrder == null)
    {
      return null;
    }

    OrderResponse updatedOrderResponse = _mapper.Map<OrderResponse>(updatedOrder); //Map updatedOrder ('Order' type) into 'OrderResponse' type (it invokes OrderToOrderResponseMappingProfile).


    //TO DO: Load ProductName and Category in OrderItem
    if (updatedOrderResponse != null)
    {
      foreach (OrderItemResponse orderItemResponse in updatedOrderResponse.OrderItems)
      {
        ProductDTO? productDTO = products.Where(temp => temp.ProductID == orderItemResponse.ProductID).FirstOrDefault();

        if (productDTO == null)
          continue;

        _mapper.Map<ProductDTO, OrderItemResponse>(productDTO, orderItemResponse);
      }
    }


    //TO DO: Load UserPersonName and Email from Users Microservice
    if (updatedOrderResponse != null)
    {
      if (user != null)
      {
        _mapper.Map<UserDTO, OrderResponse>(user, updatedOrderResponse);
      }
    }

    return updatedOrderResponse;
  }


  public async Task<bool> DeleteOrder(Guid orderID)
  {
    FilterDefinition<Order> filter = Builders<Order>.Filter.Eq(temp => temp.OrderID, orderID);
    Order? existingOrder = await _ordersRepository.GetOrderByCondition(filter);

    if (existingOrder == null)
    {
      return false;
    }


    bool isDeleted = await _ordersRepository.DeleteOrder(orderID);
    return isDeleted;
  }


  public async Task<OrderResponse?> GetOrderByCondition(FilterDefinition<Order> filter)
  {
    Order? order = await _ordersRepository.GetOrderByCondition(filter);
    if (order == null)
      return null;

    OrderResponse orderResponse = _mapper.Map<OrderResponse>(order);


    //TO DO: Load ProductName and Category in OrderItem
    if (orderResponse != null)
    {
      foreach (OrderItemResponse orderItemResponse in orderResponse.OrderItems)
      {
        ProductDTO? productDTO = await _productsMicroserviceClient.GetProductByProductID(orderItemResponse.ProductID);

        if (productDTO == null)
          continue;

        _mapper.Map<ProductDTO, OrderItemResponse>(productDTO, orderItemResponse);
      }
    }


    //TO DO: Load UserPersonName and Email from Users Microservice
    if (orderResponse != null)
    {
      UserDTO? user = await _usersMicroserviceClient.GetUserByUserID(orderResponse.UserID);
      if (user != null)
      {
        _mapper.Map<UserDTO, OrderResponse>(user, orderResponse);
      }
    }

    return orderResponse;
  }



  public async Task<List<OrderResponse?>> GetOrdersByCondition(FilterDefinition<Order> filter)
  {
    IEnumerable<Order?> orders = await _ordersRepository.GetOrdersByCondition(filter);
    

    IEnumerable<OrderResponse?> orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(orders); 
	//TO DO: Load ProductName and Category in each OrderItem
    foreach (OrderResponse? orderResponse in orderResponses)
    {
      if (orderResponse == null)
      {
        continue;
      }

      foreach (OrderItemResponse orderItemResponse in orderResponse.OrderItems)
      {
        ProductDTO? productDTO = await _productsMicroserviceClient.GetProductByProductID(orderItemResponse.ProductID);

        if (productDTO == null)
          continue;

        _mapper.Map<ProductDTO, OrderItemResponse>(productDTO, orderItemResponse);
      }


      //TO DO: Load UserPersonName and Email from Users Microservice
      UserDTO? user = await _usersMicroserviceClient.GetUserByUserID(orderResponse.UserID);
      if (user != null)
      {
        _mapper.Map<UserDTO, OrderResponse>(user, orderResponse);
      }
    }
    return orderResponses.ToList();
  }


  public async Task<List<OrderResponse?>> GetOrders()
  {
    IEnumerable<Order?> orders = await _ordersRepository.GetOrders();


    IEnumerable<OrderResponse?> orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(orders);
	 //TO DO: Load ProductName and Category in each OrderItem
    foreach (OrderResponse? orderResponse in orderResponses)
    {
      if (orderResponse == null)
      {
        continue;
      }

      foreach (OrderItemResponse orderItemResponse in orderResponse.OrderItems)
      {
        ProductDTO? productDTO = await _productsMicroserviceClient.GetProductByProductID(orderItemResponse.ProductID);

        if (productDTO == null)
          continue;

        _mapper.Map<ProductDTO, OrderItemResponse>(productDTO, orderItemResponse);
      }


      //TO DO: Load UserPersonName and Email from Users Microservice
      UserDTO? user = await _usersMicroserviceClient.GetUserByUserID(orderResponse.UserID);
      if (user != null)
      {
        _mapper.Map<UserDTO, OrderResponse>(user, orderResponse);
      }
    }
    return orderResponses.ToList();
  }

    public async Task<OrderResponse> GetOrderDetails(Guid orderID)
    {
        await Task.Delay(100);
        OrderResponse filteredOrders = _mapper.Map<OrderResponse>(orderdata.FirstOrDefault(temp => temp.OrderID == orderID));
        return filteredOrders;
    }

    public async Task<List<OrderResponse?>> GetOrderbyDetails(Guid orderID)
    {
        await Task.Delay(100);
        var ordersByproduct = (orderdata.Where(temp => temp.OrderItems.Any(tempProduct => tempProduct.ProductID == orderID)));
        IEnumerable<OrderResponse?> orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(ordersByproduct);
        return orderResponses.ToList();
    }
    public async Task<List<OrderResponse?>> GetOrderbyUser(Guid userId)
    {
        await Task.Delay(100);
        var orders = orderdata.Where(o => o.UserID == userId);
        var orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(orders).ToList();
        return orderResponses;
    }
}