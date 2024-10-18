﻿using Model.Dtos;
using Model.Entities;

namespace Business.Abstract
{
    public interface ICategoryManager
    {
        Task<List<Category>> GetCategories(params string[] includeList);
        Task<Category> GetById(int id, params string[] includeList);
        Task Insert(CategoryAddDto dto);
        Task Update(CategoryEditDto dto);
        Task<bool> Delete(int id);
    }
}