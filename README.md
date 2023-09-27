# ECommerceTemplate

* ?Adding products to the cart and deleting the product in the cart for those who log in with the user role

```
List<Product> graphicsCardProducts = _productRepository.GetAll(includeProps: "ProductType")
.Where(p => p.ProductType != null && p.ProductType.Type == "Graphics Card")
.ToList();
```
- includeProps > Foreign Key
```
@model List<Product>
@if (Model.Count > 0)
{

}

else
{

}
```
# DBCC CHECKIDENT ('TableName', RESEED, 0);



![1](https://github.com/eraybahcegulu/ECommerceTemplate-MVC/assets/84785201/3b37f38d-7494-4188-ac0c-42f4bdaffe66)

![2](https://github.com/eraybahcegulu/ECommerceTemplate-MVC/assets/84785201/32f79121-b89f-4e16-abd1-054726983f04)

![3](https://github.com/eraybahcegulu/ECommerceTemplate-MVC/assets/84785201/c3a011d0-5529-4074-bc58-d4a5c27b1213)

![4](https://github.com/eraybahcegulu/ECommerceTemplate-MVC/assets/84785201/373dbcf3-6ea9-427c-a8fc-f0c569495d5f)

![5](https://github.com/eraybahcegulu/ECommerceTemplate-MVC/assets/84785201/ed41d351-c56e-403e-ab6c-7bd97f01de02)

![6](https://github.com/eraybahcegulu/ECommerceTemplate-MVC/assets/84785201/20f8196d-4769-4e5a-94e3-040b6c836636)

![7](https://github.com/eraybahcegulu/ECommerceTemplate-MVC/assets/84785201/a3267496-ec5b-4984-b6d4-403784d85f5d)
