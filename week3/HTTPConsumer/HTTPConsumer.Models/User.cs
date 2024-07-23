namespace HTTPConsumer.Models;

public class User
{
    // Fields
    public int id { get; set; }
    public string name { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public Address adress { get; set; }
    public string phone { get; set; }
    public string website { get; set; }
    public Company company{ get; set; }

}
