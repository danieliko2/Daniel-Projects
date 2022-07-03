using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() 
    {
        return "Hello World";
    }
    [WebMethod]
    public DataSet GetAllProducts()
    {
        ProductService pservice = new ProductService();
        return pservice.GetAllProducts();
    }
    [WebMethod]
    public ProductDetails GetProductByID(int id)
    {
        ProductService pservice = new ProductService();
        return pservice.GetProductByID(id);
    }
    [WebMethod]
    public DataSet GetProductByKindID(int kindid)
    {
        ProductService pservice = new ProductService();
        return pservice.GetProductsByKindID(kindid);
    }
    [WebMethod]
    public void AddProduct(ProductDetails product)
    {
        product.UnitsInOrder = 0;
        ProductService psrvs = new ProductService();
        psrvs.AddProduct(product);
    }
    [WebMethod]
    public void UpdateProduct(ProductDetails product)
    {
        ProductService srvs = new ProductService();
        srvs.UpdateProduct(product);
    }
    [WebMethod]
    public void DeleteProduct(int productid)
    {
        ProductService srvs = new ProductService();
        srvs.DeleteProduct(productid);
    }
    
}
