using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Eventor_Project.Models.ProjectModel;

namespace Eventor_Project.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            throw new NotImplementedException();
        }
    }
}