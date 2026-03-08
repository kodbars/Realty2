namespace RealtyWeb_Client.Models
{
    public class SequrityToken
    {
        public string UserName { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public DateTime ExpiretAt {  get; set; } 
    }
}
