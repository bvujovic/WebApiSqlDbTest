﻿namespace WebApiSqlDbTest.Data.DTOs
{
    public class UserPublic
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; } = default!;
        public string FullName { get; set; } = default!;
    }
}
