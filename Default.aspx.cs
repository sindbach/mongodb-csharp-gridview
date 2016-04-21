using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoDB.Bson;
using MongoDB.Driver;


public static class Globals
{
    static Globals() {
           GlobalCurrentId = ObjectId.Parse("000000000000000000000000");
           PageSize = 15;
           CurrentIndex = 0;
    }
    public static ObjectId GlobalCurrentId { get; private set; }
    public static int PageSize { get; set; }
    public static int CurrentIndex { get; set; }
    public static void SetGlobalCurrentId(ObjectId currentId)
    {
        GlobalCurrentId = currentId;
    }
}

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPaging_GridView.VirtualItemCount = GetTotalCount();
            Globals.SetGlobalCurrentId(GetCurrentId());
            GetPageData(0, Globals.PageSize);
        }
    }


    public static IMongoCollection<Product> GetCollection()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("test");
        var collection = database.GetCollection<Product>("products");
        return collection;
    }


    public class Product
    {
        public ObjectId Id { get; set; }
        public string ProductName { get; set; }
        public string PurchaseDate { get; set; }
        public float Price { get; set; }
    }

    private int GetTotalCount()
    {
        var collection = GetCollection();
        return unchecked((int)collection.Count(new BsonDocument()));
    }

    private ObjectId GetCurrentId()
    {
        var collection = GetCollection();
        var sort = Builders<Product>.Sort.Descending("_id");
        var currentId = collection.Find<Product>(new BsonDocument()).Sort(sort).FirstOrDefault();
        return currentId.Id;
    }

    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CustomPaging_GridView.PageIndex = e.NewPageIndex;
        GetPageData(e.NewPageIndex, Globals.PageSize);
    }
    public void GetPageData(int current, int pagesize)
    {
        var collection = GetCollection();
        var sort = Builders<Product>.Sort.Descending("_id");
        var currentId = Globals.GlobalCurrentId;
        var filter = Builders<Product>.Filter.Lte("_id", currentId);
        IEnumerable<Product> query = collection.Find(filter)
                                                .Skip(current * Globals.PageSize)
                                                .Limit(Globals.PageSize)
                                                .Sort(sort).ToList();
        if (Globals.CurrentIndex > current)
        {
            filter = Builders<Product>.Filter.Gte("_id", currentId);
            query = collection.Find(filter)
                                                   .Skip(current * Globals.PageSize)
                                                   .Limit(Globals.PageSize)
                                                   .Sort(sort).ToList();
        }
        Globals.CurrentIndex = current;
        List<Product> productList = query.ToList();
        Globals.SetGlobalCurrentId(productList.First().Id);
    
        CustomPaging_GridView.DataSource = productList;
        CustomPaging_GridView.DataBind();
    }
}