using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //çift parametreli de bu constructor çalışır mesajda döner 
        public SuccessResult(string message) : base(true,message)
        {
        }
        //tek parametreli de ise burası çalışır ve sadece true dödürür 
        public SuccessResult():base(true)
        {
            
        }
    }
}
