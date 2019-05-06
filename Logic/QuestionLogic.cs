﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Interfaces;
using Logic.Abstracts;
using Logic.Interfaces;
using Models.Models;

namespace Logic
{
    public class QuestionLogic : BasicCrudLogicAbstract<Question>, IQuestionLogic
    {
        private readonly IQuestionDal _questionDal;

        public QuestionLogic(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        protected override IBasicCrudDal<Question> GetBasicCrudDal()
        {
            return _questionDal;
        }

        /// <summary>
        ///     Search the questions
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Question>> Search(string keyword)
        {
            const StringComparison stringComparisonEnum = StringComparison.OrdinalIgnoreCase;

            return (await GetAll())
                .Where(x => x.Title.Contains(keyword, stringComparisonEnum)
                            || x.Text.Contains(keyword, stringComparisonEnum)
                            || x.Answers.Any(y => y.Text.Contains(keyword, stringComparisonEnum)));
        }
    }
}