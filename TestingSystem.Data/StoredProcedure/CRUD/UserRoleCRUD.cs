﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    class UserRoleCRUD
    {
        public int Create(UserRoleDTO userRole)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_Create @RoleID,@UserID";
                return connection.Query<int>(sqlExpression, userRole).FirstOrDefault();
            }
           
        }
        public int Delete(UserRoleDTO userRole)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_Delete @UserID, @RoleID";
                return connection.Query<int>(sqlExpression, userRole).FirstOrDefault();
            }
        }
        public List<UserRoleDTO> Read()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_Read";
                return connection.Query<UserRoleDTO>(sqlExpression).ToList();
            }
        }
        public List<UserRoleDTO> ReadByUserID(int userRole)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_ReadByUserID @UserID";
                return connection.Query<UserRoleDTO>(sqlExpression,new { userRole }).ToList();
            }
        }
        public List<UserRoleDTO> ReadByRoleID(int roleID)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_ReadByRoleID @RoleID";
                return connection.Query<UserRoleDTO>(sqlExpression, new {roleID }).ToList();
            }
        }
        
        public List<UserDTO> GetUsersByRoleID(int roleID)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetUsersByRoleId";
                return connection.Query<UserDTO>(sqlExpression, new { roleID }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
