﻿namespace TodoList.Models.Entites;

public sealed class Todo
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsEnd { get; set; } 

    public DateTime DateEnd { get; set; }

    public int CategoryId { get; set; }

    public required Category Category { get; set; }

}
