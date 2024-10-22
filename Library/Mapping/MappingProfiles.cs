﻿using AutoMapper;
using Library.Domain;
using Library.Dto;

namespace Library.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Borrow, BorrowDto>();
            CreateMap<BorrowDto, Borrow>();

            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();


        }
           


    }
}
