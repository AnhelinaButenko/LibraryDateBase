﻿namespace Domains;

public class AuthorBook : BaseEntity
{
    public int AuthorId { get; set; }

    public int BookId { get; set; }

    public int PublisherId { get; set; }
}
