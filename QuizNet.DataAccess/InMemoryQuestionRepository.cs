using QuizNet.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizNet.DataAccess
{
    public class InMemoryQuestionRepository : IQuestionRepository
    {
        //public IEnumerable<Question> GetAll()
        //{
        //    return _questions;
        //}

        //public Question GetById(int id)
        //{
        //    return _questions.SingleOrDefault(x => x.Id == id);
        //}

        //public void Add(Question question)
        //{
        //    var newQuestionId = _questions.Last().Id + 1;
        //    question.Id = newQuestionId;

        //    var lastAnswerId = _questions.LastOrDefault().
        //        Answers.LastOrDefault().Id;


        //    for (int i = 0; i < question.Answers.Length; i++)
        //    {
        //        question.Answers[i].Id = lastAnswerId + i + 1;
        //        question.Answers[i].QuestionId = newQuestionId;
        //    }

        //    _questions.Add(question);
        //}

        //public void Update(Question updatedQuestion)
        //{
        //    var questionToEdit = _questions.FirstOrDefault(q => q.Id == updatedQuestion.Id);
        //    questionToEdit.Text = updatedQuestion.Text;
        //    questionToEdit.CorrectAnswerIndex = updatedQuestion.CorrectAnswerIndex;

        //    for (int i = 0; i < updatedQuestion.Answers.Length; i++)
        //    {
        //        questionToEdit.Answers[i].Text = updatedQuestion.Answers[i].Text;
        //    }
        //}

        //public void Delete(int questionId)
        //{
        //    var question = _questions.SingleOrDefault(x => x.Id == questionId);
        //    _questions.Remove(question);
        //}
        public IEnumerable<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public Question GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Question question)
        {
            throw new NotImplementedException();
        }

        public void Update(Question updatedQuestion)
        {
            throw new NotImplementedException();
        }

        public void Delete(int questionId)
        {
            throw new NotImplementedException();
        }
    }
}
