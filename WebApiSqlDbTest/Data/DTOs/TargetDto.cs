﻿
namespace WebApiSqlDbTest.Data.DTOs
{
    public class TargetDto : TargetDtoBase
    {
        public int TargetId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int OwnerId { get; set; }
    }
}
