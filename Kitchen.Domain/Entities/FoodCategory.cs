﻿namespace Kitchen.Domain.Entities
{
    public class FoodCategory
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid ProjectId { get; set; }

        public FoodCategory()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
