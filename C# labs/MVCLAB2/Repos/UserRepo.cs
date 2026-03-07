using Microsoft.EntityFrameworkCore;
using MVCLAB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MVCLAB2.Repos
{
    public class UserRepo : IEntities<User>
    {
        ITIContextcs context;

        public UserRepo(ITIContextcs context)
        {
            this.context = context;
        }
        public void Add(User entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var isExist = context.users.Find(id);
            if (isExist == null)
            {
                throw new System.Exception("User not found");
            }
            else
            {
                context.users.Remove(isExist);
                context.SaveChanges();
            }
        }

        public List<User> GetAll(Expression<Func<User, bool>>? filter = null)
        {
            if (filter != null)
            {
                return context.users.Where(filter).Include(u => u.userRoles).ThenInclude(ur => ur.role).ToList();
            }
            return context.users.Include(u => u.userRoles).ThenInclude(ur => ur.role).ToList();
        }

        public User GetById(int id)
        {
            return context.users.Include(u => u.userRoles).ThenInclude(ur => ur.role).FirstOrDefault(u => u.id == id);
        }

        public void Update(User entity)
        {
            context.users.Update(entity);
            context.SaveChanges();
        }
    }
}
