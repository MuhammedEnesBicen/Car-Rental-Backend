using Core.Entities.Concrete;
using Core.Utilities.Results;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        // bu sınıffta şunu çıkardım : using Entities.Concrete;
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
