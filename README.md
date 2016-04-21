

#### .Net GridView MongoDB CSharp 

An example of GridView pagination of : 

```
1 2 3 4 5 .. Last 
First .. 6 7 8 9 10 .. Last
First .. 21 22 23 24 25 
```


#### How do I try it ?

1. Create a new WebSite project in Visual Studio, and swap the Default.* with these files. 
2. Run MongoDB instance locally with data in `test.products` structured as: 

```
{
    "_id" : ObjectId(),
    "ProductName": "Name", 
    "PurchaseDate": "Date", 
    "Price": Int

}
```

Tested with: 

* .Net v4.5.2
* mongocsharpdriver-2.2.3
* MongoDB v3.0.x

