public class Account
{
    public int AccountId { get; set; }
    public int UserId { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public string Currency { get; set; }
    public DateTime CreatedAt { get; set; }

    public override string ToString()
    {
        return $"ID: {AccountId}, UserID: {UserId}, Number: {AccountNumber}, Balance: {Balance} {Currency}, Created: {CreatedAt}";
    }
}
