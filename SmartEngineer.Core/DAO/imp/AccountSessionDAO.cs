﻿using System;
using SmartEngineer.Core.DAO;
using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;

namespace SmartEngineer.Core.DAOs
{
    public class AccountSessionDAO<T> : BaseDAO<T>, IAccountSessionDAO<T>
        where T : AccountSession
    {
        public override string TableName
        {
            get
            {
                return "sys_AccountSession";
            }
        }

        public override T Insert(T entity)
        {
            entity.ID = this.NewID();
            base.Insert(entity);

            return entity;
        }
    }
}
