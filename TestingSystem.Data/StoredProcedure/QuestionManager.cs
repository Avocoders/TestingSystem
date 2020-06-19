﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public class QuestionManager
    {
        public int DeleteQuestionFromTest(int questionId)
        {
            var connection = Connection.GetConnection();
            IDbTransaction transaction = connection.BeginTransaction();
            string sqlExpression = "Question_DeleteFromTest";
            try
            {
                connection.Execute(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure);
                transaction.Commit();
                return questionId;
            }
            catch
            {
                transaction.Rollback();
                return 0;
            }            
        }

        public List<QuestionDTO> GetQuestionsByTestID(int testId)
        {
            using (IDbConnection connection = Connection.GetConnection()) 
            { 
                string sqlExpression = "GetQuestionsByTestID";
                return connection.Query<QuestionDTO>(sqlExpression, new { testId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        
        public void CountQtyOfCorrectAnswer(int questionId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "CountQtyCorrectAnswers";
            connection.Execute(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure);
        }
        public void UpdateRightAnswer(int id, string value)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();
                string sqlExpression = "UpdateRightAnswer";
                try
                {
                    connection.Execute(sqlExpression, new { id, value }, commandType: CommandType.StoredProcedure);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
