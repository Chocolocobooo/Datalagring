﻿using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerEntity? Create(CustomerRegistrationForm form) => form == null ? null : new()
    {
        CustomerName = form.CustomerName,
    };

    public static Customer? Create(CustomerEntity entity) => entity == null ? null : new() 
    {
        Id = entity.Id,
        CustomerName = entity.CustomerName,
    };

    public static Customer? Update(CustomerEntity entity) => entity == null ? null : new() 
    {
        CustomerName = entity.CustomerName,
    };

    public static Customer? Delete(CustomerEntity entity) => entity == null ? null : new()
    {
        Id = entity.Id,
    };

}
