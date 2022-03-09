using System;

namespace JWT_TokenAuth.Models
{
    public class Token
    {
        public string Value { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}