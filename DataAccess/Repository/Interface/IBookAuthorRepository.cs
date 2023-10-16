﻿using BusinessObject;

namespace DataAccess.Repository.Interface;

public interface IBookAuthorRepository
{
    void Add(BookAuthor bookAuthor);
    void Update(BookAuthor bookAuthor);
    void Delete(int Aid, int Bid);
    BookAuthor Get(int Aid, int Bid);
    IEnumerable<BookAuthor> GetAll();
}