﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Data;
using TestingSystem.Data.DTO;
using Dapper;
using TestingSystem.Data.StoredProcedure;

namespace TestingSystem.Data
{
    public class TeacherDataAccess
    {

        public List<GroupDTO> GetGroupByTeacherID(UserDTO user)
        {
            GroupManager teacher = new GroupManager();
            SqlConnection connection = (SqlConnection)Connection.GetConnection();
            return teacher.GetGroupByTeacherID(user);
        }

        public List<UserDTO> GetStudentsFromGroup(int id)
        {
            GroupManager teacher = new GroupManager();
            return teacher.GetAllStudents(id);

        }
        

        public List<QuestionDTO> GetQuestionsByTestID(int id)
        {
            QuestionManager teacher = new QuestionManager();
            return teacher.GetQuestionsByTestID(id);

        }


        public List<Question_AnswerDTO> GetCorrectAnswerByTestID(TestDTO test)
        {
            TestManager teacher = new TestManager();
            return teacher.GetCorrectAnswerByTestID( test);

        }

        public List<TestDTO> GetTestByGroupId(int GroupID)
        {
            TestManager teacher = new TestManager();
            return teacher.GetTestByGroupId(GroupID);
        }

        
        public List<AllStudentTestsDTO> GetAllStudentTests(int id)
        {
            UserManager teacher = new UserManager();
            return teacher.GetStudentVsTests(id);

        }


        public List<TestDTO> GetExpiredTestOfStudent(UserDTO user)
        {
            TestManager teacher = new TestManager();
            return teacher.GetLateAttempt( user);

        }

        public List<FeedbackByTestIDDTO> GetFeedbackByTestID(FeedbackByTestIDDTO feedback)
        {
            FeedbackManager teacher = new FeedbackManager();
            return teacher.GetFeedbackByTest(feedback);

        }


        public List<TestAttemptDTO> GetStudentIncompleteTests(int id)
        {
            UserManager teacher = new UserManager();
            return teacher.GetIncompleteTests(id);

        }


      

        public List<Question_AnswerDTO> GetQuestionAndAnswerByAttempt(AttemptDTO attempt)
        {
            TestManager teacher = new TestManager();
            return teacher.GetQuestionAndAnswerFromAttempt(attempt);

        }



        //Лучшая попытка конкретного теста конкретного юзера

        //Лучшие Результаты всех студентов для тестов группы   Test_BestGroupResult
        //Лучшие Результаты всех студентов для теста   GetStudentVsTests  ??


        public List<AttemptResultDTO> GetAttemptByUserIdTestId(UserIdTestIdDTO attempt)
        {
            AttemptManager teacher = new AttemptManager();
            return teacher.GetAttemptByUserIdTestId(attempt);

        }

        public List<SearchTestByTagDTO> GetTestVSTagSearchOr(string tag1, string tag2, string tag3)
        {
            TestManager teacher = new TestManager();
            return teacher.GetTestVSTagSearchOr(tag1, tag2, tag3);

        }

        public List<SearchTestByTagDTO> GetTestVSTagSearchAnd(string tag1, string tag2, string tag3)
        {
            TestManager teacher = new TestManager();
            return teacher.GetTestVSTagSearchAnd(tag1, tag2, tag3);

        }
        public List<TestDTO> GetTestByTagpAndGroup(TagGroupNamesDTO names)
        {
            TestManager teacher = new TestManager();
            return teacher.GetTestByTagpAndGroup(names);

        }

        
    }
}