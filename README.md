# ECommerceTemplate
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
