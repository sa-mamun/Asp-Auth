using Autofac;
using Microsoft.AspNetCore.Http;
using SamTech.ExpenseTrack.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamTech.ExpenseTrack.Web.Models
{
    public class MainBaseModel
    {
        public ResponseModel Response
        {
            get
            {
                if(_httpContextAccessor.HttpContext.Session.IsAvailable &&
                    _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
                {
                    var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));
                    _httpContextAccessor.HttpContext.Session.Remove(nameof(Response));

                    return response;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _httpContextAccessor.HttpContext.Session.Set(nameof(Response), value);
            }
        }

        public IHttpContextAccessor _httpContextAccessor;

        public MainBaseModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public MainBaseModel()
        {
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }
        
    }
}
